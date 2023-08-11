using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Restaurant_MVC.Models.Entities
{
    [Table("FoodCategory")]
    public class FoodCategory : BaseEntities
    {
        [Key]
        public Guid? FoodCategoryId { get; set; }

        [MaxLength(255)]
        public string? Name { get; set; }

        [InverseProperty("FoodCategory")]
        public virtual ICollection<FoodItem> FoodItems { get; set; }

    }
}
