using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Artha.Backend.Services.Interface;
using Artha.Backend.Shared.Dto;
using KiteConnect;
using System.Net.Http;
using System.Web;

namespace Artha.Backend.Services
{
    /// <summary>
    /// Singleton service for managing Kite user session for Zerodha.
    /// </summary>
    public class KiteSessionService : IKiteSessionService
    {
        //private readonly IZerodhaConfigService _zerodhaConfigService;
        private readonly ILogger<KiteSessionService> _logger;
        private Kite? _kite;
        private string? _loginUrl;
        private string? _apiKey;
        private string? _apiSecret;
        private string? _accessToken;

        public KiteSessionService(ILogger<KiteSessionService> logger)
        {
            //_zerodhaConfigService = zerodhaConfigService;
            _logger = logger;
        }

        public Kite? Kite => _kite;

        public async Task<string> InitializeKiteSessionAndGetLoginUrlAsync()
        {
            try
            {
                //var config = await _zerodhaConfigService.GetZerodhaConfigAsync();
                //if (config == null)
                //    throw new Exception("Zerodha config not found");

                _apiKey = Environment.GetEnvironmentVariable("ZERODHA_API_KEY");
                _apiSecret = Environment.GetEnvironmentVariable("ZERODHA_API_SECRET");

                _kite = new Kite(_apiKey, Debug: true);
                _loginUrl = _kite.GetLoginURL();
                _logger.LogInformation("Kite session initialized. Login URL: {loginUrl}", _loginUrl);
                return _loginUrl;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error initializing Kite session");
                throw;
            }
        }

        public async Task<bool> GenerateKiteUserSessionAsync(string requestToken)
        {
            try
            {
                if (_kite == null || string.IsNullOrEmpty(_apiSecret))
                {
                    _logger.LogWarning("Kite session not initialized. Call InitializeKiteSessionAndGetLoginUrlAsync first.");
                    throw new InvalidOperationException("Kite session not initialized.");
                }
                var user = _kite.GenerateSession(requestToken, _apiSecret);
                _logger.LogInformation("Kite user session generated for user: {userId}", user.UserId);

                _accessToken = user.AccessToken;
                _kite.SetAccessToken(_accessToken);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating Kite user session");
                return false;
            }
        }
    }
}
