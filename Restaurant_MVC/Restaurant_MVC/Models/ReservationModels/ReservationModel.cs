namespace Restaurant_MVC.Models.ReservationModels
{
    public class ReservationModel
    {
        public Guid ReservationId { get; set; }
        public Guid CustomerId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime Date { get; set; }

        public DateTime Time { get; set; }

        public int NumberOfGuests { get; set; }
        public string Status { get; set; }
        public bool IsApproved { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid? CreatedById { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? ModifiedById { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Guid? DeleteById { get; set; }
    }
}
