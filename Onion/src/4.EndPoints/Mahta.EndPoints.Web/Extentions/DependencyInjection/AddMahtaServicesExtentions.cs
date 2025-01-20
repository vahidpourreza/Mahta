using Mahta.Utilities;

namespace Mahta.EndPoints.Web.Extentions.DependencyInjection;

public static class AddMahtaServicesExtensions
{
    public static IServiceCollection AddMahtaUntilityServices(this IServiceCollection services)
    {
        services.AddTransient<MahtaServices>();
        return services;
    }
}