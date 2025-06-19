using Artha.Backend.Domain.Entity;
using Artha.Backend.Shared.Dto;

namespace Artha.Backend.Services.Mapper
{
    /// <summary>
    /// Mapper for converting ZerodhaConfig entity to ZerodhaConfigDto.
    /// </summary>
    public static class ZerodhaConfigMapper
    {
        public static ZerodhaConfigDto MapToZerodhaConfigDto(ZerodhaConfig entity)
        {
            return new ZerodhaConfigDto
            {
                ID = entity.ID,
                APIKey = entity.APIKey,
                Secret = entity.Secret,
                UserId = entity.UserId,
                AccessToken = entity.AccessToken,
                PublicToken = entity.PublicToken
            };
        }
    }
}
