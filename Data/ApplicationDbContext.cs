using CarRentalPortfolio.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalPortfolio.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<HeroImage> HeroImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed default admin with your credentials
            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    Id = 1,
                    Username = "Bakora",
                    Password = "Bakora@car" // In production, use hashed passwords
                }
            );

            // Seed default hero image
            modelBuilder.Entity<HeroImage>().HasData(
                new HeroImage
                {
                    Id = 1,
                    ImageUrl = "/images/hero-bg.jpg",
                    Title = "Luxury Cars, Exceptional Experience",
                    TitleAr = "سيارات فاخرة بتجربة استثنائية",
                    Subtitle = "Discover our curated collection of premium vehicles",
                    SubtitleAr = "اكتشف مجموعتنا المختارة من السيارات الراقية",
                    IsActive = true,
                    CreatedAt = DateTime.Now
                }
            );

            // Seed sample cars
            modelBuilder.Entity<Car>().HasData(
                new Car
                {
                    Id = 1,
                    Name = "Mercedes-Benz S-Class",
                    NameAr = "مرسيدس بنز إس كلاس",
                    PricePerDay = 3500,
                    Description = "Luxury sedan with executive comfort. Features premium leather interior, advanced driver assistance systems, and a powerful hybrid engine for a smooth, quiet ride.",
                    DescriptionAr = "سيارة سيدان فاخرة مع راحة تنفيذية. تتميز بمقصورة داخلية من الجلد الفاخر، وأنظمة مساعدة متقدمة للسائق، ومحرك هايبرد قوي لقيادة سلسة وهادئة.",
                    ImageUrl = "/images/mercedes-s-class.jpg",
                    IsAvailable = true,
                    Year = 2024,
                    Transmission = "Automatic",
                    TransmissionAr = "أوتوماتيك",
                    FuelType = "Hybrid",
                    FuelTypeAr = "هايبرد",
                    Seats = 5
                },
                new Car
                {
                    Id = 2,
                    Name = "BMW 7 Series",
                    NameAr = "بي إم دبليو الفئة السابعة",
                    PricePerDay = 3200,
                    Description = "Ultimate driving machine with premium features. Combines luxury with sporty performance, featuring cutting-edge technology and unparalleled comfort.",
                    DescriptionAr = "سيارة القيادة المثالية مع ميزات فاخرة. تجمع بين الفخامة والأداء الرياضي، وتتميز بأحدث التقنيات وراحة لا مثيل لها.",
                    ImageUrl = "/images/bmw-7.jpg",
                    IsAvailable = true,
                    Year = 2024,
                    Transmission = "Automatic",
                    TransmissionAr = "أوتوماتيك",
                    FuelType = "Petrol",
                    FuelTypeAr = "بنزين",
                    Seats = 5
                },
                new Car
                {
                    Id = 3,
                    Name = "Range Rover Sport",
                    NameAr = "رينج روفر سبورت",
                    PricePerDay = 4000,
                    Description = "Luxury SUV with off-road capabilities. Perfect for both city driving and adventurous terrain, offering supreme comfort and powerful performance.",
                    DescriptionAr = "سيارة دفع رباعي فاخرة مع قدرات للطرق الوعرة. مثالية للقيادة في المدينة والمغامرات على حد سواء، وتوفر راحة فائقة وأداء قوي.",
                    ImageUrl = "/images/range-rover.jpg",
                    IsAvailable = true,
                    Year = 2024,
                    Transmission = "Automatic",
                    TransmissionAr = "أوتوماتيك",
                    FuelType = "Diesel",
                    FuelTypeAr = "ديزل",
                    Seats = 7
                },
                new Car
                {
                    Id = 4,
                    Name = "Porsche 911",
                    NameAr = "بورش 911",
                    PricePerDay = 4500,
                    Description = "Iconic sports car with exhilarating performance. Experience the thrill of driving with precision handling and breathtaking speed.",
                    DescriptionAr = "سيارة رياضية أيقونية بأداء مثير. اختبر متعة القيادة مع تحكم دقيق وسرعة مذهلة.",
                    ImageUrl = "/images/porsche-911.jpg",
                    IsAvailable = true,
                    Year = 2024,
                    Transmission = "Automatic",
                    TransmissionAr = "أوتوماتيك",
                    FuelType = "Petrol",
                    FuelTypeAr = "بنزين",
                    Seats = 4
                },
                new Car
                {
                    Id = 5,
                    Name = "Lexus LX",
                    NameAr = "لكزس LX",
                    PricePerDay = 3800,
                    Description = "Ultra-luxury SUV with Japanese craftsmanship. Combines off-road capability with exquisite interior detailing and reliable performance.",
                    DescriptionAr = "سيارة دفع رباعي فاخرة مع حرفية يابانية. تجمع بين قدرات الطرق الوعرة والتفاصيل الداخلية الفاخرة والأداء الموثوق.",
                    ImageUrl = "/images/lexus-lx.jpg",
                    IsAvailable = true,
                    Year = 2024,
                    Transmission = "Automatic",
                    TransmissionAr = "أوتوماتيك",
                    FuelType = "Petrol",
                    FuelTypeAr = "بنزين",
                    Seats = 7
                },
                new Car
                {
                    Id = 6,
                    Name = "Audi A8",
                    NameAr = "أودي A8",
                    PricePerDay = 3300,
                    Description = "Sophisticated luxury sedan with cutting-edge technology. Features a quiet cabin, advanced suspension, and intuitive controls for a refined driving experience.",
                    DescriptionAr = "سيارة سيدان فاخرة متطورة بأحدث التقنيات. تتميز بمقصورة هادئة، ونظام تعليق متقدم، وأدوات تحكم بديهية لتجربة قيادة راقية.",
                    ImageUrl = "/images/audi-a8.jpg",
                    IsAvailable = true,
                    Year = 2024,
                    Transmission = "Automatic",
                    TransmissionAr = "أوتوماتيك",
                    FuelType = "Hybrid",
                    FuelTypeAr = "هايبرد",
                    Seats = 5
                }
            );
        }
    }
}