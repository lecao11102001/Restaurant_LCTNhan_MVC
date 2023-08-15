using AutoMapper;
using Restaurant_MVC.Areas.ContactUs.Models;
using Restaurant_MVC.Areas.Reservation.Models;
using Restaurant_MVC.Entities;

namespace Restaurant_MVC.Models.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Reservation, ReservationModel>();
            CreateMap<ReservationModel, Reservation>();

            CreateMap<ContactUs, ContactUsModel>();
            CreateMap<ContactUsModel, ContactUs>();
        }
    }
}
