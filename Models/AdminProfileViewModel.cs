using System.ComponentModel.DataAnnotations;

namespace CarRentalPortfolio.Models
{
    public class AdminProfileViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Display(Name = "New Password")]
        [DataType(DataType.Password)]
        public string? NewPassword { get; set; }
    }
}