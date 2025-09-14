using Domain.Broker.Features.GetZerodhaConfiguration; // Updated using statement
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Domain.Broker;

public static class BrokerEndpoints
{
    public static IEndpointRouteBuilder MapBrokerEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/broker").WithTags("Broker");

        group.MapGet("/configuration/zerodha/{id:int}", // Route can be more specific now
            async (int id, GetZerodhaConfigurationHandler handler) =>
            {
                var request = new GetZerodhaConfigurationRequest { Id = id };
                var result = await handler.HandleAsync(request);

                return result is not null
                    ? Results.Ok(result)
                    : Results.NotFound();
            })
            .WithName("GetZerodhaConfiguration") // Updated name for OpenAPI
            .Produces<GetZerodhaConfigurationResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

        return app;
    }
}