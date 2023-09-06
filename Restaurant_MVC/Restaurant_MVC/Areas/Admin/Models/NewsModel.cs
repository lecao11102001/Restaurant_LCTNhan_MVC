namespace Restaurant_MVC.Areas.Admin.Models
{
    public class NewsModel
    {
        public string Title { get; set; }

        public string Images { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public int Viewer { get; set; }

        public int Comments { get; set;}
        public DateTime? CreatedDate { get; set; }
        public Guid? CreatedById { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? ModifiedById { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Guid? DeleteById { get; set; }
    }
}
