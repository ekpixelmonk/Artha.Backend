using CsvHelper.Configuration;
using Artha.Backend.Shared.Dto;

namespace Artha.Backend.Services.Mapper
{
    /// <summary>
    /// CsvHelper ClassMap for ZerodhaTradeableInstrumentDto to map CSV headers to DTO properties.
    /// </summary>
    public sealed class ZerodhaTradeableInstrumentCsvMapper : ClassMap<ZerodhaTradeableInstrumentDto>
    {
        public ZerodhaTradeableInstrumentCsvMapper()
        {
            Map(m => m.InstrumentToken).Name("instrument_token");
            Map(m => m.ExchangeToken).Name("exchange_token");
            Map(m => m.Tradingsymbol).Name("tradingsymbol");
            Map(m => m.Name).Name("name");
            Map(m => m.LastPrice).Name("last_price");
            Map(m => m.Expiry).Name("expiry");
            Map(m => m.Strike).Name("strike");
            Map(m => m.TickSize).Name("tick_size");
            Map(m => m.LotSize).Name("lot_size");
            Map(m => m.InstrumentType).Name("instrument_type");
            Map(m => m.Segment).Name("segment");
            Map(m => m.Exchange).Name("exchange");
        }
    }
}
