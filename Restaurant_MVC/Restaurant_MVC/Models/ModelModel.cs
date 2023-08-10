using Restaurant_MVC.Data;

namespace Restaurant_MVC.Models
{
    public class ModelModel
    {
        public List<FoodCategory> ListFoodCategories { get; set; }
        public List<FoodItem> ListFoodItems { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        //public List<string> listMenu { get; set; }
    }
    public class PagedResult<T>
    {
        public List<T> Items { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
