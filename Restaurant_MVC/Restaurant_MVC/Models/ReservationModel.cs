using System.ComponentModel.DataAnnotations;

namespace Restaurant_MVC.Models
{
    public class ReservationModel
    {
        public Guid CustomerId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required]
        public int NumberOfGuests { get; set; }
    }
}
