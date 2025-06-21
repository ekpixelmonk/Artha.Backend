using Artha.Backend.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Artha.Backend.Domain.Contract.Interface
{
    /// <summary>
    /// Repository interface for TradeableEtfEntity operations.
    /// </summary>
    public interface ITradeableEtfRepository
    {
        /// <summary>
        /// Inserts a single TradeableEtfEntity into the database.
        /// </summary>
        /// <param name="entity">The entity to insert.</param>
        /// <returns>The inserted entity.</returns>
        Task<TradeableEtfEntity> CreateAsync(TradeableEtfEntity entity);

        /// <summary>
        /// Inserts a list of TradeableEtfEntity into the database.
        /// </summary>
        /// <param name="entities">The list of entities to insert.</param>
        /// <returns>The list of inserted entities.</returns>
        Task<IEnumerable<TradeableEtfEntity>> CreateAsync(IEnumerable<TradeableEtfEntity> entities);

        /// <summary>
        /// Gets a TradeableEtfEntity by symbol and exchange.
        /// </summary>
        /// <param name="symbol">The symbol of the ETF.</param>
        /// <param name="exchange">The exchange of the ETF.</param>
        /// <returns>The matching TradeableEtfEntity if found; otherwise, null.</returns>
        Task<TradeableEtfEntity?> GetEtfBySymbolAndExchangeAsync(string symbol, string exchange);

        /// <summary>
        /// Gets all TradeableEtfEntity records from the database.
        /// </summary>
        /// <returns>All TradeableEtfEntity records.</returns>
        Task<List<TradeableEtfEntity>> GetAllTradeableEtfsAsync();
    }
}
