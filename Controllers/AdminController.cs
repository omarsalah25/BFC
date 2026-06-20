using CarRentalPortfolio.Data;
using CarRentalPortfolio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO.Compression;
using System.Text.Json;


namespace CarRentalPortfolio.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment; 

        public AdminController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult Login()
        {
            return View();

        }
        public async Task<IActionResult> Dashboard()
        {
            if (HttpContext.Session.GetString("AdminId") == null)
                return RedirectToAction("Login");

            // Get stats for dashboard
            ViewBag.TotalCars = await _context.Cars.CountAsync();
            ViewBag.AvailableCars = await _context.Cars.CountAsync(c => c.IsAvailable);
            ViewBag.TotalHeroImages = await _context.HeroImages.CountAsync();
            ViewBag.ActiveHeroImage = await _context.HeroImages.CountAsync(h => h.IsActive);

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var admin = await _context.Admins
                    .FirstOrDefaultAsync(a => a.Username == model.Username && a.Password == model.Password);

                if (admin != null)
                {
                    HttpContext.Session.SetString("AdminId", admin.Id.ToString());
                    return RedirectToAction("Dashboard");
                }

                ModelState.AddModelError("", "Invalid username or password");
            }

            return View(model);
        }

       
        public async Task<IActionResult> Cars()
        {
            if (HttpContext.Session.GetString("AdminId") == null)
                return RedirectToAction("Login");

            var cars = await _context.Cars.ToListAsync();
            return View(cars);
        }

        public IActionResult AddCar()
        {
            if (HttpContext.Session.GetString("AdminId") == null)
                return RedirectToAction("Login");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCar(Car car, IFormFile? imageFile)
        {
            if (HttpContext.Session.GetString("AdminId") == null)
                return RedirectToAction("Login");

            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                    var filePath = Path.Combine(_environment.WebRootPath, "images", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    car.ImageUrl = "/images/" + fileName;
                }

                _context.Cars.Add(car);
                await _context.SaveChangesAsync();

                return RedirectToAction("Cars");
            }

            return View(car);
        }

        public async Task<IActionResult> EditCar(int id)
        {
            if (HttpContext.Session.GetString("AdminId") == null)
                return RedirectToAction("Login");

            var car = await _context.Cars.FindAsync(id);
            if (car == null)
                return NotFound();

            return View(car);
        }

        [HttpPost]
        public async Task<IActionResult> EditCar(Car car, IFormFile? imageFile)
        {
            if (HttpContext.Session.GetString("AdminId") == null)
                return RedirectToAction("Login");

            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                    var filePath = Path.Combine(_environment.WebRootPath, "images", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    car.ImageUrl = "/images/" + fileName;
                }

                _context.Update(car);
                await _context.SaveChangesAsync();

                return RedirectToAction("Cars");
            }

            return View(car);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCar(int id)
        {
            if (HttpContext.Session.GetString("AdminId") == null)
                return Json(new { success = false, message = "Unauthorized" });

            var car = await _context.Cars.FindAsync(id);
            if (car != null)
            {
                _context.Cars.Remove(car);
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }

            return Json(new { success = false, message = "Car not found" });
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Clears everything securely
            return RedirectToAction("Login");
        }
        public async Task<IActionResult> HeroImages()
        {
            if (HttpContext.Session.GetString("AdminId") == null)
                return RedirectToAction("Login");

            var heroImages = await _context.HeroImages.ToListAsync();
            return View(heroImages);
        }

        public IActionResult AddHeroImage()
        {
            if (HttpContext.Session.GetString("AdminId") == null)
                return RedirectToAction("Login");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddHeroImage(HeroImage heroImage, IFormFile? imageFile)
        {
            if (HttpContext.Session.GetString("AdminId") == null)
                return RedirectToAction("Login");

            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                    var filePath = Path.Combine(_environment.WebRootPath, "images", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    heroImage.ImageUrl = "/images/" + fileName;
                }

                _context.HeroImages.Add(heroImage);
                await _context.SaveChangesAsync();

                return RedirectToAction("HeroImages");
            }

            return View(heroImage);
        }

        public async Task<IActionResult> EditHeroImage(int id)
        {
            if (HttpContext.Session.GetString("AdminId") == null)
                return RedirectToAction("Login");

            var heroImage = await _context.HeroImages.FindAsync(id);
            if (heroImage == null)
                return NotFound();

            return View(heroImage);
        }

        [HttpPost]
        public async Task<IActionResult> EditHeroImage(HeroImage heroImage, IFormFile? imageFile)
        {
            if (HttpContext.Session.GetString("AdminId") == null)
                return RedirectToAction("Login");

            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                    var filePath = Path.Combine(_environment.WebRootPath, "images", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    heroImage.ImageUrl = "/images/" + fileName;
                }

                _context.Update(heroImage);
                await _context.SaveChangesAsync();

                return RedirectToAction("HeroImages");
            }

            return View(heroImage);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteHeroImage(int id)
        {
            if (HttpContext.Session.GetString("AdminId") == null)
                return Json(new { success = false, message = "Unauthorized" });

            var heroImage = await _context.HeroImages.FindAsync(id);
            if (heroImage != null)
            {
                _context.HeroImages.Remove(heroImage);
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }

            return Json(new { success = false, message = "Image not found" });
        }
        public async Task<IActionResult> Profile()
        {
            var adminId = HttpContext.Session.GetString("AdminId");
            if (adminId == null) return RedirectToAction("Login");

            var admin = await _context.Admins.FindAsync(int.Parse(adminId));
            return View(new AdminProfileViewModel { Username = admin.Username });
        }

        [HttpPost]
        public async Task<IActionResult> Profile(AdminProfileViewModel model)
        {
            var adminId = HttpContext.Session.GetString("AdminId");
            if (adminId == null) return RedirectToAction("Login");

            if (ModelState.IsValid)
            {
                var admin = await _context.Admins.FindAsync(int.Parse(adminId));
                admin.Username = model.Username;

                // Only update password if a new one is typed
                if (!string.IsNullOrWhiteSpace(model.NewPassword))
                {
                    admin.Password = model.NewPassword;
                }

                await _context.SaveChangesAsync();
                TempData["Success"] = "Profile updated successfully!";
                return RedirectToAction("Dashboard");
            }
            return View(model);
        }
        public async Task<IActionResult> Messages()
        {
            if (HttpContext.Session.GetString("AdminId") == null) return RedirectToAction("Login");

            var messages = await _context.ContactMessages.OrderByDescending(m => m.CreatedAt).ToListAsync();

            // Mark all as read when visited
            foreach (var msg in messages.Where(m => !m.IsRead)) { msg.IsRead = true; }
            await _context.SaveChangesAsync();

            return View(messages);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            if (HttpContext.Session.GetString("AdminId") == null) return Json(new { success = false });

            var msg = await _context.ContactMessages.FindAsync(id);
            if (msg != null)
            {
                _context.ContactMessages.Remove(msg);
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
        [HttpPost]
        public async Task<IActionResult> RestoreBackup(IFormFile backupFile)
        {
            if (HttpContext.Session.GetString("AdminId") == null)
                return Json(new { success = false, message = "Unauthorized" });

            if (backupFile == null || backupFile.Length == 0)
                return Json(new { success = false, message = "No file uploaded." });

            try
            {
                // 1. Open the uploaded ZIP file
                using var stream = backupFile.OpenReadStream();
                using var archive = new ZipArchive(stream, ZipArchiveMode.Read);

                // 2. Find and read the JSON database backup
                var jsonEntry = archive.GetEntry("database_backup.json");
                if (jsonEntry == null)
                    return Json(new { success = false, message = "Invalid backup file: database_backup.json not found inside ZIP." });

                using var jsonStream = jsonEntry.Open();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var backupData = await JsonSerializer.DeserializeAsync<BackupData>(jsonStream, options);

                if (backupData == null)
                    return Json(new { success = false, message = "Failed to parse backup data." });

                // 3. SAFE DATABASE WIPE (Delete all current rows)
                _context.ContactMessages.RemoveRange(_context.ContactMessages);
                _context.Cars.RemoveRange(_context.Cars);
                _context.HeroImages.RemoveRange(_context.HeroImages);
                _context.SiteSettings.RemoveRange(_context.SiteSettings);
                _context.Admins.RemoveRange(_context.Admins);
                await _context.SaveChangesAsync();

                // 4. RESTORE DATA FROM JSON
                if (backupData.Admins != null) _context.Admins.AddRange(backupData.Admins);
                if (backupData.SiteSettings != null) _context.SiteSettings.AddRange(backupData.SiteSettings);
                if (backupData.HeroImages != null) _context.HeroImages.AddRange(backupData.HeroImages);
                if (backupData.Cars != null) _context.Cars.AddRange(backupData.Cars);
                if (backupData.ContactMessages != null) _context.ContactMessages.AddRange(backupData.ContactMessages);

                await _context.SaveChangesAsync();

                // 5. RESTORE IMAGES
                var imagesPath = Path.Combine(_environment.WebRootPath, "images");
                if (!Directory.Exists(imagesPath)) Directory.CreateDirectory(imagesPath);

                foreach (var entry in archive.Entries)
                {
                    // If it's an image file inside the images/ folder of the zip
                    if (entry.FullName.StartsWith("images/") && !string.IsNullOrEmpty(entry.Name))
                    {
                        var extractPath = Path.Combine(imagesPath, entry.Name);
                        entry.ExtractToFile(extractPath, overwrite: true);
                    }
                }

                // 6. Force user to log in again (since Admin IDs might have changed)
                HttpContext.Session.Clear();

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error during restore: " + ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult> SetActiveHeroImage(int id)
        {
            if (HttpContext.Session.GetString("AdminId") == null)
                return Json(new { success = false, message = "Unauthorized" });

            // Deactivate all hero images
            var allHeroes = await _context.HeroImages.ToListAsync();
            foreach (var hero in allHeroes)
            {
                hero.IsActive = false;
            }

            // Activate the selected one
            var selectedHero = await _context.HeroImages.FindAsync(id);
            if (selectedHero != null)
            {
                selectedHero.IsActive = true;
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }

            return Json(new { success = false, message = "Image not found" });
        }


        [HttpGet]
        public async Task<IActionResult> ExportBackup()
        {
            if (HttpContext.Session.GetString("AdminId") == null)
                return RedirectToAction("Login");

            // 1. Gather all database data
            var exportData = new
            {
                Admins = await _context.Admins.ToListAsync(),
                SiteSettings = await _context.SiteSettings.ToListAsync(),
                HeroImages = await _context.HeroImages.ToListAsync(),
                Cars = await _context.Cars.ToListAsync(),
                ContactMessages = await _context.ContactMessages.ToListAsync()
            };

            // Serialize to formatted JSON
            var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(exportData, jsonOptions);

            // 2. Prepare the ZIP file in memory
            using var memoryStream = new MemoryStream();
            using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
            {
                // Add JSON file to ZIP
                var jsonEntry = archive.CreateEntry("database_backup.json");
                using (var entryStream = jsonEntry.Open())
                using (var streamWriter = new StreamWriter(entryStream))
                {
                    await streamWriter.WriteAsync(jsonString);
                }

                // Add Images to ZIP
                var imagesPath = Path.Combine(_environment.WebRootPath, "images");
                if (Directory.Exists(imagesPath))
                {
                    var imageFiles = Directory.GetFiles(imagesPath);
                    foreach (var filePath in imageFiles)
                    {
                        var fileName = Path.GetFileName(filePath);
                        archive.CreateEntryFromFile(filePath, $"images/{fileName}");
                    }
                }
            }

            // 3. Return the ZIP file for download
            memoryStream.Position = 0;
            var fileNameExport = $"HCar_Backup_{DateTime.Now:yyyyMMdd_HHmmss}.zip";
            return File(memoryStream.ToArray(), "application/zip", fileNameExport);
        }
    }
}