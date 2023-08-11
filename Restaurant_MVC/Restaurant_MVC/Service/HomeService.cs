using Restaurant_MVC.Interface;
using Restaurant_MVC.Models.Entities;

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
    }
}
