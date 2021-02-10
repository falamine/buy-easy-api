using System.ComponentModel.DataAnnotations.Schema;

namespace buy_easy_api.Entities
{
    [Table("view_Cart")]
    public class ProductView
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        
    }
}