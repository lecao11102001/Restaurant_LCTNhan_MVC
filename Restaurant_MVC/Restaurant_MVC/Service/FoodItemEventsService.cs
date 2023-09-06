using Microsoft.EntityFrameworkCore;
using Restaurant_MVC.Entities;
using Restaurant_MVC.Interface;

namespace Restaurant_MVC.Service
{
    public class FoodItemEventsService : IFoodItemEvents
    {
        private readonly RestaurantsDbContext _dbContext;

        public FoodItemEventsService(RestaurantsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<FoodItemEvent> GetAllFoodItemEvents()
        {
            var food = _dbContext.FoodItemEvents.ToList();
            return food;
        }
    }
}
