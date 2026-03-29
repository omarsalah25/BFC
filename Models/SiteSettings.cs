using System.ComponentModel.DataAnnotations;

namespace CarRentalPortfolio.Models
{
    public class SiteSettings
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Site Name")]
        public string SiteName { get; set; } = "H-CAR";

        [Display(Name = "Site Name (Arabic)")]
        public string SiteNameAr { get; set; } = "إتش-كار";

        [Required]
        [Display(Name = "WhatsApp Number")]
        [Phone]
        public string WhatsAppNumber { get; set; } = "201065646972";

        [Display(Name = "WhatsApp Message (English)")]
        public string WhatsAppMessageEn { get; set; } = "Hello, I'm interested in renting a car";

        [Display(Name = "WhatsApp Message (Arabic)")]
        public string WhatsAppMessageAr { get; set; } = "مرحباً، أود الاستفسار عن تأجير سيارة";

        // Color Settings
        [Required]
        [Display(Name = "Primary Color")]
        public string PrimaryColor { get; set; } = "#6f9883";

        [Required]
        [Display(Name = "Primary Dark Color")]
        public string PrimaryDarkColor { get; set; } = "#5a7a69";

        [Required]
        [Display(Name = "Primary Light Color")]
        public string PrimaryLightColor { get; set; } = "#8fb19e";

        [Required]
        [Display(Name = "Accent Color")]
        public string AccentColor { get; set; } = "#f6bd2c";

        [Required]
        [Display(Name = "Accent Dark Color")]
        public string AccentDarkColor { get; set; } = "#e5a913";

        [Required]
        [Display(Name = "Background Color")]
        public string BackgroundColor { get; set; } = "#d0d7d1";

        [Required]
        [Display(Name = "Surface Color")]
        public string SurfaceColor { get; set; } = "#ffffff";

        [Required]
        [Display(Name = "Text Dark Color")]
        public string TextDarkColor { get; set; } = "#1e2b27";

        [Required]
        [Display(Name = "Text Light Color")]
        public string TextLightColor { get; set; } = "#5a6b64";

        // Logo Settings
        [Display(Name = "Logo URL")]
        public string? LogoUrl { get; set; }

        [Display(Name = "Favicon URL")]
        public string? FaviconUrl { get; set; }

        [Display(Name = "Footer Text (English)")]
        public string? FooterTextEn { get; set; } = "Luxury Car Rental in Egypt";

        [Display(Name = "Footer Text (Arabic)")]
        public string? FooterTextAr { get; set; } = "تأجير سيارات فاخرة في مصر";

        [Display(Name = "Company Philosophy (English)")]
        public string? PhilosophyEn { get; set; } = "Your comfort is our top priority";

        [Display(Name = "Company Philosophy (Arabic)")]
        public string? PhilosophyAr { get; set; } = "راحتك هي أولويتنا القصوى";

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
      
    }
}