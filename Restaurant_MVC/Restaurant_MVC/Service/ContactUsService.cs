using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Restaurant_MVC.Interface;
using Restaurant_MVC.Entities;
using Restaurant_MVC.Models.ContactUsModels;

namespace Restaurant_MVC.Service
{
    public class ContactUsService : IContactUs
    {
        private readonly RestaurantsDbContext _restaurantsDbContext;
        private readonly IMapper _iMapp;

        public ContactUsService(RestaurantsDbContext restaurantsDbContext, IMapper iMapp)
        {
            _restaurantsDbContext = restaurantsDbContext;
            _iMapp = iMapp;
        }

        public void DeleteContactUs(Guid id)
        {
            var ContactToDelete = _restaurantsDbContext.ContactUss.FirstOrDefault(item => item.ContactUsId == id);

            if (ContactToDelete != null)
            {
                _restaurantsDbContext.ContactUss.Remove(ContactToDelete);
                _restaurantsDbContext.SaveChanges();
            }
            else
            {
                throw new Exception("Food item not found.");
            }
        }

        public List<ContactUs> GetAllContacts()
        {
            return _restaurantsDbContext.ContactUss.ToList();
        }

        public List<Restaurants> GetAllRestaurants()
        {
            return _restaurantsDbContext.Restaurantss.ToList();
        }

        public List<ContactUs> Search_ContactUs(string search)
        {
            return _restaurantsDbContext.ContactUss.Where(x=>x.Name.Contains(search) || x.Email.Contains(search)).ToList();
        }

        public async Task<bool> SendMessage(ContactUsModel contactmodel)
        {
            try
            {
                var contactus = _iMapp.Map<Entities.ContactUs>(contactmodel);
                _restaurantsDbContext.ContactUss.Add(contactus);

                await _restaurantsDbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
