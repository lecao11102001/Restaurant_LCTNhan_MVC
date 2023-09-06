using Restaurant_MVC.Entities;

namespace Restaurant_MVC.Areas.Admin.Models
{
    public class FoodItemEventsModel
    {
        public Guid FoodItemId { get; set; }
        public Guid EventId { get; set; }
        public FoodItem FoodItem { get; set; }
        public Events Event { get; set; }
    }
}
