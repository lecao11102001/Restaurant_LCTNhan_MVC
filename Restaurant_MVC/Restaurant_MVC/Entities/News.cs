using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Restaurant_MVC.Common;

namespace Restaurant_MVC.Entities
{
    [Table("News")]
    public class News : BaseEntities
    {
        [Key]
        public Guid NewId { get; set; }

        [MaxLength(255)]
        public string? Title { get; set; }

        [MaxLength]
        public string? Image { get; set; }

        [MaxLength]
        public string? ShortDescription { get; set; }
        
        [MaxLength]
        public string? LongDescription { get; set; }

        public int? Viewer { get; set; }

        public int? Comments { get; set; }
    }
}
