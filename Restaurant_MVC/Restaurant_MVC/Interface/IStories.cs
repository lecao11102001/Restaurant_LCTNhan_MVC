using Restaurant_MVC.Common;
using Restaurant_MVC.Entities;

namespace Restaurant_MVC.Interface
{
    public interface IStories
    {
        List<Restaurants> GetAllRestaurants();

        Page<News> GetPageStoriesItems(int page);

    }
}
