using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant_MVC.Areas.Admin.Models;
using Restaurant_MVC.Common;
using Restaurant_MVC.Entities;
using Restaurant_MVC.Interface;
using X.PagedList;

namespace Restaurant_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsController : Controller
    {

        private readonly INews _iNews;

        public NewsController(INews iNews)
        {
            _iNews = iNews;
        }

        // GET: NewsController
        public ActionResult Index(string currentFilter, string SearchString, int? page)
        {
            var model = new Model();

            if (SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = currentFilter;
            }

            model.CurrentFilter = SearchString;
            model.PageSize = 7; // Số mục trên mỗi trang
            model.CurrentPage = page ?? 1; // Số trang hiện tại (nếu không có, mặc định là 1)

            if (SearchString == null)
            {
                model.ListNew = _iNews.GetAllNews().OrderByDescending(n => n.CreatedDate).ToPagedList(model.CurrentPage, model.PageSize);
            }
            else
            {
                model.ListNew = _iNews.Search_News(SearchString).OrderByDescending(n => n.CreatedDate).ToPagedList(model.CurrentPage, model.PageSize);
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(NewsModel news)
        {
            _iNews.Add_News(news);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            var objnew = _iNews.GetAllNews().FirstOrDefault(x => x.NewId == id);

            if (objnew != null)
            {
                _iNews.DeleteNews(objnew.NewId);
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound(new { message = "Food item not found." });
            }
        }
    }
}
