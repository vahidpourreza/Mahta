﻿namespace Mahta.EndPoints.Web.Extentions.DependencyInjection;


/// <summary>
/// توابع کمکی جهت ثبت نیازمندی‌های لایه داده
/// </summary>
public static class AddDataAccessExtentsions
{
    public static IServiceCollection AddMahtaDataAccess(this IServiceCollection services, IEnumerable<Assembly> assembliesForSearch)
        => services
            .AddRepositories(assembliesForSearch)
            .AddUnitOfWorks(assembliesForSearch);

    public static IServiceCollection AddRepositories(this IServiceCollection services, IEnumerable<Assembly> assembliesForSearch)
        => services
           .AddWithTransientLifetime(assembliesForSearch, typeof(ICommandRepository<,>), typeof(IQueryRepository));

    public static IServiceCollection AddUnitOfWorks(this IServiceCollection services, IEnumerable<Assembly> assembliesForSearch)
        => services
           .AddWithTransientLifetime(assembliesForSearch, typeof(IUnitOfWork));
}
