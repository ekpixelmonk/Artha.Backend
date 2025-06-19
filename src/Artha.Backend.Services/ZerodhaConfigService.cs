using System.Threading.Tasks;
using Artha.Backend.Domain.Contract.Interface;
using Artha.Backend.Services.Interface;
using Artha.Backend.Services.Mapper;
using Artha.Backend.Shared.Dto;

namespace Artha.Backend.Services
{
    /// <summary>
    /// Service implementation for fetching ZerodhaConfigDto.
    /// </summary>
    public class ZerodhaConfigService : IZerodhaConfigService
    {
        private readonly IZerodhaConfigRepository _repository;

        public ZerodhaConfigService(IZerodhaConfigRepository repository)
        {
            _repository = repository;
        }

        public async Task<ZerodhaConfigDto?> GetZerodhaConfigAsync()
        {
            try
            {
                var entity = await _repository.GetZerodhaConfigAsync();
                if (entity == null)
                    throw new System.Exception("NotFound"); // Placeholder for custom NotFound exception
                return ZerodhaConfigMapper.MapToZerodhaConfigDto(entity);
            }
            catch
            {
                // Rethrow to be handled at a higher level or replaced with a custom exception later
                throw;
            }
        }
    }
}
