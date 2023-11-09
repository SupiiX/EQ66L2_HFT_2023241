using EQ66L2_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EQ66L2_HFT_2023241.Repository
{
    public class DBContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }
       
        public DbSet<Product> Products { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DBContext()
        {
           this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseInMemoryDatabase("data").UseLazyLoadingProxies();

            //
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Manufacturer>()
                .HasMany(x => x.Products)
                .WithOne(x => x.Manufacturer)
                .HasForeignKey(x => x.ProductID)
                .OnDelete(DeleteBehavior.Restrict);




            modelBuilder.Entity<Customer>()
                .HasMany(t => t.Products)
                .WithMany(t => t.Customers)
                .UsingEntity<Order>(
                            t => t.HasOne(t => t.Product)
                               .WithMany()
                               .HasForeignKey(t => t.ProductID)
                               .OnDelete(DeleteBehavior.Cascade),
                            t => t.HasOne(t => t.Customer)
                               .WithMany()
                               .HasForeignKey(t => t.CustomerID)
                               .OnDelete(DeleteBehavior.Cascade)
                               );
                                 

            modelBuilder.Entity<Order>()
                .HasOne(t => t.Customer)
                .WithMany(customer => customer.Orders)
                .HasForeignKey(t => t.CustomerID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
                .HasOne(t => t.Product)
                .WithMany(product => product.Orders)
                .HasForeignKey(t => t.ProductID)
                .OnDelete(DeleteBehavior.Cascade);

            


        }


    }
}
