using CarRentalPortfolio.Data;
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

        // ADD THIS METHOD
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var settings = await _context.SiteSettings.FirstOrDefaultAsync();
            return View(settings);
        }
    }
}