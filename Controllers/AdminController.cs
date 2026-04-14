using CarRentalPortfolio.Data;
using CarRentalPortfolio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    }
}