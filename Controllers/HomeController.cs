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
            ViewBag.Settings = new SiteSettings();
            ViewBag.HeroImage = new HeroImage();
            var cars = new List<Car>();

            try
            {
                // CHANGED: We removed the .Where() so ALL cars are fetched
                cars = await _context.Cars.ToListAsync();

                var heroImage = await _context.HeroImages.FirstOrDefaultAsync(h => h.IsActive);
                if (heroImage != null)
                {
                    ViewBag.HeroImage = heroImage;
                }

                ViewBag.Settings = await GetSiteSettings();
            }
            catch
            {
            }

            return View(cars);
        }


        public IActionResult About()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubmitContactMessage(ContactMessage model) // REMOVED [FromBody]
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.ContactMessages.Add(model);
                    await _context.SaveChangesAsync();
                    return Json(new { success = true });
                }
            }
            catch
            {
                // Ignore DB errors
            }
            return Json(new { success = false });
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

            return Redirect(Request.Headers["Referer"].ToString() ?? "/");
        }
    }
}