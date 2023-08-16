using Restaurant_MVC.Interface;
using Restaurant_MVC.Entities;
using Restaurant_MVC.Common;

namespace Restaurant_MVC.Service
{
    public class HomeService : IHome
    {
        private readonly RestaurantsDbContext _restaurantsDbContext;

        public HomeService(RestaurantsDbContext restaurantsDbContext)
        {
            _restaurantsDbContext = restaurantsDbContext;
        }

        public List<FoodCategory> GetAllFoodCategories()
        {
            return _restaurantsDbContext.FoodCategories.ToList();
        }

        public List<FoodItem> GetAllFoodItems()
        {
            return _restaurantsDbContext.FoodItems.ToList();
        }

        public List<Restaurants> GetAllRestaurants()
        {
            return _restaurantsDbContext.Restaurantss.ToList();
        }

        public List<MenuCategory> GetAllMenu()
        {
            return _restaurantsDbContext.Menus.ToList();
        }

        public Page<Events> GetPageStoriesItem(int page = 1)
        {
            int pageSize = 2;
            var skip = (page - 1) * pageSize;

            // Item
            var pagedItems = _restaurantsDbContext.Eventss.Skip(skip).Take(pageSize).ToList();

            // Tổng items
            var totalItems = _restaurantsDbContext.Eventss.Count();

            // Tổng trang
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            var result = new Page<Events>
            {
                Items = pagedItems,
                CurrentPage = page,
                TotalPages = totalPages
            };

            return result;
        }
    }
}
