using System.ComponentModel.DataAnnotations.Schema;

namespace THIA_Tech.Models
{
    public class Product : ProductPrototype
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }

        [ForeignKey("Category")]
        public int CategoryId;
        public Category Category { get; set; }

        public ProductPrototype Clone()
        {
            return(ProductPrototype)MemberwiseClone();
        }
    }
}
