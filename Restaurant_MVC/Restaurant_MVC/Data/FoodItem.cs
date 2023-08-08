using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Restaurant_MVC.Data
{
    [Table("FoodItem")]
    public class FoodItem
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

        public DateTime? CreatedDate { get; set; }

        public Guid? CreatedById { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public Guid? ModifiedById { get; set; }

        public DateTime? DeleteDate { get; set; }

        public Guid? DeleteById { get; set; }

        [ForeignKey("FoodCategoryId")]
        public virtual FoodCategory FoodCategory { get; set; }
    }
}
