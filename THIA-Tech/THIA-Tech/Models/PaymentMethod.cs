using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace THIA_Tech.Models
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
