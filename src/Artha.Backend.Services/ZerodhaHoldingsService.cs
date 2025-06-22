using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Artha.Backend.Services.Interface;
using KiteConnect;

namespace Artha.Backend.Services
{
    /// <summary>
    /// Service implementation for ZerodhaHoldings operations.
    /// </summary>
    public class ZerodhaHoldingsService : IZerodhaHoldingsService
    {
        private readonly IKiteSessionService _kiteSessionService;
        private readonly ILogger<ZerodhaHoldingsService> _logger;

        public ZerodhaHoldingsService(
            IKiteSessionService kiteSessionService,
            ILogger<ZerodhaHoldingsService> logger)
        {
            _kiteSessionService = kiteSessionService;
            _logger = logger;
        }

        public async Task<string> InsertZerodhaHoldingsAsync()
        {
            try
            {
                var kite = _kiteSessionService.Kite;

                if (kite == null)
                {
                    _logger.LogError("Kite session is not initialized after session generation.");
                    return "Kite session is not initialized.";
                }

                _logger.LogInformation("Fetching holdings using Kite session.");
                List<Holding> holdings = kite.GetHoldings();
                
                if (holdings == null || holdings.Count == 0)
                {
                    _logger.LogWarning("No holdings found for the user.");
                    return "No holdings found.";
                }

                // TODO: Map Kite Holding to ZerodhaHoldingsDto or Entity as needed
                // Example: var dtos = holdings.Select(MapToDto).ToList();

                _logger.LogInformation("Fetched {Count} holdings from Kite.", holdings.Count);
                return $"Fetched {holdings.Count} holdings from Kite.";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching Zerodha holdings from Kite session");
                return $"Failed to fetch Zerodha holdings: {ex.Message}";
            }
        }
    }
}
