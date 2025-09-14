// Domain.Broker/Entities/ZerodhaConfig.cs

using System.ComponentModel.DataAnnotations;

namespace Domain.Broker.Entities
{
    public class ZerodhaConfig
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(250)]
        public string APIKey { get; set; } = string.Empty;

        [Required]
        [MaxLength(250)]
        public string Secret { get; set; } = string.Empty;

        [Required]
        [MaxLength(250)]
        public string UserId { get; set; } = string.Empty;

        [Required]
        [MaxLength(250)]
        public string AccessToken { get; set; } = string.Empty;

        [Required]
        [MaxLength(250)]
        public string PublicToken { get; set; } = string.Empty;
    }
}