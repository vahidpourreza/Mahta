using Mahta.Extensions.Translations.Abstractions;
using Mahta.Extensions.Translations.Parrot.Options;
using Mahta.Extensions.Translations.Parrot.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mahta.Extensions.DependencyInjection;

public static class ParrotTranslatorServiceCollectionExtensions
{
    public static IServiceCollection AddMahtaParrotTranslator(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<ITranslator, ParrotTranslator>();
        services.Configure<ParrotTranslatorOptions>(configuration);
        return services;
    }

    public static IServiceCollection AddMahtaParrotTranslator(this IServiceCollection services, IConfiguration configuration, string sectionName)
    {
        services.AddMahtaParrotTranslator(configuration.GetSection(sectionName));
        return services;
    }

    public static IServiceCollection AddMahtaParrotTranslator(this IServiceCollection services, Action<ParrotTranslatorOptions> setupAction)
    {
        services.AddSingleton<ITranslator, ParrotTranslator>();
        services.Configure(setupAction);
        return services;
    }
}