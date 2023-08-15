namespace Restaurant_MVC.Entities
{
    public class BaseEntities
    {
        public DateTime? CreatedDate { get; set; }

        public Guid? CreatedById { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public Guid? ModifiedById { get; set; }

        public DateTime? DeleteDate { get; set; }

        public Guid? DeleteById { get; set; }
    }
}
