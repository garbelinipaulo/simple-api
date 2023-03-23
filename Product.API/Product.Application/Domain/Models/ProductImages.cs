using System.ComponentModel.DataAnnotations;

namespace Product.Application.Domain.Models
{ 
    public class ProductImages
    {
        [Key]
        public long ImageId { get; set; }
        public long ProductId { get; set; }
        public string? ImageUrl { get; set; }

        /// <summary>
        /// Auxiliar variable for base64 strings
        /// </summary>
        public string? ImageBase64 { get; set; }
    }
}
