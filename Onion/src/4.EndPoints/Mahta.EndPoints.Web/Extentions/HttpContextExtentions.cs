using Mahta.Core.Contracts.ApplicationServices.Events;
using Mahta.Utilities;
using Microsoft.AspNetCore.Http;

namespace Mahta.EndPoints.Web.Extentions;

public static class HttpContextExtensions
{
    public static ICommandDispatcher CommandDispatcher(this HttpContext httpContext) =>
        (ICommandDispatcher)httpContext.RequestServices.GetService(typeof(ICommandDispatcher));

    public static IQueryDispatcher QueryDispatcher(this HttpContext httpContext) =>
        (IQueryDispatcher)httpContext.RequestServices.GetService(typeof(IQueryDispatcher));

    public static IEventDispatcher EventDispatcher(this HttpContext httpContext) =>
        (IEventDispatcher)httpContext.RequestServices.GetService(typeof(IEventDispatcher));

    public static MahtaServices ZaminApplicationContext(this HttpContext httpContext) =>
        (MahtaServices)httpContext.RequestServices.GetService(typeof(MahtaServices));
}