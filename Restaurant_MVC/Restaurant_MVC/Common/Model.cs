using Restaurant_MVC.Entities;

namespace Restaurant_MVC.Common
{
    public class Model
    {
        public List<FoodCategory> ListFoodCategories { get; set; }
        public List<FoodItem> ListFoodItems { get; set; }
        public List<Restaurants> Restaurants { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public List<MenuCategory> listMenu { get; set; }
        public List<News> ListNews { get; set; }
        public List<Events> ListEvents { get; set; }
    }
}
