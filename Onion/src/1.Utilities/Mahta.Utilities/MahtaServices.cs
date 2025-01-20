using Mahta.Extensions.Caching.Abstractions;
using Mahta.Extensions.ObjectMappers.Abstractions;
using Mahta.Extensions.Serializers.Abstractions;
using Mahta.Extensions.Translations.Abstractions;
using Mahta.Extensions.UsersManagement.Abstractions;
using Microsoft.Extensions.Logging;

namespace Mahta.Utilities;

public class MahtaServices
{
    public readonly ITranslator Translator;
    public readonly ICacheAdapter CacheAdapter;
    public readonly IMapperAdapter MapperFacade;
    public readonly ILoggerFactory LoggerFactory;
    public readonly IJsonSerializer Serializer;
    public readonly IUserInfoService UserInfoService;

    public MahtaServices(ITranslator translator,
            ILoggerFactory loggerFactory,
            IJsonSerializer serializer,
            IUserInfoService userInfoService,
            ICacheAdapter cacheAdapter,
            IMapperAdapter mapperFacade)
    {
        Translator = translator;
        LoggerFactory = loggerFactory;
        Serializer = serializer;
        UserInfoService = userInfoService;
        CacheAdapter = cacheAdapter;
        MapperFacade = mapperFacade;
    }
}