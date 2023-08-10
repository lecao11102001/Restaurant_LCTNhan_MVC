using Restaurant_MVC.Data;

namespace Restaurant_MVC.Models
{
    public interface IHome
    {
        List<FoodCategory> GetAllFoodCategories();
        List<FoodItem> GetAllFoodItems();

    }
}
