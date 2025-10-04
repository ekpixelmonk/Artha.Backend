namespace Domain.Broker.Features.GetZerodhaConfiguration;

public class GetZerodhaConfigurationRequest
{
    public string UserId { get; set; } = string.Empty;
}

public class GetZerodhaConfigurationResponse
{
    public int Id { get; set; }
    public string APIKey { get; set; } = string.Empty;
    public string Secret { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public string AccessToken { get; set; } = string.Empty;
    public string PublicToken { get; set; } = string.Empty;
}