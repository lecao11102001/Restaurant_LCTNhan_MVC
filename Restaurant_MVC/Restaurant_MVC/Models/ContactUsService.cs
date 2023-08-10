using Microsoft.EntityFrameworkCore;
using Restaurant_MVC.Data;

namespace Restaurant_MVC.Models
{
    public class ContactUsService : IContactUs
    {
        private readonly RestaurantsDbContext _restaurantsDbContext;

        public ContactUsService(RestaurantsDbContext restaurantsDbContext)
        {
            _restaurantsDbContext = restaurantsDbContext;
        }
        public void SendMessage(ContactUsModel contactmodel)
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
            _restaurantsDbContext.SaveChanges();
        }
    }
}
