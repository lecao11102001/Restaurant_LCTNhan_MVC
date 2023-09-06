namespace Restaurant_MVC.Models.ViewModels
{
    public class UpdateModel
    {
        public Guid CustomerId { get; set; }

        public string Name { get; set; }

        //Gender

        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Password { get; set; }
    }
}
