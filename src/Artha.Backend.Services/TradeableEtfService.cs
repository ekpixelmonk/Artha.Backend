using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Artha.Backend.Services.Interface;
using Artha.Backend.Shared.Dto;
using Artha.Backend.Domain.Contract.Interface;
using Microsoft.Extensions.Logging;
using Artha.Backend.Services.Mapper;

namespace Artha.Backend.Services
{
    /// <summary>
    /// Service implementation for TradeableEtf operations.
    /// </summary>
    public class TradeableEtfService : ITradeableEtfService
    {
        private readonly ITradeableEtfRepository _repository;
        private readonly ILogger<TradeableEtfService> _logger;

        public TradeableEtfService(ITradeableEtfRepository repository, ILogger<TradeableEtfService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<TradeableEtfDto?> GetEtfBySymbolAndExchangeAsync(string symbol, string exchange)
        {
            try
            {
                var entity = await _repository.GetEtfBySymbolAndExchangeAsync(symbol, exchange);
                if (entity == null)
                    return null;
                return TradeableEtfMapper.MapToDto(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching ETF by symbol and exchange");
                throw;
            }
        }

        public async Task<string> InsertTradeableEtfsAsync(List<TradeableEtfDto> etfs)
        {
            try
            {
                _logger.LogInformation("Starting insertion of {Count} tradeable ETFs.", etfs.Count);
                var existingEtfs = await _repository.GetAllTradeableEtfsAsync();
                var existingPairs = new HashSet<(string Symbol, string Exchange)>(
                    existingEtfs.Select(e => (e.Symbol, e.Exchange)));
                var newEtfs = etfs
                    .Where(dto => !existingPairs.Contains((dto.Symbol, dto.Exchange)))
                    .Select(TradeableEtfMapper.MapToEntity)
                    .ToList();
                if (newEtfs.Any())
                {
                    await _repository.CreateAsync(newEtfs);
                    _logger.LogInformation("Inserted {Count} new tradeable ETFs.", newEtfs.Count);
                    return $"Successfully inserted {newEtfs.Count} new tradeable ETFs.";
                }
                _logger.LogInformation("No new tradeable ETFs to insert.");
                return "No new tradeable ETFs to insert.";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inserting tradeable ETFs");
                return $"Failed to insert tradeable ETFs: {ex.Message}";
            }
        }
    }
}
