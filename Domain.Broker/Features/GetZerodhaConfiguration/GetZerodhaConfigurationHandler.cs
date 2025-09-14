using Domain.Broker.Data;
using Microsoft.EntityFrameworkCore;

namespace Domain.Broker.Features.GetZerodhaConfiguration;

public class GetZerodhaConfigurationHandler
{
    private readonly BrokerDbContext _dbContext;

    public GetZerodhaConfigurationHandler(BrokerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<GetZerodhaConfigurationResponse?> HandleAsync(GetZerodhaConfigurationRequest request)
    {
        var config = await _dbContext.ZerodhaConfigs
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.ID == request.Id);

        if (config is null)
        {
            return null;
        }

        return new GetZerodhaConfigurationResponse
        {
            Id = config.ID,
            APIKey = config.APIKey,
            UserId = config.UserId
        };
    }
}