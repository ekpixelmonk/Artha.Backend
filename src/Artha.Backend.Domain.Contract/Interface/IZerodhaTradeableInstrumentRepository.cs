using Artha.Backend.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Artha.Backend.Domain.Contract.Interface
{
    /// <summary>
    /// Repository interface for ZerodhaTradeableInstrumentEntity operations.
    /// </summary>
    public interface IZerodhaTradeableInstrumentRepository
    {
        /// <summary>
        /// Creates a single ZerodhaTradeableInstrumentEntity in the database.
        /// </summary>
        /// <param name="entity">The entity to create.</param>
        /// <returns>The created entity.</returns>
        Task<ZerodhaTradeableInstrumentEntity> CreateAsync(ZerodhaTradeableInstrumentEntity entity);

        /// <summary>
        /// Creates a list of ZerodhaTradeableInstrumentEntity in the database.
        /// </summary>
        /// <param name="entities">The list of entities to create.</param>
        /// <returns>The list of created entities.</returns>
        Task<IEnumerable<ZerodhaTradeableInstrumentEntity>> CreateAsync(IEnumerable<ZerodhaTradeableInstrumentEntity> entities);

        /// <summary>
        /// Gets a ZerodhaTradeableInstrumentEntity by tradingsymbol and exchange.
        /// </summary>
        /// <param name="tradingsymbol">The trading symbol of the instrument.</param>
        /// <param name="exchange">The exchange of the instrument.</param>
        /// <returns>The matching ZerodhaTradeableInstrumentEntity if found; otherwise, null.</returns>
        Task<ZerodhaTradeableInstrumentEntity?> GetInstrumentByTradingSymbolAndExchangeAsync(string tradingsymbol, string exchange);
    }
}
