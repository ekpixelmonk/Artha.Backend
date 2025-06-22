using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Artha.Backend.Services.Interface;
using Artha.Backend.Shared.Dto;
using KiteConnect;

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
        private readonly IKiteSessionService _kiteSessionService;

        public HistoricalCandleDataService(
            IHttpClientFactory httpClientFactory,
            IZerodhaConfigService zerodhaConfigService,
            IZerodhaTradeableInstrumentService instrumentService,
            ILogger<HistoricalCandleDataService> logger,
            IKiteSessionService kiteSessionService)
        {
            _httpClientFactory = httpClientFactory;
            _zerodhaConfigService = zerodhaConfigService;
            _instrumentService = instrumentService;
            _logger = logger;
            _kiteSessionService = kiteSessionService;
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

                // Parse from/to dates
                if (!DateTime.TryParse(from, out var fromDate))
                {
                    _logger.LogError("Invalid 'from' date: {from}", from);
                    throw new ArgumentException("Invalid 'from' date format.");
                }
                if (!DateTime.TryParse(to, out var toDate))
                {
                    _logger.LogError("Invalid 'to' date: {to}", to);
                    throw new ArgumentException("Invalid 'to' date format.");
                }

                // Get Kite instance from KiteSessionService
                //var kiteSessionService = _instrumentService as IKiteSessionService ?? throw new Exception("KiteSessionService not available");
                var kite = _kiteSessionService.Kite;
                if (kite == null)
                {
                    _logger.LogError("Kite session is not initialized.");
                    throw new Exception("Kite session is not initialized.");
                }

                _logger.LogInformation("Fetching historical candle data from Kite for instrumentToken: {instrumentToken}", instrumentToken);
                var historical = kite.GetHistoricalData(
                    InstrumentToken: instrumentToken,
                    FromDate: fromDate,
                    ToDate: toDate,
                    Interval: Constants.INTERVAL_DAY,
                    Continuous: false
                );

                var result = new List<HistoricalCandleDataDto>();
                foreach (var candle in historical)
                {
                    result.Add(new HistoricalCandleDataDto
                    {
                        Timestamp = candle.TimeStamp.ToString("o"),
                        Open = candle.Open,
                        High = candle.High,
                        Low = candle.Low,
                        Close = candle.Close,
                        Volume = (int)candle.Volume
                    });
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
