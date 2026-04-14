using System.ComponentModel.DataAnnotations;

namespace CarRentalPortfolio.Models
{
    public class ContactMessage
    {
        public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Email { get; set; }
        [Required] public string Phone { get; set; }
        [Required] public string Message { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsRead { get; set; } = false;
    }
}