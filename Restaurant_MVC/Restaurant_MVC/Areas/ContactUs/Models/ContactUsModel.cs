namespace Restaurant_MVC.Areas.ContactUs.Models
{
    public class ContactUsModel
    {
        public Guid CustomerId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }
    }
}
