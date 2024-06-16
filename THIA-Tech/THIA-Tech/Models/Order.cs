using System.ComponentModel.DataAnnotations.Schema;

namespace THIA_Tech.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public DateTime OrderDate { get; set; }

        public IEnumerable<CartItem> Items { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
