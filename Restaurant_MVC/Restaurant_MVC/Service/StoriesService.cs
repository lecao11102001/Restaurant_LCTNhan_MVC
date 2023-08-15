using Restaurant_MVC.Entities;
using Restaurant_MVC.Interface;

namespace Restaurant_MVC.Service
{
    public class StoriesService : IStories
    {
        private readonly RestaurantsDbContext _restaurantsDb;

        public StoriesService(RestaurantsDbContext restaurantsDb)
        {
            _restaurantsDb = restaurantsDb;
        }

        public List<Restaurants> GetAllRestaurants()
        {
            return _restaurantsDb.Restaurantss.ToList();
        }
    }
}
