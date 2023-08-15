using Restaurant_MVC.Areas.ContactUs.Models;
using Restaurant_MVC.Entities;

namespace Restaurant_MVC.Interface
{
    public interface IContactUs
    {
        Task<bool> SendMessage(ContactUsModel contactmodel);
        List<Restaurants> GetAllRestaurants();
    }
}
