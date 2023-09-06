using AutoMapper;
using Restaurant_MVC.Areas.Admin.Models;
using Restaurant_MVC.Entities;
using Restaurant_MVC.Interface;

namespace Restaurant_MVC.Service
{
    public class CategoriesService : ICategories
    {
        private readonly RestaurantsDbContext _context;
        private readonly IMapper _imapper;

        public CategoriesService(RestaurantsDbContext context, IMapper imapper)
        {
            _context = context;
            _imapper = imapper;
        }

        public void AddCategories(CategoriesModel cate)
        {
            var category = _imapper.Map<FoodCategory>(cate);

            _context.Add(category);
            _context.SaveChanges();
        }

        public void DeleteCategories(Guid id)
        {
            var foodCateDelete = _context.FoodCategories.FirstOrDefault(item => item.FoodCategoryId == id);

            if (foodCateDelete != null)
            {
                _context.FoodCategories.Remove(foodCateDelete);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Food item not found.");
            }
        }

        public List<FoodCategory> GetAllCategories()
        {
            return _context.FoodCategories.ToList();
        }

        public void UpdateCategories(CategoriesModel spec)
        {
            var existingCate = _context.FoodCategories.FirstOrDefault(x => x.FoodCategoryId == spec.CategoryId);

            if (existingCate != null)
            {
                _imapper.Map(spec, existingCate); // Cập nhật thông tin từ CategoriesModel vào existingCate

                _context.SaveChanges();
            }
        }
    }
}
