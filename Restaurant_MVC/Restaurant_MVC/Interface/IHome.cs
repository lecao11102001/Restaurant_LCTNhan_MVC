using Restaurant_MVC.Entities;
using Restaurant_MVC.Common;
using Restaurant_MVC.Models.ReservationModels;
using Restaurant_MVC.Models.ViewModels;

namespace Restaurant_MVC.Interface
{
    public interface IHome
    {
        List<FoodCategory> GetAllFoodCategories();
        List<FoodItem> GetAllFoodItems();
        List<Restaurants> GetAllRestaurants();
        List<MenuCategory> GetAllMenu();
        List<Events> GetAllEvent();
        void UpdateCustomers(UpdateModel up);
        List<Customer> GetAllCustomer();
    }
}
