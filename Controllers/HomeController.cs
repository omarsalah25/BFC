    using CarRentalPortfolio.Data;
    using CarRentalPortfolio.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    namespace CarRentalPortfolio.Controllers
    {
        public class HomeController : BaseController
        {
            public HomeController(ApplicationDbContext context) : base(context)
            {
            }

            public async Task<IActionResult> Index()
            {
                var cars = await _context.Cars.Where(c => c.IsAvailable).ToListAsync();
                var heroImage = await _context.HeroImages.FirstOrDefaultAsync(h => h.IsActive);
                ViewBag.HeroImage = heroImage;
                ViewBag.Settings = await GetSiteSettings();
                return View(cars);
            }

            public IActionResult About()
            {
                return View();
            }

            public IActionResult ChangeLanguage(string lang)
            {
                if (lang == "ar" || lang == "en")
                {
                    Response.Cookies.Append("Language", lang, new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddYears(1)
                    });
                }

                return Redirect(Request.Headers["Referer"].ToString());
            }
        }
    }