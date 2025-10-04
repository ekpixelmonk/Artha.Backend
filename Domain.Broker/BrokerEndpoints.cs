using Domain.Broker.Features.GetZerodhaConfiguration; // Updated using statement
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Domain.Broker;

public static class BrokerEndpoints
{
    public static IEndpointRouteBuilder MapBrokerEndpoints(this IEndpointRouteBuilder app)
    {
        // create a route group with versioned prefix
        var group = app.MapGroup("/api/v1/broker").WithTags("Broker");

        //Register all broker-related endpoints here
        group.MapGetZerodhaConfigurationEndpoint();

        return app;
    }
}