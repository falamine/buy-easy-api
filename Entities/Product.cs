using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace buy_easy_api.Entities
{
    [Table("Product")]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public bool IsInStock { get; set; }
        public bool IsOnSale { get; set; }
        public string Brand { get; set; } 
        public int UserId { get; set; }
        
    }
}