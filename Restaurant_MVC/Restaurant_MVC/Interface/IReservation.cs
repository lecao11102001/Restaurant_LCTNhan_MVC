using Restaurant_MVC.Areas.Admin.Models;
using Restaurant_MVC.Entities;
using Restaurant_MVC.Models.ReservationModels;

namespace Restaurant_MVC.Interface
{
    public interface IReservation
    {
        void AddMakeReservation(ReservationModel reservation);
        List<Restaurants> GetAllRestaurants();
        List<Reservation> GetAllReservation();
        List<Reservation> GetAllReservationss();
        List<Reservation> GetAllReservations();
        List<Reservation> Search_Reservation(string search);
        void DeleteReservation(Guid id);
        void AddReservation(Admin_ReservationModel reser); 
        void UpdateReservation(ReservationModel spec);
        public Reservation GetReservationById(Guid reservationId);
        public void UpdateApproveReservation(ReservationModel reservation);
    }
}
