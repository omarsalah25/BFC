using CarRentalPortfolio.Data;
using CarRentalPortfolio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRentalPortfolio.Controllers
{
    public class SiteSettingsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public SiteSettingsController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: SiteSettings
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("AdminId") == null)
                return RedirectToAction("Login", "Admin");

            var settings = await _context.SiteSettings.FirstOrDefaultAsync();
            if (settings == null)
            {
                settings = new SiteSettings();
                _context.SiteSettings.Add(settings);
                await _context.SaveChangesAsync();
            }
            return View(settings);
        }

        // GET: SiteSettings/Edit
        public async Task<IActionResult> Edit()
        {
            if (HttpContext.Session.GetString("AdminId") == null)
                return RedirectToAction("Login", "Admin");

            var settings = await _context.SiteSettings.FirstOrDefaultAsync();
            if (settings == null)
            {
                settings = new SiteSettings();
                _context.SiteSettings.Add(settings);
                await _context.SaveChangesAsync();
            }
            return View(settings);
        }

        // POST: SiteSettings/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SiteSettings settings, IFormFile? logoFile, IFormFile? faviconFile)
        {
            if (HttpContext.Session.GetString("AdminId") == null)
                return RedirectToAction("Login", "Admin");

            if (ModelState.IsValid)
            {
                try
                {
                    var existingSettings = await _context.SiteSettings.FindAsync(settings.Id);
                    if (existingSettings == null)
                    {
                        return NotFound();
                    }

                    // Handle logo upload
                    if (logoFile != null && logoFile.Length > 0)
                    {
                        var logoFileName = Guid.NewGuid().ToString() + Path.GetExtension(logoFile.FileName);
                        var logoFilePath = Path.Combine(_environment.WebRootPath, "images", logoFileName);

                        using (var stream = new FileStream(logoFilePath, FileMode.Create))
                        {
                            await logoFile.CopyToAsync(stream);
                        }

                        settings.LogoUrl = "/images/" + logoFileName;
                    }
                    else
                    {
                        settings.LogoUrl = existingSettings.LogoUrl;
                    }

                    // Handle favicon upload
                    if (faviconFile != null && faviconFile.Length > 0)
                    {
                        var faviconFileName = Guid.NewGuid().ToString() + Path.GetExtension(faviconFile.FileName);
                        var faviconFilePath = Path.Combine(_environment.WebRootPath, "images", faviconFileName);

                        using (var stream = new FileStream(faviconFilePath, FileMode.Create))
                        {
                            await faviconFile.CopyToAsync(stream);
                        }

                        settings.FaviconUrl = "/images/" + faviconFileName;
                    }
                    else
                    {
                        settings.FaviconUrl = existingSettings.FaviconUrl;
                    }

                    settings.UpdatedAt = DateTime.Now;

                    _context.Entry(existingSettings).CurrentValues.SetValues(settings);
                    await _context.SaveChangesAsync();

                    TempData["Success"] = "Settings updated successfully!";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SettingsExists(settings.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(settings);
        }

        private bool SettingsExists(int id)
        {
            return _context.SiteSettings.Any(e => e.Id == id);
        }
    }
}