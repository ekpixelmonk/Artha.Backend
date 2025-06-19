using System;

namespace Artha.Backend.Domain.Entity
{
    public class ZerodhaTradeableInstrumentEntity
    {
        public int ID { get; set; }
        public string? instrument_token { get; set; }
        public string? exchange_token { get; set; }
        public string tradingsymbol { get; set; } // Required
        public string? name { get; set; }
        public decimal? last_price { get; set; }
        public string? expiry { get; set; } // Date as string, nullable
        public decimal? strike { get; set; }
        public float? tick_size { get; set; }
        public int? lot_size { get; set; }
        public string? instrument_type { get; set; }
        public string? segment { get; set; }
        public string exchange { get; set; } // Required
    }
}
