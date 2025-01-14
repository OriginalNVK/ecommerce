using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [StringLength(200)]
        public string? ProductName { get; set; }

        public string? ProductDescription { get; set; }

        [Required]
        [Column(TypeName ="decimal(18,2)")]
        public decimal? OldPrice { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? NewPrice { get; set; }

        [Required]
        public int StockQuantity { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public string? ImagePath { get; set; }
    }
}
