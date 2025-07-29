using Microsoft.EntityFrameworkCore;
using RebarPriceApi.Models;

namespace RebarPriceApi.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<Product> Products { get; set; }
    }
}
