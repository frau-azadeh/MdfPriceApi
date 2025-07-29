using Microsoft.EntityFrameworkCore;
using RebarPriceApi.Models;

namespace RebarPriceApi.Data
{
    public class RebarDbContext: DbContext
    {
        public RebarDbContext(DbContextOptions<RebarDbContext> options) : base(options) { }
        
        public DbSet<Product> Products { get; set; }
    }
}
