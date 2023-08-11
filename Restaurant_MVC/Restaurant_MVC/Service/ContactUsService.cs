using Microsoft.EntityFrameworkCore;
using Restaurant_MVC.Interface;
using Restaurant_MVC.Models.Entities;
using Restaurant_MVC.Models.ViewModels;

namespace Restaurant_MVC.Service
{
    public class ContactUsService : IContactUs
    {
        private readonly RestaurantsDbContext _restaurantsDbContext;

        public ContactUsService(RestaurantsDbContext restaurantsDbContext)
        {
            _restaurantsDbContext = restaurantsDbContext;
        }

        /// <summary>
        /// Send message
        /// </summary>
        /// <param name="contactmodel"></param>
        public async Task<bool> SendMessage(ContactUsModel contactmodel)
        {
            try
            {
                var contactus = new ContactUs
                {
                    CustomerId = contactmodel.CustomerId,
                    Name = contactmodel.Name,
                    Email = contactmodel.Email,
                    Subject = contactmodel.Subject,
                    Message = contactmodel.Message
                };

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
