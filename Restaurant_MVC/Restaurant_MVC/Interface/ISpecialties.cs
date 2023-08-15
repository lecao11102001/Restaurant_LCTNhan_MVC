using Restaurant_MVC.Entities;
using Restaurant_MVC.Areas.Specialties.Models;

namespace Restaurant_MVC.Interface
{
    public interface ISpecialties
    {
        PagedMenu<FoodItem> GetPagedFoodItems(int page);
        List<FoodCategory> GetAllFoodCategories();
        List<Restaurants> GetAllRestaurants();

    }
}
