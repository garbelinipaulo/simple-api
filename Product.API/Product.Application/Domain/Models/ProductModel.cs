using System.ComponentModel.DataAnnotations;

namespace Product.Application.Domain.Models
{
    public class ProductModel
    {   
        public ProductModel() {
            ProductImages = new List<ProductImages>();
        }

        [Key]
        public long ProductId { get; set; }

        [Required]
        [MaxLength(1000)]
        public string? ProductName { get; set; }

        [Required]
        [MaxLength(3000)]
        public string? ProductDescription { get; set; }
        public decimal Price { get; set; }
        public decimal Stock { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; } 
        public List<ProductImages> ProductImages { get; set; }
    }
}
