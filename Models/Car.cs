using System.ComponentModel.DataAnnotations;

namespace CarRentalPortfolio.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Car Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "اسم السيارة")]
        public string NameAr { get; set; }

        [Required]
        [Display(Name = "Price Per Day (EGP)")]
        [Range(0, double.MaxValue)]
        public decimal PricePerDay { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "الوصف")]
        public string DescriptionAr { get; set; }

        [Display(Name = "Image URL")]
        public string? ImageUrl { get; set; }

        [Display(Name = "Available")]
        public bool IsAvailable { get; set; } = true;

        [Display(Name = "Year")]
        [Range(2000, 2025)]
        public int Year { get; set; }

        [Display(Name = "Transmission")]
        public string Transmission { get; set; }

        [Display(Name = "ناقل الحركة")]
        public string TransmissionAr { get; set; }

        [Display(Name = "Fuel Type")]
        public string FuelType { get; set; }

        [Display(Name = "نوع الوقود")]
        public string FuelTypeAr { get; set; }

        [Display(Name = "Seats")]
        [Range(2, 9)]
        public int Seats { get; set; }
    }
}