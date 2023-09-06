namespace Restaurant_MVC.Areas.Admin.Models
{
    public class SpecialtiesModel
    {
        public Guid FoodCategoryId { get; set; }
        public Guid FoodItemId { get; set; }
        public string? Name { get; set;}
        public decimal? Price { get; set;}
        public string? Description { get; set;}
        public string? Images { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid? CreatedById { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? ModifiedById { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Guid? DeleteById { get; set; }
    }
}
