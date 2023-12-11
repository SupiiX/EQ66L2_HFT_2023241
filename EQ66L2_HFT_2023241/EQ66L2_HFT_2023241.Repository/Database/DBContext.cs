using EQ66L2_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EQ66L2_HFT_2023241.Repository.Database
{
    public class DBContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Manufacturer> Manufacturers { get; set; }

        public DBContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);


            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseInMemoryDatabase("data");

            }

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //connections

            /// need work here !!!!!!!



            modelBuilder.Entity<Manufacturer>()
                .HasMany(x => x.Products)
                .WithOne(x => x.Manufacturer)
                .HasForeignKey(x => x.ProductID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
                .HasOne(x => x.Product)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.ProductID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
                .HasOne(x => x.Customer)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.CustomerID)
                .OnDelete(DeleteBehavior.Cascade);




            //modelBuilder.Entity<Customer>()
            //    .HasMany(t => t.Products)
            //    .WithMany(t => t.Customers)
            //    .UsingEntity<Order>(
            //                t => t.HasOne(t => t.Product)
            //                   .WithMany()
            //                   .HasForeignKey(t => t.ProductID)
            //                   .OnDelete(DeleteBehavior.Cascade),
            //                t => t.HasOne(t => t.Customer)
            //                   .WithMany()
            //                   .HasForeignKey(t => t.CustomerID)
            //                   .OnDelete(DeleteBehavior.Cascade)
            //                   );


            //modelBuilder.Entity<Order>()
            //    .HasOne(t => t.Customer)
            //    .WithMany(customer => customer.Orders)
            //    .HasForeignKey(t => t.CustomerID)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Order>()
            //    .HasOne(t => t.Product)
            //    .WithMany(product => product.Orders)
            //    .HasForeignKey(t => t.ProductID)
            //    .OnDelete(DeleteBehavior.Cascade);


            // datas

            List<Manufacturer> manufacturers = new List<Manufacturer>();

            manufacturers.Add(new Manufacturer { ManufacturerID = 1, ManufacturerName = "Electrolux", PlaceOf = "Hungary" });
            manufacturers.Add(new Manufacturer { ManufacturerID = 2, ManufacturerName = "Sony", PlaceOf = "Japan" });
            manufacturers.Add(new Manufacturer { ManufacturerID = 3, ManufacturerName = "Samsung", PlaceOf = "South Korea" });
            manufacturers.Add(new Manufacturer { ManufacturerID = 4, ManufacturerName = "Apple", PlaceOf = "United States" });
            manufacturers.Add(new Manufacturer { ManufacturerID = 5, ManufacturerName = "Lenovo", PlaceOf = "China" });
            manufacturers.Add(new Manufacturer { ManufacturerID = 6, ManufacturerName = "LG", PlaceOf = "South Korea" });
            manufacturers.Add(new Manufacturer { ManufacturerID = 7, ManufacturerName = "Dell", PlaceOf = "United States" });
            manufacturers.Add(new Manufacturer { ManufacturerID = 8, ManufacturerName = "HP", PlaceOf = "United States" });
            manufacturers.Add(new Manufacturer { ManufacturerID = 9, ManufacturerName = "Acer", PlaceOf = "Taiwan" });
            manufacturers.Add(new Manufacturer { ManufacturerID = 10, ManufacturerName = "Microsoft", PlaceOf = "United States" });
            manufacturers.Add(new Manufacturer { ManufacturerID = 11, ManufacturerName = "Asus", PlaceOf = "Taiwan" });
            manufacturers.Add(new Manufacturer { ManufacturerID = 12, ManufacturerName = "Panasonic", PlaceOf = "Japan" });
            manufacturers.Add(new Manufacturer { ManufacturerID = 13, ManufacturerName = "Toshiba", PlaceOf = "Japan" });
            manufacturers.Add(new Manufacturer { ManufacturerID = 14, ManufacturerName = "Sharp", PlaceOf = "Japan" });
            manufacturers.Add(new Manufacturer { ManufacturerID = 15, ManufacturerName = "IBM", PlaceOf = "United States" });
            manufacturers.Add(new Manufacturer { ManufacturerID = 16, ManufacturerName = "Nokia", PlaceOf = "Finland" });
            manufacturers.Add(new Manufacturer { ManufacturerID = 17, ManufacturerName = "Canon", PlaceOf = "Japan" });
            manufacturers.Add(new Manufacturer { ManufacturerID = 18, ManufacturerName = "Epson", PlaceOf = "Japan" });
            manufacturers.Add(new Manufacturer { ManufacturerID = 19, ManufacturerName = "Xiaomi", PlaceOf = "China" });
            manufacturers.Add(new Manufacturer { ManufacturerID = 20, ManufacturerName = "GoPro", PlaceOf = "United States" });
            manufacturers.Add(new Manufacturer { ManufacturerID = 21, ManufacturerName = "Philips", PlaceOf = "Netherlands" });
            manufacturers.Add(new Manufacturer { ManufacturerID = 22, ManufacturerName = "Bosch", PlaceOf = "Germany" });
            manufacturers.Add(new Manufacturer { ManufacturerID = 23, ManufacturerName = "Siemens", PlaceOf = "Germany" });
            manufacturers.Add(new Manufacturer { ManufacturerID = 24, ManufacturerName = "BlackBerry", PlaceOf = "Canada" });
            manufacturers.Add(new Manufacturer { ManufacturerID = 25, ManufacturerName = "Casio", PlaceOf = "Japan" });
            manufacturers.Add(new Manufacturer { ManufacturerID = 26, ManufacturerName = "Pioneer", PlaceOf = "Japan" });

            List<Product> products = new List<Product>();

            products.Add(new Product { ProductID = 1, Price = 150, ProductName = "Mikro", Warranty_year = 3, ManufacturerID = 1 });
            products.Add(new Product { ProductID = 2, Price = 120, ProductName = "LED TV", Warranty_year = 2, ManufacturerID = 3 });
            products.Add(new Product { ProductID = 3, Price = 300, ProductName = "iPhone 13", Warranty_year = 1, ManufacturerID = 4 });
            products.Add(new Product { ProductID = 4, Price = 80, ProductName = "Wireless Mouse", Warranty_year = 2, ManufacturerID = 5 });
            products.Add(new Product { ProductID = 5, Price = 700, ProductName = "UltraWide Monitor", Warranty_year = 3, ManufacturerID = 6 });
            products.Add(new Product { ProductID = 6, Price = 1000, ProductName = "XPS Laptop", Warranty_year = 4, ManufacturerID = 7 });
            products.Add(new Product { ProductID = 7, Price = 450, ProductName = "Envy Printer", Warranty_year = 2, ManufacturerID = 8 });
            products.Add(new Product { ProductID = 8, Price = 600, ProductName = "Predator Gaming Laptop", Warranty_year = 3, ManufacturerID = 9 });
            products.Add(new Product { ProductID = 9, Price = 1500, ProductName = "Surface Pro 8", Warranty_year = 2, ManufacturerID = 10 });
            products.Add(new Product { ProductID = 10, Price = 300, ProductName = "ROG Gaming Mouse", Warranty_year = 1, ManufacturerID = 11 });
            products.Add(new Product { ProductID = 11, Price = 1200, ProductName = "Lumix Camera", Warranty_year = 2, ManufacturerID = 12 });
            products.Add(new Product { ProductID = 12, Price = 200, ProductName = "Satellite Laptop", Warranty_year = 3, ManufacturerID = 13 });
            products.Add(new Product { ProductID = 13, Price = 180, ProductName = "Aquos TV", Warranty_year = 3, ManufacturerID = 14 });
            products.Add(new Product { ProductID = 14, Price = 250, ProductName = "ThinkPad", Warranty_year = 2, ManufacturerID = 15 });
            products.Add(new Product { ProductID = 15, Price = 400, ProductName = "Nokia 9", Warranty_year = 1, ManufacturerID = 16 });
            products.Add(new Product { ProductID = 16, Price = 320, ProductName = "EOS DSLR Camera", Warranty_year = 2, ManufacturerID = 17 });
            products.Add(new Product { ProductID = 17, Price = 90, ProductName = "Expression Home Printer", Warranty_year = 2, ManufacturerID = 18 });
            products.Add(new Product { ProductID = 18, Price = 500, ProductName = "Redmi Note 10", Warranty_year = 1, ManufacturerID = 19 });
            products.Add(new Product { ProductID = 19, Price = 150, ProductName = "GoPro Hero 10", Warranty_year = 2, ManufacturerID = 20 });
            products.Add(new Product { ProductID = 20, Price = 40, ProductName = "LED Bulbs (4 pack)", Warranty_year = 2, ManufacturerID = 21 });
            products.Add(new Product { ProductID = 21, Price = 300, ProductName = "Bosch Drill", Warranty_year = 3, ManufacturerID = 22 });
            products.Add(new Product { ProductID = 22, Price = 200, ProductName = "Siemens Dishwasher", Warranty_year = 4, ManufacturerID = 23 });
            products.Add(new Product { ProductID = 23, Price = 120, ProductName = "BlackBerry Key2", Warranty_year = 1, ManufacturerID = 24 });
            products.Add(new Product { ProductID = 24, Price = 80, ProductName = "Casio G-Shock Watch", Warranty_year = 2, ManufacturerID = 25 });
            products.Add(new Product { ProductID = 25, Price = 150, ProductName = "Pioneer Headphones", Warranty_year = 2, ManufacturerID = 26 });


            List<Customer> customers = new List<Customer>();

            customers.Add(new Customer { CustomerID = 1, CustomerName = "Sanyo", Email = "szenasi.sandor@nik.uni-obuda.hu" });
            customers.Add(new Customer { CustomerID = 2, CustomerName = "András", Email = "kovacs.andras@nik.uni-obuda.hu" });
            customers.Add(new Customer { CustomerID = 3, CustomerName = "Péter", Email = "peter@example.com" });
            customers.Add(new Customer { CustomerID = 4, CustomerName = "Anna", Email = "anna@example.com" });
            customers.Add(new Customer { CustomerID = 5, CustomerName = "Gábor", Email = "gabor@example.com" });
            customers.Add(new Customer { CustomerID = 6, CustomerName = "Eszter", Email = "eszter@example.com" });
            customers.Add(new Customer { CustomerID = 7, CustomerName = "Balázs", Email = "balazs@example.com" });
            customers.Add(new Customer { CustomerID = 8, CustomerName = "Zsuzsa", Email = "zsuzsa@example.com" });
            customers.Add(new Customer { CustomerID = 9, CustomerName = "Tamás", Email = "tamas@example.com" });
            customers.Add(new Customer { CustomerID = 10, CustomerName = "Eva", Email = "eva@example.com" });
            customers.Add(new Customer { CustomerID = 11, CustomerName = "Gergő", Email = "gergo@example.com" });
            customers.Add(new Customer { CustomerID = 12, CustomerName = "Judit", Email = "judit@example.com" });
            customers.Add(new Customer { CustomerID = 13, CustomerName = "Máté", Email = "mate@example.com" });
            customers.Add(new Customer { CustomerID = 14, CustomerName = "Kriszta", Email = "kriszta@example.com" });
            customers.Add(new Customer { CustomerID = 15, CustomerName = "László", Email = "laszlo@example.com" });
            customers.Add(new Customer { CustomerID = 16, CustomerName = "Fanni", Email = "fanni@example.com" });
            customers.Add(new Customer { CustomerID = 17, CustomerName = "Csaba", Email = "csaba@example.com" });
            customers.Add(new Customer { CustomerID = 18, CustomerName = "Réka", Email = "reka@example.com" });
            customers.Add(new Customer { CustomerID = 19, CustomerName = "Zoltán", Email = "zoltan@example.com" });
            customers.Add(new Customer { CustomerID = 20, CustomerName = "Dóra", Email = "dora@example.com" });
            customers.Add(new Customer { CustomerID = 21, CustomerName = "Attila", Email = "attila@example.com" });
            customers.Add(new Customer { CustomerID = 22, CustomerName = "Mariann", Email = "mariann@example.com" });
            customers.Add(new Customer { CustomerID = 23, CustomerName = "Norbert", Email = "norbert@example.com" });
            customers.Add(new Customer { CustomerID = 24, CustomerName = "Virág", Email = "virag@example.com" });
            customers.Add(new Customer { CustomerID = 25, CustomerName = "Bence", Email = "bence@example.com" });


            List<Order> orders = new List<Order>();

            orders.Add(new Order { OrderID = 1, Quantity = 4, OrderDate = new DateTime(2022, 10, 16), CustomerID = customers[0].CustomerID, ProductID = products[0].ProductID });
            orders.Add(new Order { OrderID = 2, Quantity = 2, OrderDate = new DateTime(2022, 10, 17), CustomerID = customers[5].CustomerID, ProductID = products[9].ProductID });
            orders.Add(new Order { OrderID = 3, Quantity = 1, OrderDate = new DateTime(2022, 10, 18), CustomerID = customers[1].CustomerID, ProductID = products[15].ProductID });
            orders.Add(new Order { OrderID = 4, Quantity = 3, OrderDate = new DateTime(2022, 10, 19), CustomerID = customers[8].CustomerID, ProductID = products[7].ProductID });
            orders.Add(new Order { OrderID = 5, Quantity = 5, OrderDate = new DateTime(2022, 10, 20), CustomerID = customers[12].CustomerID, ProductID = products[12].ProductID });
            orders.Add(new Order { OrderID = 6, Quantity = 1, OrderDate = new DateTime(2022, 10, 21), CustomerID = customers[17].CustomerID, ProductID = products[2].ProductID });
            orders.Add(new Order { OrderID = 7, Quantity = 2, OrderDate = new DateTime(2022, 10, 22), CustomerID = customers[22].CustomerID, ProductID = products[22].ProductID });
            orders.Add(new Order { OrderID = 8, Quantity = 4, OrderDate = new DateTime(2022, 10, 23), CustomerID = customers[19].CustomerID, ProductID = products[20].ProductID });
            orders.Add(new Order { OrderID = 9, Quantity = 3, OrderDate = new DateTime(2022, 10, 24), CustomerID = customers[14].CustomerID, ProductID = products[6].ProductID });
            orders.Add(new Order { OrderID = 10, Quantity = 2, OrderDate = new DateTime(2022, 10, 25), CustomerID = customers[24].CustomerID, ProductID = products[24].ProductID });
            orders.Add(new Order { OrderID = 11, Quantity = 1, OrderDate = new DateTime(2022, 10, 26), CustomerID = customers[21].CustomerID, ProductID = products[11].ProductID });
            orders.Add(new Order { OrderID = 12, Quantity = 3, OrderDate = new DateTime(2022, 10, 27), CustomerID = customers[11].CustomerID, ProductID = products[16].ProductID });
            orders.Add(new Order { OrderID = 13, Quantity = 4, OrderDate = new DateTime(2022, 10, 28), CustomerID = customers[4].CustomerID, ProductID = products[1].ProductID });
            orders.Add(new Order { OrderID = 14, Quantity = 2, OrderDate = new DateTime(2022, 10, 29), CustomerID = customers[20].CustomerID, ProductID = products[10].ProductID });
            orders.Add(new Order { OrderID = 15, Quantity = 1, OrderDate = new DateTime(2022, 10, 30), CustomerID = customers[10].CustomerID, ProductID = products[19].ProductID });
            orders.Add(new Order { OrderID = 16, Quantity = 3, OrderDate = new DateTime(2022, 10, 31), CustomerID = customers[7].CustomerID, ProductID = products[23].ProductID });
            orders.Add(new Order { OrderID = 17, Quantity = 5, OrderDate = new DateTime(2022, 11, 1), CustomerID = customers[0].CustomerID, ProductID = products[8].ProductID });
            orders.Add(new Order { OrderID = 18, Quantity = 2, OrderDate = new DateTime(2022, 11, 2), CustomerID = customers[3].CustomerID, ProductID = products[18].ProductID });
            orders.Add(new Order { OrderID = 19, Quantity = 1, OrderDate = new DateTime(2022, 11, 3), CustomerID = customers[9].CustomerID, ProductID = products[0].ProductID });
            orders.Add(new Order { OrderID = 20, Quantity = 4, OrderDate = new DateTime(2022, 11, 4), CustomerID = customers[16].CustomerID, ProductID = products[5].ProductID });
            orders.Add(new Order { OrderID = 21, Quantity = 3, OrderDate = new DateTime(2022, 10, 5), CustomerID = customers[2].CustomerID, ProductID = products[13].ProductID });
            orders.Add(new Order { OrderID = 22, Quantity = 2, OrderDate = new DateTime(2022, 11, 6), CustomerID = customers[15].CustomerID, ProductID = products[21].ProductID });
            orders.Add(new Order { OrderID = 23, Quantity = 1, OrderDate = new DateTime(2022, 9, 7), CustomerID = customers[18].CustomerID, ProductID = products[3].ProductID });
            orders.Add(new Order { OrderID = 24, Quantity = 3, OrderDate = new DateTime(2022, 11, 8), CustomerID = customers[23].CustomerID, ProductID = products[14].ProductID });
            orders.Add(new Order { OrderID = 25, Quantity = 4, OrderDate = new DateTime(2022, 8, 9), CustomerID = customers[13].CustomerID, ProductID = products[17].ProductID });


            modelBuilder.Entity<Manufacturer>().HasData(manufacturers);

            modelBuilder.Entity<Product>().HasData(products);

            modelBuilder.Entity<Customer>().HasData(customers);

            modelBuilder.Entity<Order>().HasData(orders);
        }




    }
}
