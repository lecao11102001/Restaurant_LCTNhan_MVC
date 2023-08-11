using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace Restaurant_MVC.Models.Entities
{
    [Table("Restaurants")]
    public class Restaurants : BaseEntities
    {
        [Key]
        public Guid RestaurantsId { get; set; }

        [MaxLength(255)]
        public string? Name { get; set; }

        [MaxLength(500)]
        public string? Address { get; set; }

        [MaxLength(10)]
        public string? Phone { get; set; }

        [MaxLength(255)]
        public string? Email { get; set; }

        [MaxLength(4000)]
        public string? Website { get; set; }
    }
}
