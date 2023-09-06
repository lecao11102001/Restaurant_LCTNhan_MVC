using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using Restaurant_MVC.Common;
using Restaurant_MVC.Interface;
using Restaurant_MVC.Areas.Admin.Models;
using Restaurant_MVC.Entities;
using Restaurant_MVC.Models.ReservationModels;
using Restaurant_MVC.Service;
using System.Net.Mail;
using System.Net;

namespace Restaurant_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReservationController : Controller
    {

        private readonly IReservation _iReservation;

        public ReservationController(IReservation iReservation)
        {
            _iReservation = iReservation;
        }

        // GET: ReservationController
        public ActionResult Index(string currentFilter, string SearchString, int? page, int? page1)
        {
            var model = new Model();

            if (SearchString != null)
            {
                page = 1;
                page1 = 1;
            }
            else
            {
                SearchString = currentFilter;
            }

            model.CurrentFilter = SearchString;
            model.PageSize = 10; // Số mục trên mỗi trang
            //model.PageSize1 = 10;
            model.CurrentPage = page ?? 1; // Số trang hiện tại (nếu không có, mặc định là 1)
            model.CurrentPage1 = page1 ?? 1; 

            if (SearchString == null)
            {
                model.GetAllReservation = _iReservation.GetAllReservationss().OrderByDescending(n => n.CreatedDate).ToPagedList(model.CurrentPage, model.PageSize);
                model.GetAllReservationss = _iReservation.GetAllReservations().OrderByDescending(n => n.CreatedDate).ToPagedList(model.CurrentPage1, model.PageSize);
            }
            else
            {
                model.GetAllReservation = _iReservation.Search_Reservation(SearchString).OrderByDescending(n => n.CreatedDate).ToPagedList(model.CurrentPage, model.PageSize);
                model.GetAllReservationss = _iReservation.Search_Reservation(SearchString).OrderByDescending(n => n.CreatedDate).ToPagedList(model.CurrentPage1, model.PageSize);
            }

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Admin_ReservationModel modal)
        {
            _iReservation.AddReservation(modal);
            return RedirectToAction("Index");
        }

        public ActionResult Details(Guid id)
        {
            var model = new Model();
            model.GetAllReservations = _iReservation.GetAllReservation().Where(x => x.ReservationsId == id).ToList();

            return View(model);
        }

        public ActionResult Delete(Guid id)
        {
            var Reser = _iReservation.GetAllReservation().FirstOrDefault(x => x.ReservationsId == id);
            if (Reser != null)
            {
                _iReservation.DeleteReservation(Reser.ReservationsId);

                // Gửi email thành công
                var fromEmail = "lecao11102001@gmail.com";
                var subject = "Đăng ký thất bại";

                var body = $"Quý Khách đăng ký không thành công !!!. Chi tiết: Tên khách hàng: {Reser.Name},Ngày đặt: {Reser.Date?.ToString("dd/MM/yyyy")},Thời gian: {Reser.Time?.ToString("HH:mm:ss")}, Số lượng khách: {Reser.NumberOfGuests}. Vui lòng đăng ký lại !!!";

                MailMessage message = new MailMessage(fromEmail, Reser.Email, subject, body);

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential(fromEmail, "isyplpdlymprdygn");

                smtpClient.SendMailAsync(message);

                return RedirectToAction("Index");
            }
            else
            {
                return NotFound(new { message = "Food item not found." });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var model = new Model();
            model.GetAllReservations = _iReservation.GetAllReservation().Where(x => x.ReservationsId == id).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ReservationModel reser)
        {
            var food = _iReservation.GetAllReservation().FirstOrDefault(x => x.ReservationsId == reser.ReservationId);
            if (food != null)
            {
                _iReservation.UpdateReservation(reser);
                return RedirectToAction("Edit");
            }
            else
            {
                return NotFound(new { message = "Food item not found." });
            }
        }

        [HttpPost]
        public ActionResult ApproveReservations(List<Guid> selectedReservations)
        {
            foreach (var reservationId in selectedReservations)
            {
                var reservation = _iReservation.GetReservationById(reservationId);
                if (reservation != null)
                {
                    var reservationModel = new ReservationModel();

                    reservationModel.ReservationId = reservation.ReservationsId;
                    reservationModel.Status = "Approved";
                    reservationModel.IsApproved = true;

                    _iReservation.UpdateApproveReservation(reservationModel);
                }

                // Gửi email thành công
                var fromEmail = "lecao11102001@gmail.com";
                var subject = "Xác nhận đã đăng ký thành công";

                var body = $"Thông tin của Quý Khách !!!. Chi tiết: Tên khách hàng: {reservation.Name},Ngày đặt: {reservation.Date?.ToString("dd/MM/yyyy")},Thời gian: {reservation.Time?.ToString("HH:mm:ss")}, Số lượng khách: {reservation.NumberOfGuests}. Vui lòng đến đúng thời gian đã đăng ký !!!";

                MailMessage message = new MailMessage(fromEmail, reservation.Email, subject, body);

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential(fromEmail, "isyplpdlymprdygn");

                smtpClient.SendMailAsync(message);
            }

            return RedirectToAction("Index");
        }
    }
}
