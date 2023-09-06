using Restaurant_MVC.Areas.Admin.Models;
using Restaurant_MVC.Common;
using Restaurant_MVC.Entities;

namespace Restaurant_MVC.Interface
{
    public interface INews
    {
        List<Restaurants> GetAllRestaurants();
        List<News> GetAllNews();
        List<News> Search_News(string search);
        public void Add_News(NewsModel news);
        public void DeleteNews(Guid id);
    }
}
