namespace THIA_Tech.Models
{
    public class CartItemViewModel
    {
        public int cartItemId { get; set; }
        public int count { get; set; }
        public string address { get; set; } = string.Empty;
    }
}
