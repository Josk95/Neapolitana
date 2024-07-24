using Microsoft.EntityFrameworkCore;
using Naepolitana.Services.ProductAPI.Models;

namespace Naepolitana.Services.ProductAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }


        // Seed product Data ...
    }
}
