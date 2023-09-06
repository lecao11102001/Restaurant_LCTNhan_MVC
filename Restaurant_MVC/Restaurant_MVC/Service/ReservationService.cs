using AutoMapper;
using Restaurant_MVC.Interface;
using Restaurant_MVC.Entities;
using Restaurant_MVC.Models.SharedData;
using Restaurant_MVC.Models.ReservationModels;
using Restaurant_MVC.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;

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
            var reservations = _mapper.Map<Reservation>(reservation);

            _dbContext.Reservations.Add(reservations);
            _dbContext.SaveChanges();
        }

        public void AddReservation(Admin_ReservationModel reser)
        {
            var map = _mapper.Map<Reservation>(reser);

            _dbContext.Add(map);
            _dbContext.SaveChanges();
        }

        public void DeleteReservation(Guid id)
        {
            var ReserDele = _dbContext.Reservations.FirstOrDefault(item => item.ReservationsId == id);

            if (ReserDele != null)
            {
                _dbContext.Reservations.Remove(ReserDele);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("Food item not found.");
            }
        }

        public List<Reservation> GetAllReservation()
        {
            return _dbContext.Reservations.ToList();
        }
        
        public List<Reservation> GetAllReservations()
        {
            return _dbContext.Reservations.Where(x=>x.IsApproved==true).ToList();
        }
        public List<Reservation> GetAllReservationss()
        {
            return _dbContext.Reservations.Where(x => x.IsApproved == false).ToList();
        }

        public List<Restaurants> GetAllRestaurants()
        {
            return _dbContext.Restaurantss.ToList();
        }

        public List<Reservation> Search_Reservation(string search)
        {
            return _dbContext.Reservations.Where(s => s.Name.Contains(search) || s.Email.Contains(search) || s.Phone == search).ToList();
        }

        public void UpdateReservation(ReservationModel reser)
        {
            var existingCate = _dbContext.Reservations.FirstOrDefault(x => x.ReservationsId == reser.ReservationId);

            if (existingCate != null)
            {
                _mapper.Map(reser, existingCate); // Cập nhật thông tin từ ReservationModel vào existingCate

                _dbContext.SaveChanges();
            }
        }
        public Reservation GetReservationById(Guid reservationId)
        {
            return _dbContext.Reservations.FirstOrDefault(r => r.ReservationsId == reservationId);
        }

        public void UpdateApproveReservation(ReservationModel reservation)
        {
            var existingReservation = _dbContext.Reservations.FirstOrDefault(r => r.ReservationsId == reservation.ReservationId);

            if (existingReservation != null)
            {
                existingReservation.Status = reservation.Status;
                existingReservation.IsApproved = reservation.IsApproved;
                // Cập nhật các thông tin khác tùy theo yêu cầu của bạn
                _dbContext.SaveChanges();
            }
        }
    }
}
