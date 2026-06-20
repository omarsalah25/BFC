using CarRentalPortfolio.Data;
using CarRentalPortfolio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRentalPortfolio.ViewComponents
{
    public class SiteSettingsViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public SiteSettingsViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var settings = await _context.SiteSettings.FirstOrDefaultAsync();
                // If settings are null, return a safe empty object
                return View(settings ?? new SiteSettings());
            }
            catch
            {
                // If the database crashes or table is missing, don't break the layout
                return View(new SiteSettings());
            }
        }
    }
}