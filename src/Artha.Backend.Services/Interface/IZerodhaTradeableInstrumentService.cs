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
    }
}
