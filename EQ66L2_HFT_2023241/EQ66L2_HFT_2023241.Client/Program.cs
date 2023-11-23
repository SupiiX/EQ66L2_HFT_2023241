using ConsoleTools;
using EQ66L2_HFT_2023241.Logic;
using EQ66L2_HFT_2023241.Models;
using EQ66L2_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace EQ66L2_HFT_2023241.Client
{
    public class Program
    {

        //DBContext db = new DBContext();

        ////test datafill
        ////var a = db.Products.ToArray();
        ////var b = db.Manufacturers.ToArray();
        ////var c = db.Orders.ToArray();
        ////var d = db.Customers.ToArray();

        //CustomerRepository customerRepository = new CustomerRepository(db);
        //ManufacturerRepository manufacturerRepository = new ManufacturerRepository(db);
        //ProductRepository productRepository = new ProductRepository(db);
        //OrderRepository orderRepository = new OrderRepository(db);

        //var SupplyLogic = new SupplyLogic(productRepository, manufacturerRepository);
        //var OrderLogic = new OrderLogic(orderRepository);
        //var CustomerLogic = new CustomerLogic(customerRepository);

        ///////////////////////////////////////////////////////////////////


        //// ok => visszaadja csökkenő sorrendben hogy ki költött a legtöbbet
        //var A = OrderLogic.MostMoneySpend().ToList();

        //// melyik a elso 3 legnépszerübb termék (legtöbbet vásárolt) mennyit vásárolnak belőle-/kik-hol gyartja
        //var B = OrderLogic.MostPopularPrd().ToList();


        ////MelyikOrszagbanGyartjakALegtöbbetvasarolttermeket, termek db, atlagos garancia vallalas
        //var C = OrderLogic.PlaceOfPopularPrd().ToList();

        /////// ki gyart ott és mit 
        //var D = SupplyLogic.ManufactureByCountries("Japan").ToList();

        //var E = OrderLogic.MonthOrders(10).ToList();

        static RestService rest;

        static void Create(string entity)
        {
            if (entity == "Customer")
            {
                Console.Write("Enter Customer Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Customer Email addres: ");
                string email = Console.ReadLine();
                rest.Post(new Customer() { CustomerName = name, Email= email }, "customer");
            }

            if (entity == "Product")
            {
                Console.Write("Enter Product Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Product price: ");
                int price = int.Parse(Console.ReadLine());
                rest.Post(new Product() { ProductName = name, Price = price  }, "product");
            }


            if (entity == "Manufacturer")
            {
                Console.Write("Enter Manufacturer Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter the place of manufacture");
                string placeof = Console.ReadLine();
                rest.Post(new Manufacturer() { ManufacturerName = name, PlaceOf = placeof  }, "manufacturer");
            }

            if (entity == "Order")
            {
                Console.Write("Enter Quantity: ");
                int quantity = int.Parse(Console.ReadLine());
                Console.Write("Enter Order Date");
                DateTime Time = DateTime.Parse(Console.ReadLine());
                rest.Post(new Order() { Quantity = quantity, OrderDate = Time }, "order");
            }

        }

        static void List(string entity)
        {
            if (entity == "Customer")
            {
                List<Customer> customers = rest.Get<Customer>("customer");
                foreach (var item in customers)
                {
                    Console.WriteLine(item.CustomerID + ": " + item.CustomerName);
                }
            }
            Console.ReadLine();

            if (entity == "Product")
            {
                List<Product> products = rest.Get<Product>("product");
                foreach (var item in products)
                {
                    Console.WriteLine(item.ProductID + ": " + item.ProductName);
                }
            }
            Console.ReadLine();


            if (entity == "Manufacturer")
            {
                List<Manufacturer> manufacturers = rest.Get<Manufacturer>("manufacturer");
                foreach (var item in manufacturers)
                {
                    Console.WriteLine(item.ManufacturerID + ": " + item.ManufacturerName);
                }
            }
            Console.ReadLine();


            if (entity == "Order")
            {
                List<Order> orders = rest.Get<Order>("order");
                foreach (var item in orders)
                {
                    Console.WriteLine(item.OrderID + ": " + item.Quantity + ": " + item.OrderDate );
                }
            }
            Console.ReadLine();


        }

        static void Update(string entity)
        {
            if (entity == "Customer")
            {
                Console.Write("Enter Customer's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Customer one = rest.Get<Customer>(id, "customer");
                Console.Write($"New name [old: {one.CustomerName}]: ");
                string name = Console.ReadLine();
                one.CustomerName = name;
                rest.Put(one, "customer");
            }

            if (entity == "Product")
            {
                Console.Write("Enter Product's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Product one = rest.Get<Product>(id, "product");
                Console.Write($"New name [old: {one.ProductName}]: ");
                string name = Console.ReadLine();
                one.ProductName = name;
                rest.Put(one, "product");
            }


            if (entity == "Manufacturer")
            {
                Console.Write("Enter Manufacturer's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Manufacturer one = rest.Get<Manufacturer>(id, "manufacturer");
                Console.Write($"New name [old: {one.ManufacturerName}]: ");
                string name = Console.ReadLine();
                one.ManufacturerName = name;
                rest.Put(one, "manufacturer");
            }

            if (entity == "Order")
            {
                Console.Write("Enter Order id to update: ");
                int id = int.Parse(Console.ReadLine());
                Order one = rest.Get<Order>(id, "order");
                Console.Write($"New quantity - OrderDate [old: {one.Quantity} - {one.OrderDate}]: ");
                int quantity = int.Parse(Console.ReadLine());
                one.Quantity = quantity;
                DateTime OrderDate = DateTime.Parse(Console.ReadLine());
                one.OrderDate = OrderDate;

                rest.Put(one, "order");
            }



        }
        static void Delete(string entity)
        {
            if (entity == "Customer")
            {
                Console.Write("Enter Customer's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "customer");
            }

            if (entity == "Product")
            {
                Console.Write("Enter Product's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "product");
            }

            if (entity == "Manufacturer")
            {
                Console.Write("Enter Manufacturer's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "manufacturer");
            }

            if (entity == "Order")
            {
                Console.Write("Enter Order id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "order");
            }
          }




       public static void Main(string[] args)
        {
            rest = new RestService("http://localhost:53910/", "movie");

            var customerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Customer"))
                .Add("Create", () => Create("Customer"))
                .Add("Delete", () => Delete("Customer"))
                .Add("Update", () => Update("Customer"))
                .Add("Exit", ConsoleMenu.Close);

            var ProductSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Product"))
                .Add("Create", () => Create("Product"))
                .Add("Delete", () => Delete("Product"))
                .Add("Update", () => Update("Product"))
                .Add("Exit", ConsoleMenu.Close);

            var ManufacturerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Manufacturer"))
                .Add("Create", () => Create("Manufacturer"))
                .Add("Delete", () => Delete("Manufacturer"))
                .Add("Update", () => Update("Manufacturer"))
                .Add("Exit", ConsoleMenu.Close);

            var OrderSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Order"))
                .Add("Create", () => Create("Order"))
                .Add("Delete", () => Delete("Order"))
                .Add("Update", () => Update("Order"))
                .Add("Exit", ConsoleMenu.Close);


            var menu = new ConsoleMenu(args, level: 0)
                .Add("Orders", () => OrderSubMenu.Show())
                .Add("Customers", () => customerSubMenu.Show())
                .Add("Products", () => ProductSubMenu.Show())
                .Add("Manufactures", () => ManufacturerSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();





        }

    }
}
