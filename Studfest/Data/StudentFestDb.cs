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

            modelBuilder.Entity<ResidentalAddress>()
                .HasOne<Vendor>(i => i.Vendor)
                .WithMany(g => g.ResidentalAddress)
                .HasForeignKey( a => a.VendorId);
                   

           modelBuilder.Entity<Order>()
                .HasOne<Product>(i => i.Product)
                .WithMany(g => g.Orders)
                .HasForeignKey(v => v.ProductId);
            

            modelBuilder.Entity<ApprovedVendor>()
                .HasOne<Vendor>(i => i.Vendor)
                .WithMany( a =>  a.ApprovedVendor)
                .HasForeignKey( i => i.VendorId);

            modelBuilder.Entity<Order>()
                .HasOne<DeliveryTeam>( i => i.DeliveryTeam)
                .WithMany( a => a.Orders)
                .HasForeignKey( y => y.DeliveryTeamId);

            modelBuilder.Entity<Order>()
                .HasOne<DeliveryInformation>(i => i.DeliveryInformation)
                .WithMany(a => a.Orders)
                .HasForeignKey(y => y.DeliverInfoId);

            

            modelBuilder.Entity<ServiceProvidersDocuments>()
                .HasOne<Vendor>(i => i.Vendor)
                .WithMany(a => a.Documents)
                .HasForeignKey(y => y.VendorId);

            modelBuilder.Entity<Services>()
                .HasOne<Vendor>(i => i.Vendor)
                .WithMany(a => a.Services)
                .HasForeignKey(y => y.VendorId);


            modelBuilder.Entity<ContactDetails>()
                .HasOne<Vendor>(i => i.Vendors)
                .WithMany(a => a.ContactDetails)
                .HasForeignKey( y => y.VendorId);

            modelBuilder.Entity<ContactDetails>()
                .HasOne<DeliveryTeam>(i => i.DeliveryTeams)
                .WithMany(a => a.ContactDetails)
                .HasForeignKey(y => y.DeliveryTeamId);

            modelBuilder.Entity<ApprovedDeliveryTeam>()
                .HasOne<DeliveryTeam>(a => a.DeliveryTeam)
                .WithMany(i => i.ApprovedDeliveryTeams)
                .HasForeignKey(y => y.DeliveryTeamId);


        }

        public DbSet<Vendor> Vendor { get; set; }

        public DbSet<Services> Services { get; set; }

        public DbSet<Order> Orders { get; set; }    

        public DbSet<Product> Products { get; set; }

        public DbSet<ServiceProvidersDocuments> ServicesDocuments { get; set; }

        public DbSet<ResidentalAddress> ResidentalAddresses { get; set; }

        public DbSet<DeliveryTeam> DeliveryTeam { get; set; }

       

        public DbSet<DeliveryInformation> DeliveryInformation { get; set;}

        public DbSet<ApprovedDeliveryTeam> ApprovedDeliveryTeams { get; set; }

        public DbSet<ApprovedVendor> ApprovedVendors { get; set; }




    }
}
