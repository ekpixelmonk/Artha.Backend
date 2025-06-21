using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Artha.Backend.Shared.Dto
{
    /// <summary>
    /// Data Transfer Object for TradeableEtfEntity.
    /// </summary>
    public class TradeableEtfDto
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(250)]
        [JsonProperty("symbol")]
        public string Symbol { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        [JsonProperty("exchange")]
        public string Exchange { get; set; } = string.Empty;
    }
}
