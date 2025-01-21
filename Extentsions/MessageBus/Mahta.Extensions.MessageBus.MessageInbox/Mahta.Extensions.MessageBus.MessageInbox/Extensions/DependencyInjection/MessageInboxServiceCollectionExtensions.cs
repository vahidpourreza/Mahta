using Mahta.Extensions.MessageBus.Abstractions;
using Mahta.Extensions.MessageBus.MessageInbox.Options;
using Mahta.Extensions.MessageBus.MessageInbox;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mahta.Extensions.DependencyInjection;

public static class MessageInboxServiceCollectionExtensions
{
    public static IServiceCollection AddMahtaMessageInbox(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MessageInboxOptions>(configuration);
        AddServices(services);
        return services;
    }

    public static IServiceCollection AddMahtaMessageInbox(this IServiceCollection services, IConfiguration configuration, string sectionName)
    {
        services.AddMahtaMessageInbox(configuration.GetSection(sectionName));
        return services;
    }

    public static IServiceCollection AddMahtaMessageInbox(this IServiceCollection services, Action<MessageInboxOptions> setupAction)
    {
        services.Configure(setupAction);
        AddServices(services);
        return services;
    }



    private static void AddServices(IServiceCollection services)
    {
        services.AddScoped<IMessageConsumer, InboxMessageConsumer>();
    }


}

