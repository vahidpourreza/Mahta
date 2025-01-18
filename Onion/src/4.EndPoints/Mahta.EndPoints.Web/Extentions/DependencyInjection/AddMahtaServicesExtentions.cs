using Mahta.Utilities;

namespace Mahta.EndPoints.Web.Extentions.DependencyInjection;

public static class AddZaminServicesExtensions
{
    public static IServiceCollection AddMahtaUntilityServices(this IServiceCollection services)
    {
        services.AddTransient<MahtaServices>();
        return services;
    }
}