using Restaurant_MVC.Areas.Admin.Models;
using Restaurant_MVC.Entities;

namespace Restaurant_MVC.Interface
{
    public interface ICategories
    {
        List<FoodCategory> GetAllCategories();
        void AddCategories(CategoriesModel cate);
        void DeleteCategories(Guid id);
        void UpdateCategories(CategoriesModel spec);
    }
}
