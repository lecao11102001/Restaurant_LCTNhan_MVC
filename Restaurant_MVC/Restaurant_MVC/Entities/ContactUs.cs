using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Restaurant_MVC.Common;

namespace Restaurant_MVC.Entities
{
    [Table("ContactUs")]
    public class ContactUs : BaseEntities
    {
        [Key]
        public Guid ContactUsId { get; set; }

        public Guid CustomerId { get; set; }

        [MaxLength(255)]
        public string? Name { get; set; }

        [MaxLength(255)]
        public string? Email { get; set; }

        [MaxLength(255)]
        public string? Subject { get; set; }

        [MaxLength(4000)]
        public string? Message { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
    }
}
