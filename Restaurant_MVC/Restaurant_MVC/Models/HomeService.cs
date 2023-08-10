using Restaurant_MVC.Data;

namespace Restaurant_MVC.Models
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
    }
}
