using Restaurant_MVC.Models.ViewModels;

namespace Restaurant_MVC.Interface
{
    public interface IContactUs
    {
        Task<bool> SendMessage(ContactUsModel contactmodel);
    }
}
