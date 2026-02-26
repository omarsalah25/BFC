using System.ComponentModel.DataAnnotations;

namespace CarRentalPortfolio.Models
{
    public class HeroImage
    {
        public int Id { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public string? Title { get; set; }

        public string? TitleAr { get; set; }

        public string? Subtitle { get; set; }

        public string? SubtitleAr { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}