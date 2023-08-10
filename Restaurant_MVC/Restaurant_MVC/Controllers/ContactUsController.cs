using Microsoft.AspNetCore.Mvc;

namespace Restaurant_MVC.Controllers
{
    public class ContactUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
