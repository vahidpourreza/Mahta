using Mahta.Extensions.ChangeDataLog.Hamster.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mahta.Extensions.DependencyInjection;

public static class changeeDatalogServiceCollectionExtensions
{
    public static IServiceCollection AddMahtaHamsterChangeDatalog(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ChangeDataLogHamsterOptions>(configuration);
        return services;
    }

    public static IServiceCollection AddMahtaHamsterChangeDatalog(this IServiceCollection services, IConfiguration configuration, string sectionName)
    {
        services.AddMahtaHamsterChangeDatalog(configuration.GetSection(sectionName));
        return services;
    }

    public static IServiceCollection AddMahtaHamsterChangeDatalog(this IServiceCollection services, Action<ChangeDataLogHamsterOptions> setupAction)
    {
        services.Configure(setupAction);
        return services;
    }
}