using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Restaurant_MVC.Data
{
    [Table("FoodCategory")]
    public class FoodCategory
    {
        [Key]
        public Guid? FoodCategoryId { get; set; }

        [MaxLength(255)]
        public string? Name { get; set; }

        public DateTime? CreatedDate { get; set; }

        public Guid? CreatedById { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public Guid? ModifiedById { get; set; }

        public DateTime? DeleteDate { get; set; }

        public Guid? DeleteById { get; set; }

        [InverseProperty("FoodCategory")]
        public virtual ICollection<FoodItem> FoodItems { get; set; }

    }
}
