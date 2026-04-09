using System.Globalization;

namespace CoolJob.Middleware
{
    public class CultureMiddleware
    {
        private readonly RequestDelegate _next;

        public CultureMiddleware(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            var culture = context.Request.Cookies["Culture"] ?? "ru";
            var cultureInfo = new CultureInfo(culture);
            
            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;
            
            await _next(context);
        }
    }
}