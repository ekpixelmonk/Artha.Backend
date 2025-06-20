using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Artha.Backend.Services.Interface;

namespace Artha.Backend.Services
{
    /// <summary>
    /// Service implementation for ZerodhaHoldings operations.
    /// </summary>
    public class ZerodhaHoldingsService : IZerodhaHoldingsService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IZerodhaConfigService _zerodhaConfigService;
        private readonly ILogger<ZerodhaHoldingsService> _logger;

        public ZerodhaHoldingsService(
            IHttpClientFactory httpClientFactory,
            IZerodhaConfigService zerodhaConfigService,
            ILogger<ZerodhaHoldingsService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _zerodhaConfigService = zerodhaConfigService;
            _logger = logger;
        }

        public async Task<string> InsertZerodhaHoldingsAsync()
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
                var request = new HttpRequestMessage(HttpMethod.Get, "https://api.kite.trade/portfolio/holdings");
                request.Headers.Add("X-Kite-Version", "3");
                request.Headers.Authorization = new AuthenticationHeaderValue("token", $"{apiKey}:{accessToken}");

                _logger.LogInformation("Starting fetch of Zerodha holdings from external API.");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadAsStringAsync();
                _logger.LogInformation("Successfully fetched Zerodha holdings data from external API.");

                // Further processing will be implemented later
                return "Fetched Zerodha holdings data successfully.";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching Zerodha holdings");
                return $"Failed to fetch Zerodha holdings: {ex.Message}";
            }
        }
    }
}
