using Artha.Backend.Shared.Dto;
using System.Threading.Tasks;

namespace Artha.Backend.Services.Interface
{
    /// <summary>
    /// Service interface for ZerodhaTradeableInstrument operations.
    /// </summary>
    public interface IZerodhaTradeableInstrumentService
    {
        /// <summary>
        /// Inserts a list of ZerodhaTradeableInstrument records into the database.
        /// </summary>
        /// <returns>A success message if the operation is successful.</returns>
        Task<string> InsertZerodhaTradeableInstrumentsAsync();

        /// <summary>
        /// Gets a ZerodhaTradeableInstrumentDto by tradingsymbol and exchange.
        /// </summary>
        /// <param name="tradingsymbol">The trading symbol of the instrument.</param>
        /// <param name="exchange">The exchange of the instrument.</param>
        /// <returns>The matching ZerodhaTradeableInstrumentDto if found; otherwise, null.</returns>
        Task<ZerodhaTradeableInstrumentDto?> GetInstrumentByTradingSymbolAndExchangeAsync(string tradingsymbol, string exchange);
    }
}
