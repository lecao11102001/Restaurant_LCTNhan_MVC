using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using Restaurant_MVC.Areas.Admin.Models;
using Restaurant_MVC.Common;
using Restaurant_MVC.Entities;
using Restaurant_MVC.Interface;


namespace Restaurant_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpecialtiesController : Controller
    {
        private readonly ISpecialties _iSpecialties;
        private readonly IEvents _iEvent;
        private readonly IFoodItemEvents _foodItemEvents;

        public SpecialtiesController(ISpecialties iSpecialties, IEvents iEvent, IFoodItemEvents foodItemEvents)
        {
            _iSpecialties = iSpecialties;
            _iEvent = iEvent;
            _foodItemEvents = foodItemEvents;
        }

        // GET: SpecialtiesController


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
                model.ListFoodItem = _iSpecialties.GetAllFoodItems().OrderByDescending(n => n.CreatedDate).ToPagedList(model.CurrentPage, model.PageSize);
            }
            else
            {
                model.ListFoodItem = _iSpecialties.Search_FoodItem(SearchString).OrderByDescending(n => n.CreatedDate).ToPagedList(model.CurrentPage, model.PageSize);
            }

            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var model = new Model();

            model.ListFoodCategories = _iSpecialties.GetAllFoodCategories();

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(SpecialtiesModel modal, IFormFile Images)
        {
            _iSpecialties.SaveImage(modal, Images);
            _iSpecialties.AddSpecialties(modal);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var model = new Model();
            model.ListFoodItems = _iSpecialties.GetAllFoodItems().Where(x => x.FoodItemId == id).ToList();
            model.ListFoodCategories = _iSpecialties.GetAllFoodCategories();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(SpecialtiesModel modal, IFormFile Images)
        {
            var food = _iSpecialties.GetAllFoodItems().FirstOrDefault(x => x.FoodItemId == modal.FoodItemId);
            if (food != null)
            {
                if (Images != null)
                {
                    _iSpecialties.SaveImage(modal, Images);
                }
                _iSpecialties.UpdateSpecialties(modal);
                return RedirectToAction("Index");

            }
            else
            {
                return NotFound(new { message = "Food item not found." });
            }
        }

        public ActionResult Delete(Guid id)
        {
            var objfooditem = _iSpecialties.GetAllFoodItems().FirstOrDefault(x => x.FoodItemId == id);

            if (objfooditem != null)
            {
                _iSpecialties.DeleteSpecialties(objfooditem.FoodItemId);
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound(new { message = "Food item not found." });
            }
        }
        public ActionResult FoodItemEvents(int? page)
        {
            var model = new Model();

            model.PageSize = 7; // Số mục trên mỗi trang
            model.CurrentPage = page ?? 1; // Số trang hiện tại (nếu không có, mặc định là 1)

            model.FoodItemEvent = _iEvent.FoodItemEvents().ToPagedList(model.CurrentPage, model.PageSize);

            model.ListFoodItems = _iSpecialties.GetAllFoodItems();
            model.ListEvents = _iEvent.GetAllEvents();
            return View(model);
        }

        public ActionResult DeleteEvents(Guid id)
        {
            var objEvent = _iEvent.FoodItemEvents().FirstOrDefault(x => x.FoodItemEventId == id);

            if (objEvent != null)
            {
                _iEvent.DeleteFoodItemEvent(objEvent.FoodItemEventId);
                return RedirectToAction("FoodItemEvents");
            }
            else
            {
                return NotFound(new { message = "Food item not found." });
            }
        }

        public ActionResult CreateFoodItemEvents(FoodItemEventsModel fe, List<Guid> selectedFoodItems)
        {
            foreach (var reservationId in selectedFoodItems)
            {
                var reservation = _iSpecialties.GetReservationById(reservationId);
                if (reservation != null)
                {
                    fe.FoodItemId = reservation.FoodItemId;
                    _iEvent.Add_FoodItemEvents(fe);
                }
            }
            return RedirectToAction("FoodItemEvents");
        }

        public ActionResult CreateFoodItemEvent(Guid? selectedFoodCategory)
        {
            var model = new Model();
            if (selectedFoodCategory.HasValue)
            {
                model.Select_ListFoodItems = _iEvent.GetFoodItemsByCategory(selectedFoodCategory.Value);
            }
            else
            {
                model.Select_ListFoodItems = _iEvent.GetAllFoodItems();
            }
            model.ListEvents = _iEvent.GetAllEvents();
            model.ListFoodItems = _iEvent.GetAllFoodItems();
            model.ListFoodCategories = _iEvent.GetAllFoodCategories();
            //model.ListFoodItems = _iSpec.GetAllFoodItems();
            return View(model);

        }
    }
}