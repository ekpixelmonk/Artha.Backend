namespace Domain.Broker.Features.GetZerodhaConfiguration;

public class GetZerodhaConfigurationRequest
{
    public int Id { get; set; }
}

public class GetZerodhaConfigurationResponse
{
    public int Id { get; set; }
    public string APIKey { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
}