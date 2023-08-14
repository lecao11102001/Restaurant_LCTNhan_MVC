using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant_MVC.Interface;
using Restaurant_MVC.Models.ViewModels;
using System.Net.Mail;
using System.Net;
using AutoMapper;
using Restaurant_MVC.Service;

namespace Restaurant_MVC.Areas.Reservation.Controllers
{
    [Area("Reservation")]
    public class ReservationController : Controller
    {
        private readonly IReservation _ireservation;
        private readonly IMapper _mapper;

        public ReservationController(IReservation ireservation, IMapper mapper)
        {
            _ireservation = ireservation;
            _mapper = mapper;
        }
        // GET: ReservationController1
        public ActionResult Index()
        {
            //if (TempData.ContainsKey("SuccessReservation"))
            //{
            //    ViewBag.SuccessMessage = TempData["SuccessReservation"].ToString();
            //}
            return View();
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
