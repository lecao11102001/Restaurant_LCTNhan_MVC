using Microsoft.AspNetCore.Mvc;
using Restaurant_MVC.Data;
using Restaurant_MVC.Models;
using System.Net.Mail;
using System.Net;

namespace Restaurant_MVC.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly IContactUs _iContactUs;

        public ContactUsController(IContactUs iContactUs)
        {
            _iContactUs = iContactUs;
        }

        public ActionResult Index()
        {
            return View();
        }

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
