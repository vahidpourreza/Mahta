using Mahta.Extensions.Caching.Abstractions;
using Mahta.Extensions.Caching.InMemory.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Mahta.Extensions.DependencyInjection;

public static class InMemoryCachingServiceCollectionExtensions
{
    public static IServiceCollection AddMahtaInMemoryCaching(this IServiceCollection services)
                     => services
                      .AddMemoryCache()
                      .AddTransient<ICacheAdapter, InMemoryCacheAdapter>();
}