using Microsoft.Extensions.Hosting;
using NServiceBus;

namespace NServiceBoXes.Endpoints.AmazonSQS;

public static class HostBuilderExtensions
{
    public static IHostBuilder UseNServiceBusAmazonSqsEndpoint(this IHostBuilder builder, Action<AmazonSqsEndpoint>? endpoint = null)
    {
        builder.UseNServiceBus(hostBuilderContext=>
        {
            var ep = new AmazonSqsEndpoint(hostBuilderContext.Configuration);
            endpoint?.Invoke(ep);

            return ep;
        });
        
        return builder;
    }
    
    public static IHostBuilder UseNServiceBusAmazonSqsEndpoint(this IHostBuilder builder, string endpointName, Action<AmazonSqsEndpoint>? endpoint = null)
    {
        builder.UseNServiceBus(hostBuilderContext=>
        {
            var ep = new AmazonSqsEndpoint(endpointName, hostBuilderContext.Configuration);
            endpoint?.Invoke(ep);

            return ep;
        });
        
        return builder;
    }
}