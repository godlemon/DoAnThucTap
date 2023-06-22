using DoAnThucTap.Areas.Admin.Models;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using static System.Reflection.Metadata.BlobBuilder;

namespace DoAnThucTap.Models
{
    public class ADbContext : DbContext
    {
        public ADbContext(DbContextOptions<ADbContext> options) : base(options) { }
        public DbSet<Camera> Cameras { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Tags> Tags { get; set; }
		public DbSet<Warehouses> Warehousess { get; set; }
		public DbSet<Menu> Menus { get; set; }
		public DbSet<Banner> banners { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<CartItem>()
                .Property(ci => ci.TotalAmount)
                .HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasColumnType("decimal(18, 2)");
			modelBuilder.Entity<Warehouses>()
		        .Property(w => w.PriceBuy)
		        .HasColumnType("decimal(18,2)");
			modelBuilder.Entity<Warehouses>()
				.Property(w => w.PriceSell)
				.HasColumnType("decimal(18,2)");
		}
    }
}
