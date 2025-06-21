using Artha.Backend.Domain.Entity;
using Artha.Backend.Shared.Dto;

namespace Artha.Backend.Services.Mapper
{
    /// <summary>
    /// Mapper for converting TradeableEtfEntity to TradeableEtfDto and vice versa.
    /// </summary>
    public static class TradeableEtfMapper
    {
        public static TradeableEtfDto MapToDto(TradeableEtfEntity entity)
        {
            return new TradeableEtfDto
            {
                ID = entity.ID,
                Symbol = entity.Symbol,
                Exchange = entity.Exchange
            };
        }

        public static TradeableEtfEntity MapToEntity(TradeableEtfDto dto)
        {
            return new TradeableEtfEntity
            {
                ID = dto.ID,
                Symbol = dto.Symbol,
                Exchange = dto.Exchange
            };
        }
    }
}
