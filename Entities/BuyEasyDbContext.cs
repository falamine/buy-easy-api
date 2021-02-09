using Microsoft.EntityFrameworkCore;

namespace buy_easy_api.Entities
{
    public class BuyEasyDbContext: DbContext
    {
        public BuyEasyDbContext(DbContextOptions<BuyEasyDbContext> options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}