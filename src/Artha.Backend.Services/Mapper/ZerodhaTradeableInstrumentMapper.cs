using Artha.Backend.Domain.Entity;
using Artha.Backend.Shared.Dto;
using CsvHelper;

namespace Artha.Backend.Services.Mapper
{
    /// <summary>
    /// Mapper for converting ZerodhaTradeableInstrumentEntity to ZerodhaTradeableInstrumentDto and vice versa.
    /// </summary>
    public static class ZerodhaTradeableInstrumentMapper
    {
        public static ZerodhaTradeableInstrumentDto MapToDto(ZerodhaTradeableInstrumentEntity entity)
        {
            return new ZerodhaTradeableInstrumentDto
            {
                ID = entity.ID,
                InstrumentToken = entity.instrument_token,
                ExchangeToken = entity.exchange_token,
                Tradingsymbol = entity.tradingsymbol,
                Name = entity.name,
                LastPrice = entity.last_price,
                Expiry = entity.expiry,
                Strike = entity.strike,
                TickSize = entity.tick_size,
                LotSize = entity.lot_size,
                InstrumentType = entity.instrument_type,
                Segment = entity.segment,
                Exchange = entity.exchange
            };
        }

        public static ZerodhaTradeableInstrumentEntity MapToEntity(ZerodhaTradeableInstrumentDto dto)
        {
            return new ZerodhaTradeableInstrumentEntity
            {
                ID = dto.ID,
                instrument_token = dto.InstrumentToken,
                exchange_token = dto.ExchangeToken,
                tradingsymbol = dto.Tradingsymbol,
                name = dto.Name,
                last_price = dto.LastPrice,
                expiry = dto.Expiry,
                strike = dto.Strike,
                tick_size = dto.TickSize,
                lot_size = dto.LotSize,
                instrument_type = dto.InstrumentType,
                segment = dto.Segment,
                exchange = dto.Exchange
            };
        }

        /// <summary>
        /// Registers the CsvHelper class map for ZerodhaTradeableInstrumentDto.
        /// </summary>
        public static void RegisterCsvMap(CsvReader csv)
        {
            csv.Context.RegisterClassMap<ZerodhaTradeableInstrumentCsvMapper>();
        }
    }
}
