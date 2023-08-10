using Restaurant_MVC.Data;
using Restaurant_MVC.Models.SharedDataDictionary;

namespace Restaurant_MVC.Models
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
