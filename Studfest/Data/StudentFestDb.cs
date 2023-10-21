using Microsoft.EntityFrameworkCore;
using Studfest.Models;

namespace Studfest.Data
{
    public class StudentFestDb : DbContext
    {

        public StudentFestDb(DbContextOptions options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne<Vendor>(i => i.Vendor)
                .WithMany(g => g.Products)
                .HasForeignKey(v => v.VendorId);

            modelBuilder.Entity<OrderItem>()
                .HasOne<Product>(a => a.Product)
                .WithMany(y => y.OrderItems)
                .HasForeignKey(z => z.ProductId);

            modelBuilder.Entity<OrderItem>()
               .HasOne<Order>(a => a.Order)
               .WithMany(y => y.OrderItems)
               .HasForeignKey(z => z.OrderId);

            modelBuilder.Entity<CartItem>()
              .HasOne<Cart>(a => a.Cart)
              .WithMany(y => y.CartItem)
              .HasForeignKey(z => z.CartId);

            modelBuilder.Entity<CartItem>()
              .HasOne<Product>(a => a.Product)
              .WithMany(y => y.CartItems)
              .HasForeignKey(z => z.ProductId);
            
            modelBuilder.Entity<ApprovedVendor>()
                .HasOne<Vendor>(i => i.Vendor);
          
            modelBuilder.Entity<Services>()
                .HasOne<Vendor>(i => i.Vendor)
                .WithMany(a => a.Services)
                .HasForeignKey(y => y.VendorId);               

            

           
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Events> Events { get; set; }

        public DbSet<Vendor> Vendor { get; set; }

        public DbSet<Services> Services { get; set; }

        public DbSet<Order> Orders { get; set; }    

        public DbSet<Product> Products { get; set; }

        public DbSet<ResidentalAddress> ResidentalAddresses { get; set; }

        public DbSet<ApprovedVendor> ApprovedVendors { get; set; }




    }
}
