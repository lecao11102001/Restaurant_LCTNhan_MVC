using Restaurant_MVC.Entities;
using Restaurant_MVC.Models.ViewModels;

namespace Restaurant_MVC.Interface
{
    public interface IHome
    {
        List<FoodCategory> GetAllFoodCategories();
        List<FoodItem> GetAllFoodItems();
        List<Restaurants> GetAllRestaurants();
        List<MenuCategory> GetAllMenu();
        List<StoriesItem> GetAllStoriesItems();
        List<StoriesCategory> GetAllStoriesCategory();
        //PagedStoriesItem<StoriesItem> GetPageStoriesItem(int page);
        
    }
}
