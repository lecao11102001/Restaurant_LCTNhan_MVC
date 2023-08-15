namespace Restaurant_MVC.Areas.Reservation.Models
{
    public class ReservationModel
    {
        public Guid CustomerId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime Date { get; set; }

        public DateTime Time { get; set; }

        public int NumberOfGuests { get; set; }
    }
}
