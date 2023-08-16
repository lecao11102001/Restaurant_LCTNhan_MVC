
using Restaurant_MVC.Interface;
using Restaurant_MVC.Entities;
using Restaurant_MVC.Common;

namespace Restaurant_MVC.Service
{
    public class SpecialtiesService : ISpecialties
    {
        private readonly RestaurantsDbContext _restaurantsDbContext;
        public SpecialtiesService(RestaurantsDbContext restaurantsDbContext)
        {
            _restaurantsDbContext = restaurantsDbContext;
        }

        public List<FoodCategory> GetAllFoodCategories()
        {
            return _restaurantsDbContext.FoodCategories.ToList();
        }

        public List<Restaurants> GetAllRestaurants()
        {
            return _restaurantsDbContext.Restaurantss.ToList();
        }

        Page<FoodItem> ISpecialties.GetPageFoodItems(int page = 1)
        {
            int pageSize = 9;
            var skip = (page - 1) * pageSize;
            // Item
            var pagedItems = _restaurantsDbContext.FoodItems.Skip(skip).Take(pageSize).ToList();

            // Tổng items
            var totalItems = _restaurantsDbContext.FoodItems.Count();
            // Tổng trang
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            var result = new Page<FoodItem>
            {
                Items = pagedItems,
                CurrentPage = page,
                TotalPages = totalPages
            };

            return result;
        }
    }

}
