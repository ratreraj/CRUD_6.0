using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GoodBooksWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="Please enter the vale between range of 1 to 100 !!")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

    }
}
