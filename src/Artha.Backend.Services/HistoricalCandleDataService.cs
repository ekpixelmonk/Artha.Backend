using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Artha.Backend.Services.Interface;
using Artha.Backend.Shared.Dto;

namespace Artha.Backend.Services
{
    /// <summary>
    /// Service implementation for fetching historical candle data.
    /// </summary>
    public class HistoricalCandleDataService : IHistoricalCandleDataService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IZerodhaConfigService _zerodhaConfigService;
        private readonly IZerodhaTradeableInstrumentService _instrumentService;
        private readonly ILogger<HistoricalCandleDataService> _logger;

        public HistoricalCandleDataService(
            IHttpClientFactory httpClientFactory,
            IZerodhaConfigService zerodhaConfigService,
            IZerodhaTradeableInstrumentService instrumentService,
            ILogger<HistoricalCandleDataService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _zerodhaConfigService = zerodhaConfigService;
            _instrumentService = instrumentService;
            _logger = logger;
        }

        public async Task<List<HistoricalCandleDataDto>> GetHistoricalCandleDataAsync(string symbol, string exchange, string from, string to)
        {
            try
            {
                _logger.LogInformation("Fetching instrument token for symbol: {symbol}, exchange: {exchange}", symbol, exchange);
                var instrumentToken = await _instrumentService.GetInstrumentTokenByTradingSymbolAndExchangeAsync(symbol, exchange);
                if (string.IsNullOrEmpty(instrumentToken))
                {
                    _logger.LogWarning("Instrument token not found for symbol: {symbol}, exchange: {exchange}", symbol, exchange);
                    return new List<HistoricalCandleDataDto>();
                }

                var config = await _zerodhaConfigService.GetZerodhaConfigAsync();
                if (config == null)
                    throw new Exception("Zerodha config not found");

                var apiKey = config.APIKey;
                var accessToken = config.AccessToken;

                var url = $"https://api.kite.trade/instruments/historical/{instrumentToken}/daily?from={from}&to={to}";
                var client = _httpClientFactory.CreateClient();
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Add("X-Kite-Version", "3");
                request.Headers.Authorization = new AuthenticationHeaderValue("token", $"{apiKey}:{accessToken}");

                _logger.LogInformation("Calling external API for historical candle data: {url}", url);
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var jObj = JObject.Parse(json);
                var candles = jObj["data"]?["candles"];
                var result = new List<HistoricalCandleDataDto>();
                if (candles != null)
                {
                    foreach (var candle in candles)
                    {
                        // candle: [timestamp, open, high, low, close, volume]
                        result.Add(new HistoricalCandleDataDto
                        {
                            Timestamp = candle[0]?.ToString() ?? string.Empty,
                            Open = candle[1]?.Value<decimal>() ?? 0,
                            High = candle[2]?.Value<decimal>() ?? 0,
                            Low = candle[3]?.Value<decimal>() ?? 0,
                            Close = candle[4]?.Value<decimal>() ?? 0,
                            Volume = candle[5]?.Value<int>() ?? 0
                        });
                    }
                }
                _logger.LogInformation("Fetched {Count} historical candle records for symbol: {symbol}, exchange: {exchange}", result.Count, symbol, exchange);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching historical candle data for symbol: {symbol}, exchange: {exchange}", symbol, exchange);
                throw;
            }
        }
    }
}
