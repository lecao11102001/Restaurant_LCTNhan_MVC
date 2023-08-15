using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Restaurant_MVC.Entities
{
    [Table("Reservation")]
    public class Reservation : BaseEntities
    {
        [Key]
        public Guid ReservationsId { get; set; }

        public Guid CustomerId { get; set; }

        [MaxLength(225)]
        public string? Name { get; set; }

        [MaxLength(225)]
        public string? Email { get; set; }

        [MaxLength(10)]
        public string? Phone { get; set; }

        public DateTime? Date { get; set; }

        public DateTime? Time { get; set; }

        public int? NumberOfGuests { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
    }
}
