using Restaurant_MVC.Models.Entities;

namespace Restaurant_MVC.Models.ViewModels
{
    public class ModelModel
    {
        public List<FoodCategory> ListFoodCategories { get; set; }
        public List<FoodItem> ListFoodItems { get; set; }
        //public List<Restaurants> Restaurants { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public List<MenuCategory> listMenu { get; set; }
    }
    public class PagedResult<T>
    {
        public List<T> Items { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
    public class LayoutViewModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
    }

}
