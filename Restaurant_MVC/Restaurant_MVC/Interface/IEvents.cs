using Restaurant_MVC.Areas.Admin.Models;
using Restaurant_MVC.Entities;
using Restaurant_MVC.Models.ReservationModels;

namespace Restaurant_MVC.Interface
{
    public interface IEvents
    {
        List<Events> GetAllEvents();
        List<FoodItem> GetAllFoodItems();
        List<FoodCategory> GetAllFoodCategories();
        List<Events> GetActiveEvents();
        List<Events> Search_Events(string search);
        public void Add_Events(EventsModel events);
        public void DeleteEvent(Guid id);
        public void DeleteFoodItemEvent(Guid id);
        void UpdateEvents(EventsModel even);
        List<FoodItemEvent> FoodItemEvents();
        public void Add_FoodItemEvents(FoodItemEventsModel events);



        List<FoodItem> GetFoodItemsByCategory(Guid foodCategoryId);


    }
}
