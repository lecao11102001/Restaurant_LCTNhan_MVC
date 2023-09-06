using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant_MVC.Areas.Admin.Models;
using Restaurant_MVC.Common;
using Restaurant_MVC.Interface;

namespace Restaurant_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly ICategories _iCategories;
        
        public CategoriesController(ICategories iCategories)
        {
            _iCategories = iCategories;
        }

        // GET: Categories
        public ActionResult Index()
        {
            var model = new Model();
            model.ListFoodCategories = _iCategories.GetAllCategories();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(CategoriesModel categories)
        {
            _iCategories.AddCategories(categories);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var model = new Model();
            model.ListFoodCategories  = _iCategories.GetAllCategories().Where(x=>x.FoodCategoryId == id).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(CategoriesModel cate)
        {
            var food = _iCategories.GetAllCategories().FirstOrDefault(x => x.FoodCategoryId == cate.CategoryId);
            if (food != null)
            {
                _iCategories.UpdateCategories(cate);
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound(new { message = "Food item not found." });
            }
        }

        public ActionResult Delete(Guid id)
        {
            var objfoodcate = _iCategories.GetAllCategories().FirstOrDefault(x => x.FoodCategoryId == id);

            if (objfoodcate != null)
            {
                _iCategories.DeleteCategories(objfoodcate.FoodCategoryId);
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound(new { message = "Food item not found." });
            }
        }
    }
}
