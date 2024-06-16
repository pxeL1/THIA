using System.ComponentModel.DataAnnotations.Schema;

namespace THIA_Tech.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        public string Content { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
