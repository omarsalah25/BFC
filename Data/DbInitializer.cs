using CarRentalPortfolio.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalPortfolio.Data
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            // 1. SEED TWO ADMIN ACCOUNTS (Main and Backup)
            if (!await context.Admins.AnyAsync())
            {
                context.Admins.AddRange(
                    new Admin
                    {
                        Username = "admin",
                        Password = "Password@1"
                    },
                    new Admin
                    {
                        Username = "admin_backup",
                        Password = "Backup@123"
                    }
                );
            }

            // 2. SEED SITE SETTINGS (Economic, Egyptian Focus)
            if (!await context.SiteSettings.AnyAsync())
            {
                context.SiteSettings.Add(new SiteSettings
                {
                    SiteName = "H-CAR",
                    SiteNameAr = "إتش-كار",
                    WhatsAppNumber = "201065646972",
                    ContactPhone1 = "01065646972",
                    ContactEmail = "info@h-car.com",
                    Address1En = "Cairo, Egypt",
                    Address1Ar = "القاهرة، مصر",
                    WhatsAppMessageEn = "Hello, I want to inquire about renting an affordable car",
                    WhatsAppMessageAr = "مرحباً، أود الاستفسار عن تأجير سيارة بأسعار اقتصادية",
                    PrimaryColor = "#6f9883",
                    PrimaryDarkColor = "#5a7a69",
                    PrimaryLightColor = "#8fb19e",
                    AccentColor = "#f6bd2c",
                    AccentDarkColor = "#e5a913",
                    BackgroundColor = "#d0d7d1",
                    SurfaceColor = "#ffffff",
                    TextDarkColor = "#1e2b27",
                    TextLightColor = "#5a6b64",
                    FooterTextEn = "Affordable & Reliable Car Rental in Egypt",
                    FooterTextAr = "تأجير سيارات موثوقة واقتصادية في مصر",
                    CarsTitleEn = "Our Economic Fleet",
                    CarsTitleAr = "أسطولنا الاقتصادي",
                    CarsSubtitleEn = "Clean, reliable, and reasonably priced cars for your everyday needs.",
                    CarsSubtitleAr = "سيارات نظيفة، موثوقة، وبأسعار معقولة لتناسب احتياجاتك اليومية.",
                    FeaturesTitleEn = "Why Rent From Us?",
                    FeaturesTitleAr = "لماذا تستأجر من إتش-كار؟",
                    PhilosophyEn = "We are a proudly Egyptian brand committed to providing reliable and highly affordable cars. Whether you need a car for a quick errand, a family trip, or daily commuting, we ensure you get the best reasonable prices without compromising on quality or cleanliness.",
                    PhilosophyAr = "نحن علامة تجارية مصرية نفخر بتقديم سيارات موثوقة بأسعار اقتصادية تناسب الجميع. سواء كنت بحاجة لسيارة لمشوار سريع، رحلة عائلية، أو تنقل يومي، نضمن لك الحصول على أفضل الأسعار المعقولة دون التنازل عن الجودة والنظافة.",
                    ContactTitleEn = "Get in Touch",
                    ContactTitleAr = "تواصل معنا",
                    ContactSubtitleEn = "We are here to assist you with your rental needs.",
                    ContactSubtitleAr = "نحن هنا لمساعدتك في تلبية احتياجاتك لتأجير السيارات بكل سهولة.",
                    UpdatedAt = DateTime.Now
                });
            }

            // 3. SEED HERO IMAGE
            if (!await context.HeroImages.AnyAsync())
            {
                context.HeroImages.Add(new HeroImage
                {
                    ImageUrl = "/images/hero-bg.jpg",
                    Title = "Reliable Cars at Reasonable Prices",
                    TitleAr = "سيارات موثوقة بأسعار معقولة",
                    Subtitle = "Experience practical and affordable car rentals across Egypt.",
                    SubtitleAr = "استمتع بتجربة تأجير سيارات عملية واقتصادية في جميع أنحاء مصر.",
                    IsActive = true,
                    CreatedAt = DateTime.Now
                });
            }

            // 4. SEED ECONOMIC CARS
            if (!await context.Cars.AnyAsync())
            {
                context.Cars.AddRange(
                    new Car
                    {
                        Name = "Nissan Sunny",
                        NameAr = "نيسان صني",
                        PricePerDay = 800,
                        Description = "A highly practical and economic car perfect for city driving and family trips. Excellent fuel efficiency.",
                        DescriptionAr = "سيارة عملية واقتصادية للغاية، مثالية للقيادة داخل المدينة والرحلات العائلية. موفرة جداً في استهلاك الوقود.",
                        ImageUrl = "",
                        IsAvailable = true,
                        Year = 2023,
                        Transmission = "Automatic",
                        TransmissionAr = "أوتوماتيك",
                        FuelType = "Petrol",
                        FuelTypeAr = "بنزين",
                        Seats = 5
                    },
                    new Car
                    {
                        Name = "Hyundai Elantra",
                        NameAr = "هيونداي إلنترا",
                        PricePerDay = 1200,
                        Description = "Comfortable interior with a smooth ride. Great value for those looking for a bit more space at a reasonable rate.",
                        DescriptionAr = "مقصورة مريحة وقيادة سلسة. قيمة ممتازة لمن يبحث عن مساحة أكبر بسعر مناسب ومعقول.",
                        ImageUrl = "",
                        IsAvailable = true,
                        Year = 2023,
                        Transmission = "Automatic",
                        TransmissionAr = "أوتوماتيك",
                        FuelType = "Petrol",
                        FuelTypeAr = "بنزين",
                        Seats = 5
                    },
                    new Car
                    {
                        Name = "Kia Pegas",
                        NameAr = "كيا بيجاس",
                        PricePerDay = 900,
                        Description = "Compact, easy to park, and highly affordable. The best choice for daily commuting in busy streets.",
                        DescriptionAr = "مدمجة، سهلة الركن، واقتصادية جداً. الخيار الأفضل للتنقل اليومي في الشوارع المزدحمة.",
                        ImageUrl = "",
                        IsAvailable = true,
                        Year = 2024,
                        Transmission = "Automatic",
                        TransmissionAr = "أوتوماتيك",
                        FuelType = "Petrol",
                        FuelTypeAr = "بنزين",
                        Seats = 5
                    }
                );
            }

            await context.SaveChangesAsync();
        }
    }
}