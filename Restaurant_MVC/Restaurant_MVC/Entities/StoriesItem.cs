using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant_MVC.Entities
{
    [Table("StoriesItem")]
    public class StoriesItem : BaseEntities
    {
        [Key]
        public Guid StoriesItemId { get; set; }

        public Guid StoriesCategoryId { get; set; }

        [MaxLength(255)]
        public string? Name { get; set; }

        [MaxLength]
        public string? Image { get; set; }

        [MaxLength]
        public string? ShortDescription { get; set; }
        
        [MaxLength]
        public string? LongDescription { get; set; }

        public int? Viewer { get; set; }

        public int? Comments { get; set; }

        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }
        
        [ForeignKey("StoriesCategoryId")]    
        public virtual StoriesCategory StoriesCategory { get; set; }
    }
}
