using System.Collections.Generic;
using System.Threading.Tasks;
using Artha.Backend.Shared.Dto;

namespace Artha.Backend.Services.Interface
{
    /// <summary>
    /// Service interface for TradeableEtf operations.
    /// </summary>
    public interface ITradeableEtfService
    {
        /// <summary>
        /// Gets a TradeableEtfDto by symbol and exchange.
        /// </summary>
        /// <param name="symbol">The symbol of the ETF.</param>
        /// <param name="exchange">The exchange of the ETF.</param>
        /// <returns>The matching TradeableEtfDto if found; otherwise, null.</returns>
        Task<TradeableEtfDto?> GetEtfBySymbolAndExchangeAsync(string symbol, string exchange);

        /// <summary>
        /// Inserts a list of TradeableEtfDto into the database.
        /// </summary>
        /// <param name="etfs">The list of TradeableEtfDto to insert.</param>
        /// <returns>A success or failure message.</returns>
        Task<string> InsertTradeableEtfsAsync(List<TradeableEtfDto> etfs);
    }
}
