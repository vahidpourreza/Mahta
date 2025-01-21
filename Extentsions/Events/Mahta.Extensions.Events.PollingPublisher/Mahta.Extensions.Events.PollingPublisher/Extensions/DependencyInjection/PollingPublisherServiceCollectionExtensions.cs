using Mahta.Extensions.Events.PollingPublisher.Options;
using Mahta.Extensions.Events.PollingPublisher;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mahta.Extensions.DependencyInjection;


public static class PollingPublisherServiceCollectionExtensions
{
    public static IServiceCollection AddMahtaPollingPublisher(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<PollingPublisherOptions>(configuration);
        AddServices(services);
        return services;
    }

    public static IServiceCollection AddMahtaPollingPublisher(this IServiceCollection services, IConfiguration configuration, string sectionName)
    {
        services.AddMahtaPollingPublisher(configuration.GetSection(sectionName));
        return services;
    }

    public static IServiceCollection AddMahtaPollingPublisher(this IServiceCollection services, Action<PollingPublisherOptions> setupAction)
    {
        services.Configure(setupAction);
        AddServices(services);
        return services;
    }



    private static void AddServices(IServiceCollection services)
    {
        services.AddHostedService<PoolingPublisherBackgroundService>();
    }

}