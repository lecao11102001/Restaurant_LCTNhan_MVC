using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc;
using Restaurant_MVC.Interface;
using Restaurant_MVC.Models.ViewModels;

namespace Restaurant_MVC.Areas.Stories.Controllers
{
    [Area("Stories")]
    public class StoriesController : Controller
    {
        private readonly IStories _iStories;

        public StoriesController(IStories iStories)
        {
            _iStories = iStories;
        }

        // GET: StoriesController1
        public ActionResult Index()
        {
            var model = new Model();
            model.Restaurants = _iStories.GetAllRestaurants();

            return View(model);
        }


    }
}
