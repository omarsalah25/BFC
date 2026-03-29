using CarRentalPortfolio.Data;
using CarRentalPortfolio.Models;
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
            // ADD THIS TO FETCH SETTINGS AND PASS TO LAYOUT
            var settings = await dbContext.SiteSettings.FirstOrDefaultAsync();
            if (settings != null)
            {
                context.Items["SiteSettings"] = settings;
            }

            await _next(context);
        }
    }
    // Extension method to register the middleware
    public static class SiteSettingsMiddlewareExtensions
    {
        public static IApplicationBuilder UseSiteSettings(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SiteSettingsMiddleware>();
        }
    }
}