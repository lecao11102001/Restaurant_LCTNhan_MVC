using Restaurant_MVC.Entities;

namespace Restaurant_MVC.Models.ViewModels
{
    public class Model
    {
        public List<FoodCategory> ListFoodCategories { get; set; }
        public List<FoodItem> ListFoodItems { get; set; }
        public List<Restaurants>? Restaurants { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public List<MenuCategory> listMenu { get; set; }
        public List<StoriesItem> ListStoriesItem { get; set; }
        public List<StoriesCategory> ListStoriesCategory { get; set; }
    }

    //public class PagedStoriesItem<T>
    //{
    //    public List<T> Items { get; set; }
    //    public int CurrentPage { get; set; }
    //    public int TotalPages { get; set; }
    //}

}
