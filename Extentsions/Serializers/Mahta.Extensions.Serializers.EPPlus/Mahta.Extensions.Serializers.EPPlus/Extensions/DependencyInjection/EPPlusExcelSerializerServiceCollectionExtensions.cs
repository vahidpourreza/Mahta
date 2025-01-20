using Mahta.Extensions.Serializers.Abstractions;
using Mahta.Extensions.Serializers.EPPlus.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Mahta.Extensions.DependencyInjection;

public static class EPPlusExcelSerializerServiceCollectionExtensions
{
    public static IServiceCollection AddEPPlusExcelSerializer(this IServiceCollection services) => services.AddSingleton<IExcelSerializer, EPPlusExcelSerializer>();
}