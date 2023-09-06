namespace Restaurant_MVC.Areas.Admin.Models
{
    public class CategoriesModel
    {
        public Guid CategoryId { get; set; }
        public string? Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid? CreatedById { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? ModifiedById { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Guid? DeleteById { get; set; }
    }
}
