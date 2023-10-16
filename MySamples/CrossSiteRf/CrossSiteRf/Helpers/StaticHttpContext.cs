using Microsoft.AspNetCore.Http;
namespace CrossSiteRf.Helpers;
public static class StaticHttpContext
{
    private static IHttpContextAccessor _httpContextAccessor;

    public static void Configure(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public static HttpContext Current => _httpContextAccessor.HttpContext;
}