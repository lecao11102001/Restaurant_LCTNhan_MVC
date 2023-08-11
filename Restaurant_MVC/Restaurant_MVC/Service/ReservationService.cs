using Restaurant_MVC.Interface;
using Restaurant_MVC.Models.Entities;
using Restaurant_MVC.Models.SharedDataDictionary;
using Restaurant_MVC.Models.ViewModels;

namespace Restaurant_MVC.Service
{
    public class ReservationService : IReservation
    {
        private readonly RestaurantsDbContext _dbContext;

        public ReservationService(RestaurantsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddMakeReservation(ReservationModel reservation)
        {
            var reservations = new Reservation
            {
                ReservationsId = Guid.NewGuid(),
                CustomerId = reservation.CustomerId,
                Name = reservation.Name,
                Email = reservation.Email,
                Phone = reservation.Phone,
                Date = reservation.Date,
                Time = reservation.Time,
                NumberOfGuests = reservation.NumberOfGuests
            };
            _dbContext.Reservations.Add(reservations);
            _dbContext.SaveChanges();
        }
    }
}
