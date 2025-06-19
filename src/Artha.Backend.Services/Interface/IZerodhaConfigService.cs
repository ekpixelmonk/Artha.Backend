using System.Threading.Tasks;
using Artha.Backend.Shared.Dto;

namespace Artha.Backend.Services.Interface
{
    /// <summary>
    /// Service interface for fetching ZerodhaConfigDto.
    /// </summary>
    public interface IZerodhaConfigService
    {
        /// <summary>
        /// Fetches the ZerodhaConfigDto.
        /// </summary>
        /// <returns>The ZerodhaConfigDto if found; otherwise, null.</returns>
        Task<ZerodhaConfigDto?> GetZerodhaConfigAsync();
    }
}
