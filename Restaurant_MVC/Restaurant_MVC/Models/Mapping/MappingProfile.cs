using AutoMapper;
using Restaurant_MVC.Areas.Admin.Models;
using Restaurant_MVC.Entities;
using Restaurant_MVC.Models.ContactUsModels;
using Restaurant_MVC.Models.ReservationModels;
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
            
            CreateMap<FoodItem, SpecialtiesModel>();
            CreateMap<SpecialtiesModel, FoodItem>();

            CreateMap<FoodCategory, CategoriesModel>();
            CreateMap<CategoriesModel, FoodCategory>();

            CreateMap<Reservation, Admin_ReservationModel>();
            CreateMap<Admin_ReservationModel, Reservation>();

            CreateMap<Events, EventsModel>();
            CreateMap<EventsModel, Events>();

            CreateMap<News, NewsModel>();
            CreateMap<NewsModel, News>();

            CreateMap<Customer, UpdateModel>();
            CreateMap<UpdateModel, Customer>();

            CreateMap<FoodItemEvent, FoodItemEventsModel>();
            CreateMap<FoodItemEventsModel, FoodItemEvent>();
        }
    }
}
