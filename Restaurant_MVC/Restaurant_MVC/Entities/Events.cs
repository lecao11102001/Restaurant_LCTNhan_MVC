using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Restaurant_MVC.Common;

namespace Restaurant_MVC.Entities
{
    [Table("Events")]
    public class Events : BaseEntities
    {
        [Key]
        public Guid EventId { get; set; }

        [MaxLength(255)]
        public string? Name { get; set; }

        [MaxLength]
        public string? Code { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? DiscountAmount { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public ICollection<FoodItemEvent> FoodItemEvents { get; set; }
    }
}

