using Restaurant_MVC.Data;

namespace Restaurant_MVC.Models
{
    public interface ISpecialties
    {
        PagedResult<FoodItem> GetPagedFoodItems(int page);
        List<FoodCategory> GetAllFoodCategories();
    }
}
