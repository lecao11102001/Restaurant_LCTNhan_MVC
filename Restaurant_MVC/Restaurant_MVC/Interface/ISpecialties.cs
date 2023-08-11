using Restaurant_MVC.Models.Entities;
using Restaurant_MVC.Models.ViewModels;

namespace Restaurant_MVC.Interface
{
    public interface ISpecialties
    {
        PagedResult<FoodItem> GetPagedFoodItems(int page);
        List<FoodCategory> GetAllFoodCategories();
    }
}
