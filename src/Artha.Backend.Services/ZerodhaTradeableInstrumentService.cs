using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Artha.Backend.Services.Interface;
using Artha.Backend.Shared.Dto;
using Microsoft.Extensions.Logging;

namespace Artha.Backend.Services
{
    /// <summary>
    /// Service implementation for ZerodhaTradeableInstrument operations.
    /// </summary>
    public class ZerodhaTradeableInstrumentService : IZerodhaTradeableInstrumentService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IZerodhaConfigService _zerodhaConfigService;
        private readonly ILogger<ZerodhaTradeableInstrumentService> _logger;

        public ZerodhaTradeableInstrumentService(
            IHttpClientFactory httpClientFactory,
            IZerodhaConfigService zerodhaConfigService,
            ILogger<ZerodhaTradeableInstrumentService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _zerodhaConfigService = zerodhaConfigService;
            _logger = logger;
        }

        public async Task<string> InsertZerodhaTradeableInstrumentsAsync()
        {
            try
            {
                // Fetch API key and access token from ZerodhaConfigService
                var config = await _zerodhaConfigService.GetZerodhaConfigAsync();
                if (config == null)
                    throw new Exception("Zerodha config not found");

                var apiKey = config.APIKey;
                var accessToken = config.AccessToken;

                var client = _httpClientFactory.CreateClient();
                var request = new HttpRequestMessage(HttpMethod.Get, "https://api.kite.trade/instruments/NSE");
                request.Headers.Add("X-Kite-Version", "3");
                request.Headers.Authorization = new AuthenticationHeaderValue("token", $"{apiKey}:{accessToken}");

                _logger.LogInformation("Starting fetch of Zerodha tradeable instruments from external API.");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadAsStringAsync();
                // For now, just return a message indicating success in fetching data
                return "Fetched instruments data successfully.";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching Zerodha tradeable instruments");
                throw;
            }
        }
    }
}
