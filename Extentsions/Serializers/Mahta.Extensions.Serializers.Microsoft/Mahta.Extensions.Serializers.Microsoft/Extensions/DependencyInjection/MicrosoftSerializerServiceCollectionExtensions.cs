using Mahta.Extensions.Serializers.Abstractions;
using Mahta.Extensions.Serializers.Microsoft.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Mahta.Extensions.DependencyInjection;

public static class MicrosoftSerializerServiceCollectionExtensions
{
    public static IServiceCollection AddMahtaMicrosoftSerializer(this IServiceCollection services) => services.AddSingleton<IJsonSerializer, MicrosoftSerializer>();
}
