using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Restaurant_MVC.Entities
{
    [Table("FoodItem")]
    public class FoodItem : BaseEntities
    {
        [Key]
        public Guid FoodItemId { get; set; }

        public Guid FoodCategoryId { get; set; }

        [MaxLength(255)]
        public string? Name { get; set; }

        public decimal? Price { get; set; }

        [MaxLength]
        public string? Description { get; set; }

        [MaxLength]
        public string? Images { get; set; }

        [ForeignKey("FoodCategoryId")]
        public virtual FoodCategory FoodCategory { get; set; }
    }
}
