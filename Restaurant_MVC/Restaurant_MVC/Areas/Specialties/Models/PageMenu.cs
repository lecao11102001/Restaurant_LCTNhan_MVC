namespace Restaurant_MVC.Areas.Specialties.Models
{
    public class PagedMenu<T>
    {
        public List<T> Items { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
