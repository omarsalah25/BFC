using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BFC.Migrations
{
    /// <inheritdoc />
    public partial class AddSiteSettingsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    NameAr = table.Column<string>(type: "TEXT", nullable: false),
                    PricePerDay = table.Column<decimal>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    DescriptionAr = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    IsAvailable = table.Column<bool>(type: "INTEGER", nullable: false),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    Transmission = table.Column<string>(type: "TEXT", nullable: false),
                    TransmissionAr = table.Column<string>(type: "TEXT", nullable: false),
                    FuelType = table.Column<string>(type: "TEXT", nullable: false),
                    FuelTypeAr = table.Column<string>(type: "TEXT", nullable: false),
                    Seats = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HeroImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    TitleAr = table.Column<string>(type: "TEXT", nullable: true),
                    Subtitle = table.Column<string>(type: "TEXT", nullable: true),
                    SubtitleAr = table.Column<string>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiteSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SiteName = table.Column<string>(type: "TEXT", nullable: false),
                    SiteNameAr = table.Column<string>(type: "TEXT", nullable: false),
                    WhatsAppNumber = table.Column<string>(type: "TEXT", nullable: false),
                    WhatsAppMessageEn = table.Column<string>(type: "TEXT", nullable: false),
                    WhatsAppMessageAr = table.Column<string>(type: "TEXT", nullable: false),
                    PrimaryColor = table.Column<string>(type: "TEXT", nullable: false),
                    PrimaryDarkColor = table.Column<string>(type: "TEXT", nullable: false),
                    PrimaryLightColor = table.Column<string>(type: "TEXT", nullable: false),
                    AccentColor = table.Column<string>(type: "TEXT", nullable: false),
                    AccentDarkColor = table.Column<string>(type: "TEXT", nullable: false),
                    BackgroundColor = table.Column<string>(type: "TEXT", nullable: false),
                    SurfaceColor = table.Column<string>(type: "TEXT", nullable: false),
                    TextDarkColor = table.Column<string>(type: "TEXT", nullable: false),
                    TextLightColor = table.Column<string>(type: "TEXT", nullable: false),
                    LogoUrl = table.Column<string>(type: "TEXT", nullable: true),
                    FaviconUrl = table.Column<string>(type: "TEXT", nullable: true),
                    FooterTextEn = table.Column<string>(type: "TEXT", nullable: true),
                    FooterTextAr = table.Column<string>(type: "TEXT", nullable: true),
                    PhilosophyEn = table.Column<string>(type: "TEXT", nullable: true),
                    PhilosophyAr = table.Column<string>(type: "TEXT", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteSettings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[] { 1, "Bakora@car", "Bakora" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Description", "DescriptionAr", "FuelType", "FuelTypeAr", "ImageUrl", "IsAvailable", "Name", "NameAr", "PricePerDay", "Seats", "Transmission", "TransmissionAr", "Year" },
                values: new object[,]
                {
                    { 1, "Luxury sedan with executive comfort. Features premium leather interior, advanced driver assistance systems, and a powerful hybrid engine for a smooth, quiet ride.", "سيارة سيدان فاخرة مع راحة تنفيذية. تتميز بمقصورة داخلية من الجلد الفاخر، وأنظمة مساعدة متقدمة للسائق، ومحرك هايبرد قوي لقيادة سلسة وهادئة.", "Hybrid", "هايبرد", "/images/mercedes-s-class.jpg", true, "Mercedes-Benz S-Class", "مرسيدس بنز إس كلاس", 3500m, 5, "Automatic", "أوتوماتيك", 2024 },
                    { 2, "Ultimate driving machine with premium features. Combines luxury with sporty performance, featuring cutting-edge technology and unparalleled comfort.", "سيارة القيادة المثالية مع ميزات فاخرة. تجمع بين الفخامة والأداء الرياضي، وتتميز بأحدث التقنيات وراحة لا مثيل لها.", "Petrol", "بنزين", "/images/bmw-7.jpg", true, "BMW 7 Series", "بي إم دبليو الفئة السابعة", 3200m, 5, "Automatic", "أوتوماتيك", 2024 },
                    { 3, "Luxury SUV with off-road capabilities. Perfect for both city driving and adventurous terrain, offering supreme comfort and powerful performance.", "سيارة دفع رباعي فاخرة مع قدرات للطرق الوعرة. مثالية للقيادة في المدينة والمغامرات على حد سواء، وتوفر راحة فائقة وأداء قوي.", "Diesel", "ديزل", "/images/range-rover.jpg", true, "Range Rover Sport", "رينج روفر سبورت", 4000m, 7, "Automatic", "أوتوماتيك", 2024 },
                    { 4, "Iconic sports car with exhilarating performance. Experience the thrill of driving with precision handling and breathtaking speed.", "سيارة رياضية أيقونية بأداء مثير. اختبر متعة القيادة مع تحكم دقيق وسرعة مذهلة.", "Petrol", "بنزين", "/images/porsche-911.jpg", true, "Porsche 911", "بورش 911", 4500m, 4, "Automatic", "أوتوماتيك", 2024 },
                    { 5, "Ultra-luxury SUV with Japanese craftsmanship. Combines off-road capability with exquisite interior detailing and reliable performance.", "سيارة دفع رباعي فاخرة مع حرفية يابانية. تجمع بين قدرات الطرق الوعرة والتفاصيل الداخلية الفاخرة والأداء الموثوق.", "Petrol", "بنزين", "/images/lexus-lx.jpg", true, "Lexus LX", "لكزس LX", 3800m, 7, "Automatic", "أوتوماتيك", 2024 },
                    { 6, "Sophisticated luxury sedan with cutting-edge technology. Features a quiet cabin, advanced suspension, and intuitive controls for a refined driving experience.", "سيارة سيدان فاخرة متطورة بأحدث التقنيات. تتميز بمقصورة هادئة، ونظام تعليق متقدم، وأدوات تحكم بديهية لتجربة قيادة راقية.", "Hybrid", "هايبرد", "/images/audi-a8.jpg", true, "Audi A8", "أودي A8", 3300m, 5, "Automatic", "أوتوماتيك", 2024 }
                });

            migrationBuilder.InsertData(
                table: "HeroImages",
                columns: new[] { "Id", "CreatedAt", "ImageUrl", "IsActive", "Subtitle", "SubtitleAr", "Title", "TitleAr" },
                values: new object[] { 1, new DateTime(2026, 3, 10, 23, 54, 51, 474, DateTimeKind.Local).AddTicks(7365), "/images/hero-bg.jpg", true, "Discover our curated collection of premium vehicles", "اكتشف مجموعتنا المختارة من السيارات الراقية", "Luxury Cars, Exceptional Experience", "سيارات فاخرة بتجربة استثنائية" });

            migrationBuilder.InsertData(
                table: "SiteSettings",
                columns: new[] { "Id", "AccentColor", "AccentDarkColor", "BackgroundColor", "FaviconUrl", "FooterTextAr", "FooterTextEn", "LogoUrl", "PhilosophyAr", "PhilosophyEn", "PrimaryColor", "PrimaryDarkColor", "PrimaryLightColor", "SiteName", "SiteNameAr", "SurfaceColor", "TextDarkColor", "TextLightColor", "UpdatedAt", "WhatsAppMessageAr", "WhatsAppMessageEn", "WhatsAppNumber" },
                values: new object[] { 1, "#f6bd2c", "#e5a913", "#d0d7d1", "/images/icon.png", "تأجير سيارات فاخرة في مصر", "Luxury Car Rental in Egypt", "/images/icon.png", "راحتك هي أولويتنا القصوى", "Your comfort is our top priority", "#6f9883", "#5a7a69", "#8fb19e", "H-CAR", "إتش-كار", "#ffffff", "#1e2b27", "#5a6b64", new DateTime(2026, 3, 10, 23, 54, 51, 474, DateTimeKind.Local).AddTicks(4394), "مرحباً، أود الاستفسار عن تأجير سيارة", "Hello, I'm interested in renting a car", "201065646972" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "HeroImages");

            migrationBuilder.DropTable(
                name: "SiteSettings");
        }
    }
}
