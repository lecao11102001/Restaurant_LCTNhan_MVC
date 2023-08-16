using Microsoft.AspNetCore.Mvc;
using Restaurant_MVC.Interface;
using Restaurant_MVC.Common;
using System.Net.Mail;
using System.Net;
using Restaurant_MVC.Areas.Reservation.Models;

namespace Restaurant_MVC.Areas.Reservation.Controllers
{
    [Area("Reservation")]
    public class ReservationController : Controller
    {
        private readonly IReservation _ireservation;

        public ReservationController(IReservation ireservation)
        {
            _ireservation = ireservation;
        }
        // GET: ReservationController1
        public ActionResult Index()
        {
            var model = new Model();
            model.Restaurants = _ireservation.GetAllRestaurants();
            return View(model);
        }

        public async Task<IActionResult> MakeReservation(ReservationModel model)
        {
            // Thêm vào database
            //_ireservation.AddMakeReservation(model);

            // Map the Reservation object to ReservationDto using AutoMapper
            //var reservationDto = _mapper.Map<ReservationModel>(model);

            // Pass the mapped ReservationDto to the service for processing
            _ireservation.AddMakeReservation(model);

            // Gửi email xác nhận
            var fromEmail = "lecao11102001@gmail.com";
            var subject = "Xác nhận đăng ký thành công";

            var body = $"Đã ghi nhận thông tin của Quý Khách !!!. Chi tiết: Tên khách hàng: {model.Name},Ngày đặt: {model.Date.ToString("dd/MM/yyyy")},Thời gian: {model.Time.ToString("HH:mm:ss")}, Số lượng khách: {model.NumberOfGuests}. Hãy chờ đợi duyệt !!!";

            MailMessage message = new MailMessage(fromEmail, model.Email, subject, body);

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(fromEmail, "isyplpdlymprdygn");

            smtpClient.SendMailAsync(message);

            //TempData["SuccessReservation"] = "Đặt bàn thành công! Hãy chờ xác nhận từ chúng tôi.";

            return View("Index");

        }

    }
}
