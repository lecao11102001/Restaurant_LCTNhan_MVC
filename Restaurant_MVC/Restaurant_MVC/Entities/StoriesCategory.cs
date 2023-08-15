using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant_MVC.Entities
{
    [Table("StoriesCategory")]
    public class StoriesCategory : BaseEntities
    {
        [Key]
        public Guid StoriesCategoryId { get; set; }

        [MaxLength(255)]
        public string? Name { get; set; }

        [InverseProperty("StoriesCategory")]
        public virtual ICollection<StoriesItem> StoriesItems { get; set; }
    }
}
