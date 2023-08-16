using Restaurant_MVC.Entities;
using Restaurant_MVC.Common;

namespace Restaurant_MVC.Interface
{
    public interface IHome
    {
        List<FoodCategory> GetAllFoodCategories();
        List<FoodItem> GetAllFoodItems();
        List<Restaurants> GetAllRestaurants();
        List<MenuCategory> GetAllMenu();
        Page<Events> GetPageStoriesItem(int page);

    }
}
