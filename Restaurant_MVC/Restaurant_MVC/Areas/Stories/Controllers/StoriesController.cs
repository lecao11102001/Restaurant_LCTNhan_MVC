using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Restaurant_MVC.Areas.Stories.Controllers
{
    [Area("Stories")]
    public class StoriesController : Controller
    {
        // GET: StoriesController1
        public ActionResult Index()
        {
            return View();
        }


    }
}
