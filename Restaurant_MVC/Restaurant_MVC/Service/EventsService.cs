using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Restaurant_MVC.Areas.Admin.Models;
using Restaurant_MVC.Entities;
using Restaurant_MVC.Interface;

namespace Restaurant_MVC.Service
{
    public class EventsService : IEvents
    {
        private readonly RestaurantsDbContext _db;
        private readonly IMapper _mapper;

        public EventsService(RestaurantsDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public void Add_Events(EventsModel events)
        {
            var eventss = _mapper.Map<Events>(events);

            _db.Add(eventss);
            _db.SaveChanges();
        }

        public void DeleteEvent(Guid id)
        {
            var EventToDelete = _db.Eventss.FirstOrDefault(item => item.EventId == id);

            if (EventToDelete != null)
            {
                _db.Eventss.Remove(EventToDelete);
                _db.SaveChanges();
            }
            else
            {
                throw new Exception("Food item not found.");
            }
        }
        public void DeleteFoodItemEvent(Guid id)
        {
            var EventToDelete = _db.FoodItemEvents.FirstOrDefault(item => item.FoodItemEventId == id);

            if (EventToDelete != null)
            {
                _db.FoodItemEvents.Remove(EventToDelete);
                _db.SaveChanges();
            }
            else
            {
                throw new Exception("Food item not found.");
            }
        }

        public List<Events> GetActiveEvents()
        {
            DateTime now = DateTime.Now;
            return _db.Eventss.Where(e => e.StartDate <= now && e.EndDate >= now).ToList();
        }

        public List<Events> GetAllEvents()
        {
            return _db.Eventss.ToList();
        }

        public List<Events> Search_Events(string search)
        {
            return _db.Eventss.Where(x => x.Name.Contains(search)).ToList();

        }

        public void UpdateEvents(EventsModel even)
        {
            var evens = _db.Eventss.FirstOrDefault(x => x.EventId == even.EventId);

            if (evens != null)
            {
                _mapper.Map(even, evens); // Cập nhật thông tin từ ReservationModel vào existingCate

                _db.SaveChanges();
            }
        }
        public List<FoodItemEvent> FoodItemEvents()
        {
            return _db.FoodItemEvents.ToList();
        }

        public void Add_FoodItemEvents(FoodItemEventsModel fe)
        {
            var fes = _mapper.Map<FoodItemEvent>(fe);

            _db.Add(fes);
            _db.SaveChanges();
        }

        public List<FoodItem> GetAllFoodItems()
        {
            return _db.FoodItems.ToList();
        }

        public List<FoodCategory> GetAllFoodCategories()
        {
            return _db.FoodCategories.ToList();
        }

        public List<FoodItem> GetFoodItemsByCategory(Guid foodCategoryId)
        {
            //if (foodCategoryId == null)
            //    return _db.FoodItems.ToList();
            return _db.FoodItems.Where(item => item.FoodCategoryId == foodCategoryId).ToList();
        }
    }
}
