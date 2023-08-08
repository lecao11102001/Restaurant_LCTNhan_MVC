using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant_MVC.Data;
using Restaurant_MVC.Models.SharedDataDictionary;
using Restaurant_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Restaurant_MVC.Controllers
{
    public class SpecialtiesController : Controller
    {
        private readonly RestaurantsDbContext _restaurantsDbContext;
        public SpecialtiesController(RestaurantsDbContext restaurantsDbContext)
        {
            _restaurantsDbContext = restaurantsDbContext;
        }
        // GET: Specialties
        public ActionResult Index()
        {
            ModelModel model = new ModelModel();
            model.ListFoodCategories = _restaurantsDbContext.FoodCategories.ToList();
            model.ListFoodItems = _restaurantsDbContext.FoodItems.ToList();

            return View(model);
        }
        public IActionResult ProductsByCategory(Guid categoryId)
        {
            var productsInCategory = _restaurantsDbContext.FoodItems.Where(s => s.FoodCategoryId == categoryId).ToList();

            return View(productsInCategory);
        }

    }
}
