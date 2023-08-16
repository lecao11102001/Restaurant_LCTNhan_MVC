using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant_MVC.Entities
{
    [Table("Events")]
    public class Events : BaseEntities
    {
        [Key]
        public Guid EventId { get; set; }

        [MaxLength(255)]
        public string? Title { get; set; }

        [MaxLength]
        public string? Image { get; set; }

        [MaxLength (255)]
        public string? Description { get; set; }

        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }
    }
}
