using Restaurant_MVC.Areas.Reservation.Models;
using Restaurant_MVC.Entities;

namespace Restaurant_MVC.Interface
{
    public interface IReservation
    {
        void AddMakeReservation(ReservationModel reservation);
        List<Restaurants> GetAllRestaurants();
    }
}
