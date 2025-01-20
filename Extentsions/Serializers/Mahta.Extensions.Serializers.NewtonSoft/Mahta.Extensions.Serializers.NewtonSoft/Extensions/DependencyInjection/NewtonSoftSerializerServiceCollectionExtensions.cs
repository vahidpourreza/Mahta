using Mahta.Extensions.Serializers.Abstractions;
using Mahta.Extensions.Serializers.NewtonSoft.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Mahta.Extensions.DependencyInjection;

public static class NewtonSoftSerializerServiceCollectionExtensions
{
    public static IServiceCollection AddMahtaNewtonSoftSerializer(this IServiceCollection services) => services.AddSingleton<IJsonSerializer, NewtonSoftSerializer>();
}