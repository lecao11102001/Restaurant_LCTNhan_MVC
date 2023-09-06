using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Restaurant_MVC.Areas.Admin.Models;
using Restaurant_MVC.Common;
using Restaurant_MVC.Entities;
using Restaurant_MVC.Interface;

namespace Restaurant_MVC.Service
{
    public class NewsService : INews
    {
        private readonly RestaurantsDbContext _restaurantsDb;
        public readonly IMapper _mapper;

        public NewsService(RestaurantsDbContext restaurantsDb, IMapper mapper)
        {
            _restaurantsDb = restaurantsDb;
            _mapper = mapper;
        }

        public List<News> GetAllNews()
        {
            return _restaurantsDb.Newss.ToList();
        }

        public List<Restaurants> GetAllRestaurants()
        {
            return _restaurantsDb.Restaurantss.ToList();
        }

        public List<News> Search_News(string search)
        {
            return _restaurantsDb.Newss.Where(x=>x.Title.Contains(search)).ToList();
        }

        public void Add_News(NewsModel news)
        {
            var newss = _mapper.Map<News>(news);

            _restaurantsDb.Add(newss);
            _restaurantsDb.SaveChanges();
        }

        public void DeleteNews(Guid id)
        {
            var NewsToDelete = _restaurantsDb.Newss.FirstOrDefault(item => item.NewId == id);

            if (NewsToDelete != null)
            {
                _restaurantsDb.Newss.Remove(NewsToDelete);
                _restaurantsDb.SaveChanges();
            }
            else
            {
                throw new Exception("Food item not found.");
            }
        }
    }
}
