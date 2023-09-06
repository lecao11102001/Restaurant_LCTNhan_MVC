using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Restaurant_MVC.Models.SharedData;
using Restaurant_MVC.Interface;
using Restaurant_MVC.Common;
using Restaurant_MVC.Entities;
using Restaurant_MVC.Models.ViewModels;
using X.PagedList;

namespace Restaurant_MVC.Controllers.Home
{

    public class HomeController : Controller
    {
        private readonly IDataSharingService _dataSharingService;
        private readonly RestaurantsDbContext _restaurantsDbContext;
        private readonly IHome _iHome;

        public HomeController(IHome iHome, RestaurantsDbContext restaurantsDbContext, IDataSharingService dataSharingService)
        {
            _restaurantsDbContext = restaurantsDbContext;
            _dataSharingService = dataSharingService;
            _iHome = iHome;
        }

        public ActionResult Index(int? page)
        {
            var model = new Model();

            model.PageSize = 2; // Số mục trên mỗi trang
            model.CurrentPage = page ?? 1; // Số trang hiện tại (nếu không có, mặc định là 1)
            model.ListEvent = _iHome.GetAllEvent().OrderByDescending(n => n.CreatedDate).ToPagedList(model.CurrentPage, model.PageSize);

            model.ListFoodCategories = _iHome.GetAllFoodCategories();
            //model.listMenu = _iHome.GetAllMenu();

            model.Restaurants = _iHome.GetAllRestaurants();
            return View(model);
        }

        public IActionResult Login()
        {
            var model = new Model();
            model.Restaurants = _iHome.GetAllRestaurants();

            return View(model);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetAllLogin()
        {
            return _restaurantsDbContext.Customers.ToList();

        }

        //POST: Login
        [HttpPost]
        public ActionResult Login(LoginModel login)
        {
            var data = _restaurantsDbContext.Customers.Where(s => s.UserName.Equals(login.Username) && s.PassWord.Equals(login.Password)).ToList();
            if (data.Count() > 0)
            {
                _dataSharingService.SetSharedData("username", data.FirstOrDefault().UserName);
                _dataSharingService.SetSharedData("customerId", data.FirstOrDefault().CustomerId.ToString());
                _dataSharingService.SetSharedData("password", data.FirstOrDefault().PassWord);
                _dataSharingService.SetSharedData("customerid", data.FirstOrDefault().CustomerId.ToString());
                _dataSharingService.SetSharedData("name", data.FirstOrDefault().Name);
                _dataSharingService.SetSharedData("gender", data.FirstOrDefault().Gender.ToString());
                _dataSharingService.SetSharedData("address", data.FirstOrDefault().Address);
                _dataSharingService.SetSharedData("phone", data.FirstOrDefault().Phone);
                _dataSharingService.SetSharedData("email", data.FirstOrDefault().Email);
                _dataSharingService.SetSharedData("dateofbirth", data.FirstOrDefault().DateOfBirth.ToString());
                _dataSharingService.SetSharedData("role", data.FirstOrDefault().Role);

                if (_dataSharingService.GetSharedData("role") == "Admin")
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                return RedirectToAction("Index");
            }
            _dataSharingService.SetSharedData("noti_err", "username or password incorrect");
            return RedirectToAction("Login");
        }

        public IActionResult Registry()
        {
            var model = new Model();
            model.Restaurants = _iHome.GetAllRestaurants();

            return View(model);
        }

        //POST: Register
        [HttpPost]
        public ActionResult Registry(RegistryModel registry)
        {
            if (ModelState.IsValid)
            {
                var account = _restaurantsDbContext.Customers.FirstOrDefault(s => s.UserName == registry.Username);

                if (account == null)
                {
                    var cus = new Customer
                    {
                        CustomerId = Guid.NewGuid(),
                        Name = registry.Name,
                        Gender = registry.Gender,
                        Address = registry.Address,
                        Phone = registry.Phone,
                        Email = registry.Email,
                        DateOfBirth = registry.DateOfBirth.Date,
                        UserName = registry.Username,
                        PassWord = registry.Password,
                        Role = "Customer",
                    };
                    _restaurantsDbContext.Customers.Add(cus);
                    _restaurantsDbContext.SaveChanges();

                    return RedirectToAction("Login");
                }
                else
                {
                    return View("Registry");
                }
            }
            return View("Registry");
        }

        public ActionResult Logout()
        {
            _dataSharingService.ClearShareData("username");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Customer_Info()
        {

            //_dataSharingService.GetSharedData("customerId");

            var model = new Model();
            model.Restaurants = _iHome.GetAllRestaurants();
            model.GetAllCustomers = _iHome.GetAllCustomer();

            return View(model);
        }

        [HttpPost]
        public ActionResult Customer_Info(UpdateModel edit)
        {

            var cus = _iHome.GetAllCustomer().FirstOrDefault(s => s.CustomerId == edit.CustomerId);

            if (cus != null)
            {
                _iHome.UpdateCustomers(edit);
                return RedirectToAction("Customer_Info");
            }
            else
            {
                return View("Customer_Info");
            }

            return View();
        }
    }
}