using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant_MVC.Models;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace Restaurant_MVC.Controllers
{
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
            return View();
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> MakeReservation(ReservationModel model)
        {
            // Thêm vào database
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

            return View("Index");

        }

    }
}
