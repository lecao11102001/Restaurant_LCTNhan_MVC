using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Restaurant_MVC.Areas.ContactUs.Models;
using Restaurant_MVC.Interface;
using Restaurant_MVC.Entities;

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

        public List<Restaurants> GetAllRestaurants()
        {
            return _restaurantsDbContext.Restaurantss.ToList();
        }

        public async Task<bool> SendMessage(ContactUsModel contactmodel)
        {
            try
            {
                //var contactus = new ContactUs
                //{
                //    CustomerId = contactmodel.CustomerId,
                //    Name = contactmodel.Name,
                //    Email = contactmodel.Email,
                //    Subject = contactmodel.Subject,
                //    Message = contactmodel.Message
                //};
                var contactus = _iMapp.Map<ContactUs>(contactmodel);
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
