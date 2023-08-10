using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Restaurant_MVC.Data
{
    [Table("Customers")]
    public class Customer
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

        public DateTime? CreatedDate { get; set; }

        public Guid? CreatedById { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public Guid? ModifiedById { get; set; }

        public DateTime? DeleteDate { get; set; }

        public Guid? DeleteById { get; set; }

        [InverseProperty("Customer")]
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
