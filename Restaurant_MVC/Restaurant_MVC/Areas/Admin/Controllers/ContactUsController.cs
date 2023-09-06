using Microsoft.AspNetCore.Http;
using Restaurant_MVC.Common;
using Microsoft.AspNetCore.Mvc;
using Restaurant_MVC.Interface;
using Restaurant_MVC.Entities;
using X.PagedList;

namespace Restaurant_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactUsController : Controller
    {
        private readonly IContactUs _iContactUs;

        public ContactUsController(IContactUs iContactUs)
        {
            _iContactUs = iContactUs;
        }

        // GET: ContactUsController
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
                model.GetAllContactUs = _iContactUs.GetAllContacts().OrderByDescending(n => n.CreatedDate).ToPagedList(model.CurrentPage, model.PageSize);
            }
            else
            {
                model.GetAllContactUs = _iContactUs.Search_ContactUs(SearchString).OrderByDescending(n => n.CreatedDate).ToPagedList(model.CurrentPage, model.PageSize);
            }
            return View(model);
        }

        public ActionResult Details(Guid id)
        {
            var model = new Model();
            model.GetAllContactUss = _iContactUs.GetAllContacts().Where(x=>x.ContactUsId == id).ToList();

            return View(model);
        }

        public ActionResult Delete(Guid id)
        {
            var contact = _iContactUs.GetAllContacts().FirstOrDefault(x => x.ContactUsId == id);

            if (contact != null)
            {
                _iContactUs.DeleteContactUs(contact.ContactUsId);
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound(new { message = "Food item not found." });
            }
        }
    }
}
