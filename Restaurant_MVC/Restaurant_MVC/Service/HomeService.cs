using Restaurant_MVC.Interface;
using Restaurant_MVC.Entities;
using Restaurant_MVC.Common;
using Restaurant_MVC.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Restaurant_MVC.Service
{
    public class HomeService : IHome
    {
        private readonly RestaurantsDbContext _restaurantsDbContext;
        private readonly IMapper _mapper;

        public HomeService(RestaurantsDbContext restaurantsDbContext, IMapper mapper)
        {
            _restaurantsDbContext = restaurantsDbContext;
            _mapper = mapper;
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

        public List<Events> GetAllEvent()
        {
            return _restaurantsDbContext.Eventss.ToList();
        }
        
        public List<Customer> GetAllCustomer()
        {
            return _restaurantsDbContext.Customers.ToList();
        }

        public void UpdateCustomers(UpdateModel up)
        {
            var existingCate = _restaurantsDbContext.Customers.FirstOrDefault(x => x.CustomerId == up.CustomerId);

            if (existingCate != null)
            {
                _mapper.Map(up, existingCate); // Cập nhật thông tin từ ReservationModel vào existingCate

                _restaurantsDbContext.SaveChanges();
            }
        }
    }
}
