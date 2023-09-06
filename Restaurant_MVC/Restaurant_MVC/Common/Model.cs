using Restaurant_MVC.Entities;
using X.PagedList;

namespace Restaurant_MVC.Common
{
    public class Model
    {
        public List<FoodCategory> ListFoodCategories { get; set; }
        public List<Restaurants> Restaurants { get; set; }

        public List<Customer> GetAllCustomers { get; set; }

        public List<FoodItem>? ListFoodItems { get; set; }
        public List<FoodItem>? Select_ListFoodItems { get; set; }
        public IPagedList<FoodItem>? ListFoodItem { get; set; }
        public IPagedList<FoodItem>? Select_ListFoodItem { get; set; }

        public int CurrentPage { get; set; }    //Page hiện tại
        public int CurrentPage1 { get; set; }    //Page hiện tại
        public int PageSize { get; set; }   // Số sản phẩm trên 1 trang
        public int PageSize1 { get; set; }   // Số sản phẩm trên 1 trang
        public string CurrentFilter { get; set; }

        public List<MenuCategory> listMenu { get; set; }
        
        public List<News> ListNews { get; set; }
        public IPagedList<News>? ListNew { get; set; }
        
        public List<Events> ListEvents { get; set; }
        public IPagedList<Events>? ListEvent { get; set; }


        public List <Reservation> GetAllReservations {  get; set; }
        public IPagedList<Reservation>? GetAllReservation { get; set; }
        public IPagedList<Reservation>? GetAllReservationss { get; set; }

        public List<ContactUs> GetAllContactUss { get; set; }
        public IPagedList<ContactUs>? GetAllContactUs { get; set; }

        public List<FoodItemEvent>? FoodItemEvents { get; set; }
        public IPagedList<FoodItemEvent>? FoodItemEvent { get; set; }
    }
}
