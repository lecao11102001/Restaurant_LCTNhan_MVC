using Microsoft.AspNetCore.Mvc;
using Restaurant_MVC.Interface;
using Restaurant_MVC.Models.ViewModels;

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
            var pagedFoodItems = _iSpecialties.GetPagedFoodItems(page);
            var allFoodCategories = _iSpecialties.GetAllFoodCategories();

            var model = new ModelModel
            {
                ListFoodItems = pagedFoodItems.Items,
                CurrentPage = pagedFoodItems.CurrentPage,
                TotalPages = pagedFoodItems.TotalPages,
                ListFoodCategories = allFoodCategories
            };

            return View(model);
        }
    }
}
