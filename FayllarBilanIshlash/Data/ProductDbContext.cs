using FayllarBilanIshlash.Models;
using Microsoft.EntityFrameworkCore;

namespace FayllarBilanIshlash.Data
{
    public class ProductDbContext : DbContext 
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }
        public virtual DbSet<Product> Products { get; set; }
    }
}
