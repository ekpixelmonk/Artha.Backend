using Newtonsoft.Json;

namespace Artha.Backend.Shared.Dto
{
    /// <summary>
    /// Data Transfer Object for ZerodhaConfig entity.
    /// </summary>
    public class ZerodhaConfigDto
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("apiKey")]
        public string APIKey { get; set; } = string.Empty;

        [JsonProperty("secret")]
        public string Secret { get; set; } = string.Empty;

        [JsonProperty("userId")]
        public string UserId { get; set; } = string.Empty;

        [JsonProperty("accessToken")]
        public string AccessToken { get; set; } = string.Empty;

        [JsonProperty("publicToken")]
        public string PublicToken { get; set; } = string.Empty;
    }
}
