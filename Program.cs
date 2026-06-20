using CarRentalPortfolio.Data;
using CarRentalPortfolio.Middleware;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // 1. Setup Persistent SQLite Path inside AppData folder
        // This ensures your database file is stored safely outside of temporary build folders.
        var appDataPath = Path.Combine(builder.Environment.ContentRootPath, "AppData");
        if (!Directory.Exists(appDataPath))
        {
            Directory.CreateDirectory(appDataPath);
        }
        var dbPath = Path.Combine(appDataPath, "CarRental.db");
        var connectionString = $"Data Source={dbPath}";

        // 2. Add Services
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(connectionString));

        builder.Services.AddDistributedMemoryCache();
        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromHours(24);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });

        var app = builder.Build();

        // 3. DATABASE INITIALIZATION (SAFE VERSION)
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<ApplicationDbContext>();

            try
            {
                // Creates the database ONLY IF it doesn't already exist.
                // It will NEVER delete your saved data.
                await context.Database.EnsureCreatedAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database Creation Error: " + ex.Message);
            }

            try
            {
                // Seeds the default data ONLY IF the tables are 100% empty.
                await DbInitializer.SeedAsync(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Seeding Error: " + ex.Message);
            }
        }

        // 4. Configure pipeline
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseSession();
        app.UseAuthorization();

        // Middleware
        app.UseSiteSettings();

        app.Use(async (context, next) =>
        {
            if (!context.Request.Cookies.ContainsKey("Language"))
            {
                context.Response.Cookies.Append("Language", "en");
            }
            await next();
        });

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        await app.RunAsync();
    }
}