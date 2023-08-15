using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Restaurant_MVC.Entities
{
    [Table("Customers")]
    public class Customer : BaseEntities
    {
        [Key]
        public Guid CustomerId { get; set; }

        [MaxLength(255)]
        public string? Name { get; set; }

        public bool? Gender { get; set; }

        [MaxLength(255)]
        public string? Address { get; set; }

        [MaxLength(10)]
        public string? Phone { get; set; }

        [MaxLength(255)]
        public string? Email { get; set; }

        [MaxLength(255)]
        public string? UserName { get; set; }

        [MaxLength(100)]
        public string? PassWord { get; set; }

        public string? Role { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [InverseProperty("Customer")]
        public virtual ICollection<Reservation> Reservations { get; set; }

        [InverseProperty("Customer")]
        public virtual ICollection<ContactUs> ContactUss { get; set; }
    }
}
