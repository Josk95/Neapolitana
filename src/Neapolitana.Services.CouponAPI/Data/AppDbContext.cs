using Microsoft.EntityFrameworkCore;
using Neapolitana.Services.CouponAPI.Models;

namespace Neapolitana.Services.CouponAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {   
        }

        public DbSet<Coupon> Coupons => Set<Coupon>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coupon>().HasData(new Coupon()
            {
                Id = 1,
                Code = "10OFF",
                Discount = 10,
                MinimumAmount = 20
            });

            modelBuilder.Entity<Coupon>().HasData(new Coupon()
            {
                Id = 2,
                Code = "20OFF",
                Discount = 20,
                MinimumAmount = 20
            });

            modelBuilder.Entity<Coupon>().HasData(new Coupon()
            {
                Id = 3,
                Code = "20OFF",
                Discount = 20,
                MinimumAmount = 20
            });
        }
    }
}
