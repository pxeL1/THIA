using System.ComponentModel.DataAnnotations.Schema;

namespace THIA_Tech.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int Count { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
