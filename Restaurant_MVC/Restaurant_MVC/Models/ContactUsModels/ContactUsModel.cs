namespace Restaurant_MVC.Models.ContactUsModels
{
    public class ContactUsModel
    {
        public Guid CustomerId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
