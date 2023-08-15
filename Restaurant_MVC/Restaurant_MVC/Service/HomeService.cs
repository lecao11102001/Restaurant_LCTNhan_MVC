using Restaurant_MVC.Interface;
using Restaurant_MVC.Entities;
using Restaurant_MVC.Models.ViewModels;

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

        public List<StoriesItem> GetAllStoriesItems()
        {
            return _restaurantsDbContext.StoriesItems.ToList();
        }
        
        public List<StoriesCategory> GetAllStoriesCategory()
        {
            return _restaurantsDbContext.StoriesCategories.ToList();
        }

        //public PagedStoriesItem<StoriesItem> GetPageStoriesItem(int page =1)
        //{
        //    int pageSize = 2;
        //    var skip = (page - 1) * pageSize;

        //    // Item
        //    var pagedItems = _restaurantsDbContext.StoriesItems.Skip(skip).Take(pageSize).ToList();

        //    // Tổng items
        //    var totalItems = _restaurantsDbContext.StoriesItems.Count();
        //    // Tổng trang
        //    var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

        //    var result = new PagedStoriesItem<StoriesItem>
        //    {
        //        Items = pagedItems,
        //        CurrentPage = page,
        //        TotalPages = totalPages
        //    };

        //    return result;
        //}
    }
}
