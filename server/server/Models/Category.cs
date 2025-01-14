using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Required]
        [StringLength(100)]
        public string? CategoryName { get; set; }

        public string? Description { get; set; }
    }
}
