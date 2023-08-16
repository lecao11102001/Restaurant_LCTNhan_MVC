using Microsoft.AspNetCore.Mvc;
using Restaurant_MVC.Interface;
using Restaurant_MVC.Common;

namespace Restaurant_MVC.Areas.Specialties.Controllers
{
    [Area("Specialties")]
    public class SpecialtiesController : Controller
    {
        private readonly ISpecialties _iSpecialties;

        public SpecialtiesController(ISpecialties iSpecialties)
        {
            _iSpecialties = iSpecialties;
        }
        // GET: Specialties
        public ActionResult Index(int page = 1)
        {
            var pagedFoodItems = _iSpecialties.GetPageFoodItems(page);

            var model = new Model();

            model.ListFoodItems = pagedFoodItems.Items;
            model.CurrentPage = pagedFoodItems.CurrentPage;
            model.TotalPages = pagedFoodItems.TotalPages;
            
            model.Restaurants = _iSpecialties.GetAllRestaurants();
            model.ListFoodCategories = _iSpecialties.GetAllFoodCategories();
            return View(model);
        }
    }
}
