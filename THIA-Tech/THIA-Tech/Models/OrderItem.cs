﻿using System.ComponentModel.DataAnnotations.Schema;

namespace THIA_Tech.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int Count { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
