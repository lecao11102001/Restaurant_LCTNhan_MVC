using Microsoft.Extensions.Logging;
using Restaurant_MVC.Common;
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

        

        public Page<News> GetPageStoriesItems(int page = 1)
        {
            int pageSize = 6;
            var skip = (page - 1) * pageSize;

            // Item
            var pagedItems = _restaurantsDb.Newss.Skip(skip).Take(pageSize).ToList();

            // Tổng items
            var totalItems = _restaurantsDb.Newss.Count();

            // Tổng trang
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            var result = new Page<News>
            {
                Items = pagedItems,
                CurrentPage = page,
                TotalPages = totalPages
            };

            return result;
        }
    }
}
