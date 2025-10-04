using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;

namespace Domain.Broker.Features.GetZerodhaConfiguration
{
    public static class GetZerodhaConfigurationEndpoint
    {
        public static IEndpointRouteBuilder MapGetZerodhaConfigurationEndpoint(this IEndpointRouteBuilder endpoint)
        {
            endpoint.MapGet("/configuration/zerodha/{userid}", // Route can be more specific now
                async (string userid, GetZerodhaConfigurationHandler handler) =>
                {
                    var request = new GetZerodhaConfigurationRequest { UserId = userid };
                    var result = await handler.HandleAsync(request);

                    return result is not null
                        ? Results.Ok(result)
                        : Results.NotFound();
                })
                .WithName("GetZerodhaConfiguration") // Updated name for OpenAPI
                .WithTags("Broker") // Ensure it is tagged under Broker
                .Produces<GetZerodhaConfigurationResponse>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound);

            return endpoint;
        }
    }
}
