using Microsoft.AspNetCore.Mvc;
using Restaurant_MVC.Interface;
using Restaurant_MVC.Common;
using Restaurant_MVC.Entities;
using X.PagedList;
using Microsoft.CodeAnalysis;
using Restaurant_MVC.Service;

namespace Restaurant_MVC.Controllers.Specialties
{
    public class SpecialtiesController : Controller
    {
        private readonly ISpecialties _iSpecialties;
        private readonly IEvents _iEvents;
        private readonly IFoodItemEvents _foodItemEvents;

        public SpecialtiesController(ISpecialties iSpecialties, IEvents iEvents, IFoodItemEvents foodItemEvents)
        {
            _iSpecialties = iSpecialties;
            _iEvents = iEvents;
            _foodItemEvents = foodItemEvents;
        }
        // GET: Specialties
        public ActionResult Index(int? page, Guid? foodcategoryid)
        {
            var model = new Model();

            if (foodcategoryid.HasValue)
            {
                ViewBag.FoodCategoryId = foodcategoryid;
                model.PageSize = 9; // Số mục trên mỗi trang
                model.CurrentPage = page ?? 1; // Số trang hiện tại (nếu không có, mặc định là 1)
                model.Select_ListFoodItem = _iSpecialties.GetFoodItemsByCategory(foodcategoryid).OrderByDescending(n => n.CreatedDate).ToPagedList(model.CurrentPage, model.PageSize);
            }
            else
            {
                model.PageSize = 9; 
                model.CurrentPage = page ?? 1;
                model.Select_ListFoodItem = _iSpecialties.GetAllFoodItems().OrderByDescending(n => n.CreatedDate).ToPagedList(model.CurrentPage, model.PageSize);
            }


            //model.ListFoodItem = _iSpecialties.GetAllFoodItems().OrderByDescending(n => n.CreatedDate).ToPagedList(model.CurrentPage, model.PageSize);

            var activeEvents = _iEvents.GetActiveEvents(); // Lấy danh sách sự kiện giảm giá đang diễn ra
            foreach (var ev in activeEvents)
            {
                var foodItemsInEvent = _foodItemEvents.GetAllFoodItemEvents().Where(x => x.EventId == ev.EventId).Select(x => x.FoodItem);

                foreach (var item in foodItemsInEvent)
                {
                    if (item != null && ev != null)
                    {
                        item.DiscountedPrice = item.Price * ev.DiscountAmount;
                        item.DiscountAmount = ev.DiscountAmount * 100;
                    }
                }

            }

            model.Restaurants = _iSpecialties.GetAllRestaurants();
            model.ListFoodCategories = _iSpecialties.GetAllFoodCategories();

            return View(model);
        }
    }
}