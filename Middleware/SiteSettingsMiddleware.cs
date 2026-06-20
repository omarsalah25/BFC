using CarRentalPortfolio.Data;
using Microsoft.EntityFrameworkCore;

namespace CarRentalPortfolio.Middleware
{
    public class SiteSettingsMiddleware
    {
        private readonly RequestDelegate _next;

        public SiteSettingsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ApplicationDbContext dbContext)
        {
            try
            {
                // Check if database is available and fetch settings
                var settings = await dbContext.SiteSettings.AsNoTracking().FirstOrDefaultAsync();
                if (settings != null)
                {
                    context.Items["SiteSettings"] = settings;
                }
            }
            catch
            {
                // If the table doesn't exist yet (during first run/migration), 
                // we just ignore the error so the app can finish starting up.
            }

            await _next(context);
        }
    }

    public static class SiteSettingsMiddlewareExtensions
    {
        public static IApplicationBuilder UseSiteSettings(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SiteSettingsMiddleware>();
        }
    }
}