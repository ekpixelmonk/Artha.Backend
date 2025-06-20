using Newtonsoft.Json;

namespace Artha.Backend.Shared.Dto
{
    /// <summary>
    /// Data Transfer Object for ZerodhaTradeableInstrument entity.
    /// </summary>
    public class ZerodhaTradeableInstrumentDto
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("instrument_token")]
        public string? InstrumentToken { get; set; }

        [JsonProperty("exchange_token")]
        public string? ExchangeToken { get; set; }

        [JsonProperty("tradingsymbol")]
        public string Tradingsymbol { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("last_price")]
        public decimal? LastPrice { get; set; }

        [JsonProperty("expiry")]
        public string? Expiry { get; set; }

        [JsonProperty("strike")]
        public decimal? Strike { get; set; }

        [JsonProperty("tick_size")]
        public float? TickSize { get; set; }

        [JsonProperty("lot_size")]
        public int? LotSize { get; set; }

        [JsonProperty("instrument_type")]
        public string? InstrumentType { get; set; }

        [JsonProperty("segment")]
        public string? Segment { get; set; }

        [JsonProperty("exchange")]
        public string Exchange { get; set; } = string.Empty;
    }
}
