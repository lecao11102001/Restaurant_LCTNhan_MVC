using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Restaurant_MVC.Areas.About.Controllers
{
    [Area("About")]
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            return View();
        }


    }
}
