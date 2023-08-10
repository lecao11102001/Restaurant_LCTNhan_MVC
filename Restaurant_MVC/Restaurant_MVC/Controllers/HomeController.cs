using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using Restaurant_MVC.Data;
using Restaurant_MVC.Models;
using System.Net;
using Restaurant_MVC.Models.SharedDataDictionary;
using Microsoft.AspNetCore.Authorization;

namespace Restaurant_MVC.Controllers
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

        public IActionResult Index()
        {
            //var menuItems = new List<string> {"About", "Specialties", "Stories", "Reservation", "ContactUs" };

            //var result = new ModelModel();
            //result.listMenu = menuItems;
            //result.ListFoodCategories = _restaurantsDbContext.FoodCategories.ToList();

            var allFoodCategories = _iHome.GetAllFoodCategories();
            var allFoodItems = _iHome.GetAllFoodItems();

            var model = new ModelModel
            {
                ListFoodCategories = allFoodCategories,
                ListFoodItems = allFoodItems
            };

            return View(model);
        }

        public IActionResult Login()
        {
            return View();
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
                _dataSharingService.SetSharedData("password", data.FirstOrDefault().PassWord);
                _dataSharingService.SetSharedData("customerid", data.FirstOrDefault().CustomerId.ToString());
                _dataSharingService.SetSharedData("name", data.FirstOrDefault().Name);
                _dataSharingService.SetSharedData("gender", data.FirstOrDefault().Gender.ToString());
                _dataSharingService.SetSharedData("address", data.FirstOrDefault().Address);
                _dataSharingService.SetSharedData("phone", data.FirstOrDefault().Phone);
                _dataSharingService.SetSharedData("email", data.FirstOrDefault().Email);
                _dataSharingService.SetSharedData("dateofbirth", data.FirstOrDefault().DateOfBirth.ToString());
                _dataSharingService.SetSharedData("role", data.FirstOrDefault().Role);

                return RedirectToAction("Index");
            }
            _dataSharingService.SetSharedData("noti_err", "username or password incorrect");
            return RedirectToAction("Login");
        }

        public IActionResult Registry()
        {
            return View();
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
                        Role = "Khách hàng",
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
            return View();
        }

        public ActionResult Logout()
        {
            _dataSharingService.ClearShareData("username");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Customer_Info()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Customer_Info(UpdateModel edit)
        {
            if (ModelState.IsValid)
            {
                var cus = _restaurantsDbContext.Customers.FirstOrDefault(s => s.CustomerId == edit.CustomerId);

                if (cus != null)
                {
                    if (cus.CustomerId == edit.CustomerId)
                    {
                        cus.Name = edit.Name;
                        //Gender = edit.Gender,
                        cus.Address = edit.Address;
                        cus.Phone = edit.Phone;
                        cus.Email = edit.Email;
                        //DateOfBirth = edit.DateOfBirth,
                        cus.PassWord = edit.Password;
                        _dataSharingService.SetSharedData("password", edit.Password);

                    }
                    _restaurantsDbContext.Customers.Update(cus);
                    _restaurantsDbContext.SaveChanges();

                    return RedirectToAction("Customer_Info");
                }
                else
                {
                    return View("Customer_Info");
                }
            }
            return View();
        }
    }
}