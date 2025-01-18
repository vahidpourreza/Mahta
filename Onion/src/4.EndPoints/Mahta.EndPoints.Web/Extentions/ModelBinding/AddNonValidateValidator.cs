using Mahta.EndPoints.Web.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Mahta.EndPoints.Web.Extentions.ModelBinding;

public static class NonValidatingValidatorExtensions
{
    public static IServiceCollection AddNonValidatingValidator(this IServiceCollection services)
    {
        var validator = services.FirstOrDefault(s => s.ServiceType == typeof(IObjectModelValidator));
        if (validator != null)
        {
            services.Remove(validator);
            services.Add(new ServiceDescriptor(typeof(IObjectModelValidator), _ => new NonValidatingValidator(), ServiceLifetime.Singleton));
        }
        return services;
    }
}
