using Mahta.Extensions.UsersManagement.Abstractions;
using Mahta.Extensions.UsersManagement.Options;
using Mahta.Extensions.UsersManagement.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mahta.Extensions.DependencyInjection;

public static class UserInfoServiceCollectionExtensions
{
    public static IServiceCollection AddMahtaWebUserInfoService(this IServiceCollection services, IConfiguration configuration, bool useFake = false)
    {
        if (useFake)
        {
            services.AddSingleton<IUserInfoService, FakeUserInfoService>();

        }
        else
        {
            services.Configure<UserManagementOptions>(configuration);
            services.AddSingleton<IUserInfoService, WebUserInfoService>();

        }
        return services;
    }


    public static IServiceCollection AddMahtaWebUserInfoService(this IServiceCollection services, IConfiguration configuration, string sectionName, bool useFake = false)
    {
        services.AddMahtaWebUserInfoService(configuration.GetSection(sectionName), useFake);
        return services;
    }

    public static IServiceCollection AddMahtaWebUserInfoService(this IServiceCollection services, Action<UserManagementOptions> setupAction, bool useFake = false)
    {
        if (useFake)
        {
            services.AddSingleton<IUserInfoService, FakeUserInfoService>();

        }
        else
        {
            services.Configure(setupAction);
            services.AddSingleton<IUserInfoService, WebUserInfoService>();

        }
        return services;
    }
}

