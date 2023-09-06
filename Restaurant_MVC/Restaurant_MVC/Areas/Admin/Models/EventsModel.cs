namespace Restaurant_MVC.Areas.Admin.Models
{
    public class EventsModel
    {
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal DiscountAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedById { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Guid ModifiedById { get; set; }
        public DateTime DeleteDate { get; set; }
        public Guid DeleteById { get; set; }
    }
}
