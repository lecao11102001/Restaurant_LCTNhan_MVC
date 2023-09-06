using Restaurant_MVC.Entities;
using Restaurant_MVC.Models.ContactUsModels;

namespace Restaurant_MVC.Interface
{
    public interface IContactUs
    {
        Task<bool> SendMessage(ContactUsModel contactmodel);
        List<Restaurants> GetAllRestaurants();
        List<ContactUs> GetAllContacts();
        List<ContactUs> Search_ContactUs(string search);
        void DeleteContactUs(Guid id);
    }
}
