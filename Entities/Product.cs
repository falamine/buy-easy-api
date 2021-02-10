using System;
using System.ComponentModel.DataAnnotations.Schema;
using buy_easy_api.Enum;

namespace buy_easy_api.Entities
{
    [Table("Product")]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProductType Type { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Brand { get; set; } 
        public int UserId { get; set; }
        
    }
}