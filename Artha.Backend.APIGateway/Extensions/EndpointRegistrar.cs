using Domain.Broker;

namespace Artha.Backend.APIGateway.Extensions
{
    public static class EndpointRegistrar
    {
        public static IEndpointRouteBuilder MapDomainEndpoints(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapBrokerEndpoints();

            return endpoints;
        }
    }
}
