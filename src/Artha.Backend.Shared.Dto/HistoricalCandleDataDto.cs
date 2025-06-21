using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Artha.Backend.Shared.Dto
{
    /// <summary>
    /// Data Transfer Object for historical candle data.
    /// </summary>
    public class HistoricalCandleDataDto
    {
        [JsonProperty("timestamp")]
        [MaxLength(100)]
        public string Timestamp { get; set; } = string.Empty;

        [JsonProperty("open")]
        public decimal Open { get; set; }

        [JsonProperty("high")]
        public decimal High { get; set; }

        [JsonProperty("low")]
        public decimal Low { get; set; }

        [JsonProperty("close")]
        public decimal Close { get; set; }

        [JsonProperty("volume")]
        public int Volume { get; set; }
    }
}
