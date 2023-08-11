using Restaurant_MVC.Models.Entities;

namespace Restaurant_MVC.Interface
{
    public interface IHome
    {
        List<FoodCategory> GetAllFoodCategories();
        List<FoodItem> GetAllFoodItems();
        List<Restaurants> GetAllRestaurants();
        List<MenuCategory> GetAllMenu();

    }
}
