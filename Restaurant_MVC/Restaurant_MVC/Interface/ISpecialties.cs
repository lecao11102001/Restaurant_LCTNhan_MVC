using Restaurant_MVC.Entities;
using Restaurant_MVC.Common;

namespace Restaurant_MVC.Interface
{
    public interface ISpecialties
    {
        Page<FoodItem> GetPageFoodItems(int page);
        List<FoodCategory> GetAllFoodCategories();
        List<Restaurants> GetAllRestaurants();

    }
}
