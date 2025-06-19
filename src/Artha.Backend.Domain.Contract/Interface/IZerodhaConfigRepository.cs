using Artha.Backend.Domain.Entity;
using System.Threading.Tasks;

namespace Artha.Backend.Domain.Contract.Interface
{
    /// <summary>
    /// Repository interface for fetching ZerodhaConfig details from the database.
    /// </summary>
    public interface IZerodhaConfigRepository
    {
        /// <summary>
        /// Fetches the ZerodhaConfig entity from the database.
        /// </summary>
        /// <returns>The ZerodhaConfig entity if found; otherwise, null.</returns>
        Task<ZerodhaConfig?> GetZerodhaConfigAsync();
    }
}
