using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant_MVC.Entities
{
    [Table("FoodItemEvents")]
    public class FoodItemEvent
    {
        [Key]
        public Guid FoodItemEventId { get; set; }
        public Guid FoodItemId { get; set; }
        public Guid EventId { get; set; }
        public FoodItem FoodItem { get; set; }
        public Events Event { get; set; }




        //public Guid FoodItemId { get; set; }
        //public string Name { get; set; }
        //public decimal? Price { get; set; }
        //public string Description { get; set; }
        //public decimal? DiscountAmount { get; set; }
    }
}
