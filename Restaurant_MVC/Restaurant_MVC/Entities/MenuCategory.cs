using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant_MVC.Entities
{
    [Table("MenuCategory")]
    public class MenuCategory : BaseEntities
    {
        [Key]
        public Guid MenuCategoryId { get; set; }

        [MaxLength(255)]
        public string? Name { get; set; }

        [MaxLength(4000)]
        public string? Description { get; set; }
    }
}
