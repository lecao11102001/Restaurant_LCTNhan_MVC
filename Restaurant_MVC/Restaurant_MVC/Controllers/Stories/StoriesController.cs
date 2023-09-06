using Microsoft.AspNetCore.Mvc;
using Restaurant_MVC.Common;
using System.Drawing.Printing;
using System.Net.WebSockets;
using Restaurant_MVC.Interface;
using X.PagedList;

namespace Restaurant_MVC.Controllers.Stories
{
    public class StoriesController : Controller
    {
        private readonly INews _iNews;

        public StoriesController(INews iNews)
        {
            _iNews = iNews;
        }

        // GET: StoriesController1
        public ActionResult Index(int? page)
        {
            var model = new Model();

            model.PageSize = 6; // Số mục trên mỗi trang
            model.CurrentPage = page ?? 1; // Số trang hiện tại (nếu không có, mặc định là 1)
            model.ListNew = _iNews.GetAllNews().OrderByDescending(n => n.CreatedDate).ToPagedList(model.CurrentPage, model.PageSize);

            model.Restaurants = _iNews.GetAllRestaurants();

            return View(model);
        }


    }
}
