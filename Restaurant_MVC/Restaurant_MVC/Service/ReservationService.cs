using AutoMapper;
using Restaurant_MVC.Areas.Reservation.Models;
using Restaurant_MVC.Interface;
using Restaurant_MVC.Entities;
using Restaurant_MVC.Models.SharedData;

namespace Restaurant_MVC.Service
{
    public class ReservationService : IReservation
    {
        private readonly RestaurantsDbContext _dbContext;
        private readonly IMapper _mapper;


        public ReservationService(RestaurantsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public void AddMakeReservation(ReservationModel reservation)
        {
            //var reservations = new Reservation
            //{
            //    ReservationsId = Guid.NewGuid(),
            //    CustomerId = reservation.CustomerId,
            //    Name = reservation.Name,
            //    Email = reservation.Email,
            //    Phone = reservation.Phone,
            //    Date = reservation.Date,
            //    Time = reservation.Time,
            //    NumberOfGuests = reservation.NumberOfGuests
            //};
            var reservations = _mapper.Map<Reservation>(reservation);

            _dbContext.Reservations.Add(reservations);
            _dbContext.SaveChanges();
        }

        public List<Restaurants> GetAllRestaurants()
        {
            return _dbContext.Restaurantss.ToList();
        }
    }
}
