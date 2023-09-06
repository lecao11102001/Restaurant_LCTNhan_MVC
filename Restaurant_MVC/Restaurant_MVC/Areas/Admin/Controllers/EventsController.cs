using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant_MVC.Areas.Admin.Models;
using Restaurant_MVC.Common;
using Restaurant_MVC.Entities;
using Restaurant_MVC.Interface;
using Restaurant_MVC.Models.ReservationModels;
using System.Net.Mail;
using System.Net;
using X.PagedList;

namespace Restaurant_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class EventsController : Controller
    {
        private readonly IEvents _iEvent;
        //private readonly ISpecialties _iSpec;

        public EventsController(IEvents iEvent, ISpecialties iSpec)
        {
            _iEvent = iEvent;
            //_iSpec = iSpec;
        }

        // GET: EventsController
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
                model.ListEvent = _iEvent.GetAllEvents().OrderByDescending(n => n.CreatedDate).ToPagedList(model.CurrentPage, model.PageSize);
            }
            else
            {
                model.ListEvent = _iEvent.Search_Events(SearchString).OrderByDescending(n => n.CreatedDate).ToPagedList(model.CurrentPage, model.PageSize);
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(EventsModel events)
        {
            _iEvent.Add_Events(events);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            var objEvent = _iEvent.GetAllEvents().FirstOrDefault(x => x.EventId == id);

            if (objEvent != null)
            {
                _iEvent.DeleteEvent(objEvent.EventId);
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound(new { message = "Food item not found." });
            }
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var model = new Model();
            model.ListEvents = _iEvent.GetAllEvents().Where(x => x.EventId == id).ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(EventsModel even)
        {
            var evens = _iEvent.GetAllEvents().FirstOrDefault(x => x.EventId == even.EventId);
            if (evens != null)
            {
                _iEvent.UpdateEvents(even);
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound(new { message = "Food item not found." });
            }
        }

        //public ActionResult FoodItemEvents(int? page)
        //{
        //    var model = new Model();



        //    model.PageSize = 7; // Số mục trên mỗi trang
        //    model.CurrentPage = page ?? 1; // Số trang hiện tại (nếu không có, mặc định là 1)


        //    model.FoodItemEvent = _iEvent.FoodItemEvents().ToPagedList(model.CurrentPage, model.PageSize);



        //    model.ListFoodItems = _iSpec.GetAllFoodItems();
        //    model.ListEvents = _iEvent.GetAllEvents();
        //    return View(model);
        //}

        //public ActionResult DeleteEvents(Guid id)
        //{
        //    var objEvent = _iEvent.FoodItemEvents().FirstOrDefault(x => x.FoodItemEventId == id);

        //    if (objEvent != null)
        //    {
        //        _iEvent.DeleteFoodItemEvent(objEvent.FoodItemEventId);
        //        return RedirectToAction("FoodItemEvents");
        //    }
        //    else
        //    {
        //        return NotFound(new { message = "Food item not found." });
        //    }
        //}

        //public ActionResult CreateFoodItemEvents(FoodItemEventsModel fe)
        //{
        //    _iEvent.Add_FoodItemEvents(fe);
        //    return RedirectToAction("FoodItemEvents");
        //}

        //public ActionResult CreateFoodItemEvent(Guid? selectedFoodCategory)
        //{
        //    var model = new Model();
        //    if (selectedFoodCategory.HasValue)
        //    {
        //        model.Select_ListFoodItems = _iEvent.GetFoodItemsByCategory(selectedFoodCategory.Value);
        //    }
        //    else
        //    {
        //        model.Select_ListFoodItems = _iEvent.GetAllFoodItems();
        //    }
        //    model.ListEvents = _iEvent.GetAllEvents();
        //        model.ListFoodItems = _iEvent.GetAllFoodItems();
        //        model.ListFoodCategories = _iEvent.GetAllFoodCategories();
        //        //model.ListFoodItems = _iSpec.GetAllFoodItems();
        //        return View(model);
            
        //}


        ////[HttpPost]
        ////public ActionResult ApproveReservations(List<Guid> selectedFoodItems)
        ////{
        ////    foreach (var reservationId in selectedFoodItems)
        ////    {
        ////        var reservation = _iReservation.GetReservationById(reservationId);
        ////        if (reservation != null)
        ////        {
        ////            var reservationModel = new ReservationModel();

        ////            reservationModel.ReservationId = reservation.ReservationsId;
        ////            reservationModel.Status = "Approved";
        ////            reservationModel.IsApproved = true;

        ////            _iReservation.UpdateApproveReservation(reservationModel);
        ////        }
        ////    }
        ////    return RedirectToAction("Index");
        ////}
    }
}
