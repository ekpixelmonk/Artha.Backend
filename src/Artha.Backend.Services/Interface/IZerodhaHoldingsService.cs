using System.Threading.Tasks;

namespace Artha.Backend.Services.Interface
{
    /// <summary>
    /// Service interface for ZerodhaHoldings operations.
    /// </summary>
    public interface IZerodhaHoldingsService
    {
        /// <summary>
        /// Inserts ZerodhaHoldings records into the database.
        /// </summary>
        /// <returns>A success or failure message.</returns>
        Task<string> InsertZerodhaHoldingsAsync();
    }
}
