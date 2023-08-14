using AutoMapper;
using Restaurant_MVC.Models.Entities;
using Restaurant_MVC.Models.ViewModels;

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
