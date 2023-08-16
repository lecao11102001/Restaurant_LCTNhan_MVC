using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using Restaurant_MVC.Interface;
using Restaurant_MVC.Common;
using Restaurant_MVC.Areas.ContactUs.Models;

namespace Restaurant_MVC.Areas.ContactUs.Controllers
{
    [Area("ContactUs")]
    public class ContactUsController : Controller
    {
        private readonly IContactUs _iContactUs;

        public ContactUsController(IContactUs iContactUs)
        {
            _iContactUs = iContactUs;
        }

        public ActionResult Index()
        {
            var model = new Model();

            model.Restaurants = _iContactUs.GetAllRestaurants();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitForm(ContactUsModel model)
        {
            // Thêm vào database
            _iContactUs.SendMessage(model);

            MailMessage mailMessage = new MailMessage(model.Email, "lecao11102001@gmail.com", model.Subject, model.Message);

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(model.Email, "dxyspnjrduwhpegk");

            smtpClient.SendMailAsync(mailMessage);

            return View("Index");

        }


    }
}
