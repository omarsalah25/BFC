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

        // --- NEW CONTACT FIELDS ---
        [Display(Name = "Contact Email")]
        public string? ContactEmail { get; set; } = "info@h-car.com";

        [Display(Name = "Primary Phone")]
        public string? ContactPhone1 { get; set; }

        [Display(Name = "Secondary Phone")]
        public string? ContactPhone2 { get; set; }

        [Display(Name = "Main Branch Address (English)")]
        public string? Address1En { get; set; }

        [Display(Name = "Main Branch Address (Arabic)")]
        public string? Address1Ar { get; set; }

        [Display(Name = "Second Branch Address (English)")]
        public string? Address2En { get; set; }

        [Display(Name = "Second Branch Address (Arabic)")]
        public string? Address2Ar { get; set; }
        // --------------------------

        [Required]
        [Display(Name = "WhatsApp Number")]
        [Phone]
        public string WhatsAppNumber { get; set; } = "201065646972";

        [Display(Name = "WhatsApp Message (English)")]
        public string WhatsAppMessageEn { get; set; } = "Hello, I'm interested in renting a car";

        [Display(Name = "WhatsApp Message (Arabic)")]
        public string WhatsAppMessageAr { get; set; } = "مرحباً، أود الاستفسار عن تأجير سيارة";

        // Color Settings
        [Required] public string PrimaryColor { get; set; } = "#6f9883";
        [Required] public string PrimaryDarkColor { get; set; } = "#5a7a69";
        [Required] public string PrimaryLightColor { get; set; } = "#8fb19e";
        [Required] public string AccentColor { get; set; } = "#f6bd2c";
        [Required] public string AccentDarkColor { get; set; } = "#e5a913";
        [Required] public string BackgroundColor { get; set; } = "#d0d7d1";
        [Required] public string SurfaceColor { get; set; } = "#ffffff";
        [Required] public string TextDarkColor { get; set; } = "#1e2b27";
        [Required] public string TextLightColor { get; set; } = "#5a6b64";

        // Logo Settings
        [Display(Name = "Logo URL")] public string? LogoUrl { get; set; }
        [Display(Name = "Favicon URL")] public string? FaviconUrl { get; set; }

        [Display(Name = "Footer Text (English)")]
        public string? FooterTextEn { get; set; } = "Premium Car Rental in Egypt";

        [Display(Name = "Footer Text (Arabic)")]
        public string? FooterTextAr { get; set; } = "تأجير سيارات في مصر";

        [Display(Name = "Company Philosophy (English)")]
        public string? PhilosophyEn { get; set; } = "Your comfort is our top priority";

        [Display(Name = "Company Philosophy (Arabic)")]
        public string? PhilosophyAr { get; set; } = "راحتك هي أولويتنا القصوى";

        [Display(Name = "Features Title (English)")]
        public string FeaturesTitleEn { get; set; } = "Our Advantages";

        [Display(Name = "Features Title (Arabic)")]
        public string FeaturesTitleAr { get; set; } = "مميزاتنا";

        [Display(Name = "Cars Section Title (English)")]
        public string CarsTitleEn { get; set; } = "Our Fleet";

        [Display(Name = "Cars Section Title (Arabic)")]
        public string CarsTitleAr { get; set; } = "سياراتنا";

        [Display(Name = "Philosophy Image URL")]
        public string? PhilosophyImageUrl { get; set; }

        // --- SOCIAL MEDIA ---
        [Display(Name = "Facebook URL")] public string? FacebookUrl { get; set; }
        [Display(Name = "Twitter/X URL")] public string? TwitterUrl { get; set; }
        [Display(Name = "Instagram URL")] public string? InstagramUrl { get; set; }

        [Display(Name = "Cars Section Subtitle (English)")]
        public string CarsSubtitleEn { get; set; } = "Choose your perfect car and enjoy an unforgettable driving experience";

        [Display(Name = "Cars Section Subtitle (Arabic)")]
        public string CarsSubtitleAr { get; set; } = "اختر سيارتك المثالية واستمتع بتجربة قيادة لا تُنسى";

        [Display(Name = "Testimonials Title (English)")]
        public string TestimonialsTitleEn { get; set; } = "What Our Clients Say";

        [Display(Name = "Testimonials Title (Arabic)")]
        public string TestimonialsTitleAr { get; set; } = "ماذا يقول عملاؤنا";

        [Display(Name = "Contact Title (English)")]
        public string ContactTitleEn { get; set; } = "Contact Us";

        [Display(Name = "Contact Title (Arabic)")]
        public string ContactTitleAr { get; set; } = "تواصل معنا";

        [Display(Name = "Contact Subtitle (English)")]
        public string ContactSubtitleEn { get; set; } = "We're here to help you 24/7";

        [Display(Name = "Contact Subtitle (Arabic)")]
        public string ContactSubtitleAr { get; set; } = "نحن هنا لمساعدتك طوال أيام الأسبوع";

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}