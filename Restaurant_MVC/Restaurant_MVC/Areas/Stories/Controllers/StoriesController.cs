using Microsoft.AspNetCore.Mvc;
using Restaurant_MVC.Interface;
using Restaurant_MVC.Common;
using System.Drawing.Printing;
using System.Net.WebSockets;

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
        public ActionResult Index(int page = 1)
        {
            var pageStories = _iStories.GetPageStoriesItems(page);

            var model = new Model();
            model.Restaurants = _iStories.GetAllRestaurants();

            model.ListNews = pageStories.Items;
            model.CurrentPage = pageStories.CurrentPage;
            model.TotalPages = pageStories.TotalPages;

            return View(model);
        }


    }
}
