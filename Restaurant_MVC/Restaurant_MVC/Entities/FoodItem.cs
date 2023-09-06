using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using Restaurant_MVC.Common;

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
        [Column(TypeName = "decimal(18,0)")]
        public decimal? Price { get; set; } 
        [MaxLength]
        public string? Description { get; set; } 
        [MaxLength]
        public string? Images { get; set; } 
        [ForeignKey("FoodCategoryId")]
        public virtual FoodCategory FoodCategory { get; set; }

        public ICollection<FoodItemEvent> FoodItemEvents { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        [NotMapped] // Đánh dấu thuộc tính này không được ánh xạ vào cơ sở dữ liệu
        public decimal? DiscountedPrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [NotMapped]
        public decimal? DiscountAmount { get; set; }
    }
}
