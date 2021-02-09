using System.ComponentModel.DataAnnotations.Schema;

namespace buy_easy_api.Entities
{
    [Table("User")]
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        
        public string Role { get; set; }
    }
}