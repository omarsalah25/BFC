using CarRentalPortfolio.Data;
using CarRentalPortfolio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRentalPortfolio.Controllers
{
    public class BaseController : Controller
    {
        protected ApplicationDbContext _context;

        public BaseController(ApplicationDbContext context)
        {
            _context = context;
        }

        protected async Task<SiteSettings> GetSiteSettings()
        {
            var settings = await _context.SiteSettings.FirstOrDefaultAsync();
            if (settings == null)
            {
                settings = new SiteSettings();
                _context.SiteSettings.Add(settings);
                await _context.SaveChangesAsync();
            }
            return settings;
        }

        protected string GetWhatsAppUrl(string message = null)
        {
            var settings = _context.SiteSettings.FirstOrDefault();
            if (settings == null) return "#";

            var phone = settings.WhatsAppNumber;
            var defaultMessage = HttpContext.Request.Cookies["Language"] == "ar"
                ? settings.WhatsAppMessageAr
                : settings.WhatsAppMessageEn;

            var text = Uri.EscapeDataString(message ?? defaultMessage);
            return $"https://wa.me/{phone}?text={text}";
        }
    }
}