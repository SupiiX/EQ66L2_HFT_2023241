using ConsoleTools;
//using EQ66L2_HFT_2023241.Logic;
using EQ66L2_HFT_2023241.Models;
//using EQ66L2_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace EQ66L2_HFT_2023241.Client
{
    public class Program
    {

        static RestService rest;

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        static void Create(string entity)
        {
            if (entity == "Customer")
            {
                Console.Write("Enter Customer Name (min 3 char):");
                string name = Console.ReadLine();

                Console.Write("Enter Customer Email addres (dont forget @ symbol!): ");
                string email = Console.ReadLine();

                try
                {
                    rest.Post(new Customer() { CustomerName = name, Email = email }, "customer");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                
            }

            if (entity == "Product")
            {
                Console.Write("Enter Product Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Product price: ");
                int price = int.Parse(Console.ReadLine());

                Console.Write("Enter Product warranty: ");
                int warr = int.Parse(Console.ReadLine());

                Console.Write("Enter Manufacturer Id: ");
                int ManId = int.Parse(Console.ReadLine());

                try
                {
                    rest.Post(new Product() { ProductName = name, Price = price, Warranty_year = warr, ManufacturerID = ManId }, "product");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            
            }


            if (entity == "Manufacturer")
            {
                Console.Write("Enter Manufacturer Name(min 2 char): ");
                string name = Console.ReadLine();

                Console.Write("Enter the place of manufacture: ");
                string placeof = Console.ReadLine();

                try
                {
                    rest.Post(new Manufacturer() { ManufacturerName = name, PlaceOf = placeof }, "manufacturer");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            if (entity == "Order")
            {
                Console.Write("Enter Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

               // Console.Write("Enter Order Date OR Enter - if you want to Order NOW");
                //DateTime Time = DateTime.Parse(Console.ReadLine());
                DateTime Time = DateTime.Now;


                Console.Write("Enter Customer Id: ");
                int CustomerId = int.Parse(Console.ReadLine());

                Console.Write("Enter Product Id: ");
                int ProductId = int.Parse(Console.ReadLine());

                try
                {
                    rest.Post(new Order() { Quantity = quantity, OrderDate = Time, CustomerID = CustomerId, ProductID = ProductId }, "order");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


                
            }

        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        static void List(string entity)
        {
            if (entity == "Customer")
            {
                List<Customer> customers = rest.Get<Customer>("customer");
                foreach (var item in customers)
                {
                    Console.WriteLine("ID: " + item.CustomerID + " / CustomerName: " + item.CustomerName + " / CustomerEmail: " + item.Email);
                }
            }
            

            if (entity == "Product")
            {
                List<Product> products = rest.Get<Product>("product");
                foreach (var item in products)
                {
                    Console.WriteLine("ID: " + item.ProductID + " / ProductName: " + item.ProductName + " / Warranty: " + item.Warranty_year);

                }
            }
            


            if (entity == "Manufacturer")
            {
                List<Manufacturer> manufacturers = rest.Get<Manufacturer>("manufacturer");
                foreach (var item in manufacturers)
                {
                    Console.WriteLine("ID: " + item.ManufacturerID + " / ManufacturerName: " + item.ManufacturerName + " / place of manufacture: " + item.PlaceOf );
                }
            }
           


            if (entity == "Order")
            {
                List<Order> orders = rest.Get<Order>("order");
                foreach (var item in orders)
                {
                    Console.WriteLine("ID: " + item.OrderID + " / Quantity: " + item.Quantity + " / Date of order: " + item.OrderDate );
                }
            }


            Console.ReadLine();

        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        static void Update(string entity)
        {
            if (entity == "Customer")
            {
                Console.Write("Enter Customer's id to update: ");
                int id = int.Parse(Console.ReadLine());

                Customer one = rest.Get<Customer>(id, "customer");


                Console.Write($"New Name [old: {one.CustomerName}]: ");
                string name = Console.ReadLine();

                Console.Write($"New Emal [old: {one.Email}]: ");
                string email = Console.ReadLine();
                
                one.CustomerName = name;
                one.Email = email;
                                            

                try
                {
                    rest.Put(one, "customer");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            if (entity == "Product")
            {
                Console.Write("Enter Product's id to update: ");
                int id = int.Parse(Console.ReadLine());

                Product one = rest.Get<Product>(id, "product");

                Console.Write($"New name [old: {one.ProductName}]: ");
                string name = Console.ReadLine();

                Console.Write($"New Price [old: {one.Price}]: ");
                int price = int.Parse(Console.ReadLine());

                Console.Write($"New Warranty [old: {one.Warranty_year}]: ");
                int warr = int.Parse(Console.ReadLine());

                Console.Write($"New manufacturer [old (Id): {one.ManufacturerID}]: ");
                int Manuf = int.Parse(Console.ReadLine());


                one.ProductName = name;
                one.Warranty_year = warr;
                one.Price = price;
                one.ManufacturerID = Manuf;
                              

                try
                {
                    rest.Put(one, "product");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


            if (entity == "Manufacturer")
            {
                Console.Write("Enter Manufacturer's id to update: ");
                int id = int.Parse(Console.ReadLine());

                Manufacturer one = rest.Get<Manufacturer>(id, "manufacturer");

                Console.Write($"New name [old: {one.ManufacturerName}]: ");
                string name = Console.ReadLine();

                Console.Write($"New Place of manufacture [old: {one.PlaceOf}]: ");
                string place = Console.ReadLine();

                one.ManufacturerName = name;
                one.PlaceOf = place;
                               

                try
                {
                    rest.Put(one, "manufacturer");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            if (entity == "Order")
            {
                Console.Write("Enter Order id to update: ");
                int id = int.Parse(Console.ReadLine());

                Order one = rest.Get<Order>(id, "order");

                Console.Write($"New quantity [old: {one.Quantity}]: ");
                int quantity = int.Parse(Console.ReadLine());

                Console.Write($"New OrderDate [old: {one.OrderDate}]: ");
                DateTime OrderDate = DateTime.Parse(Console.ReadLine());

                Console.Write($"New Product (id) [old: {one.ProductID}]: ");
                int prodid = int.Parse(Console.ReadLine());

                Console.Write($"New Customer (id) [old: {one.CustomerID}]: ");
                int cusid = int.Parse(Console.ReadLine());

                one.OrderDate = OrderDate;
                one.Quantity = quantity;
                one.ProductID = prodid;
                one.CustomerID = cusid;
                               

                try
                {
                    rest.Put(one, "order");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        static void Delete(string entity)
        {
            if (entity == "Customer")
            {
                Console.WriteLine("Items: ");
                Console.WriteLine("press enter to continue deleting !! ");
                List(entity);
                

                Console.Write("Enter Customer's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                try
                {
                    rest.Delete(id, "customer");
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }               
            }

            if (entity == "Product")
            {
                Console.WriteLine("Items: ");
                Console.WriteLine("press enter to continue deleting !! ");
                List(entity);

                Console.Write("Enter Product's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                try
                {
                    rest.Delete(id, "product");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }

            if (entity == "Manufacturer")
            {
                Console.WriteLine("Items: ");
                Console.WriteLine("press enter to continue deleting !! ");
                List(entity);

                Console.Write("Enter Manufacturer's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                try
                {
                    rest.Delete(id, "manufacturer");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            if (entity == "Order")
            {
                Console.WriteLine("Items: ");
                Console.WriteLine("press enter to continue deleting !! ");
                List(entity);

                Console.Write("Enter Order id to delete: ");
                int id = int.Parse(Console.ReadLine());
                try
                {
                    rest.Delete(id, "order");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////

        static void MostPopularPrdMethod()
        {
            //MostPopularPrd

            var prd = rest.Get<PupularPrd>("order/MostPopularPrd");

            foreach (var item in prd)
            {
                Console.WriteLine(item.productName +" - "+ item.ManufacturerName +" - "+ item.MadeIn);
            }
                        
            Console.ReadLine();
        }

        

       static void MostMoneySpendMethod()
        {
            //MostMoneySpend

            var mony = rest.Get<MoneySpend>("order/MostMoneySpend");

            /// Only One

            Console.WriteLine(" Name: " + mony[0].Name + " | Id: " + mony[0].Id + " | Amount: " + mony[0].Amount );

            Console.ReadLine();
        }

        static void PlaceOfPopularPrdMethod()
        {
            //PlaceOfPopularPrd


            var a = rest.Get<CountryMostPopularPrd>("order/PlaceOfPopularPrd");

            foreach (var item in a)
            {
                Console.WriteLine("Country: " + item.Country + " Quantity:" +item.Quantity + " AverageWarranty: " + item.AverageWarranty);
            }

            Console.ReadLine();
        }
        //---

        static void MonthOrdersMethod()
                {
            //MonthOrders

            Console.WriteLine("Enter month (int): ");

            int Month;
            int.TryParse(Console.ReadLine(), out Month);

            var b = rest.GetList<DateOrders>(Month,"order/MonthOrders");

            bool i = false;

            foreach (var item in b)
            {
                if (item.When.Month == Month)
                {
                    Console.WriteLine("When : " + item.When + " | " + item.Product + " | " + item.Customer);

                    i = true;
                }

            }

            if (i == false)
            {
                Console.WriteLine("there was no order in this month");

            }

            Console.ReadLine();
              }

       

        static void ManufactureByCountriesMethod()
        {

            //ManufactureByCountries

            Console.WriteLine("Enter Country Name(min 3 char): ");

            string Country = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(Country))
            {
                Console.WriteLine($"You need to add parameter");
            }
            else
            {
                var c = rest.GetList<ManufactureByCountry>(Country, "product/ManufactureByCountries");

                bool i = false;
                foreach (var item in c)
                {
                    if (item.MadeIn == Country)
                    {
                        Console.WriteLine("Product Name: " + item.ProductName + " | Manufacturer Name: " + item.ManufaturerName + " | Made in: " + item.MadeIn);

                        i = true;
                    }


                }

                if (i == false)
                {
                    Console.WriteLine($"there is no country named like {Country}");
                }

            }
            Console.ReadLine();
        }





        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void Main(string[] args)
        {
           rest = new RestService("http://localhost:63659/","order");

         

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


            var NonCrudSubMenu = new ConsoleMenu(args, level: 1)
                .Add("3 Most Popular product", () => MostPopularPrdMethod())
                .Add("Place of popular product", () => PlaceOfPopularPrdMethod())
                .Add("Who spend the most money", () => MostMoneySpendMethod())
                .Add("Orders in Month", () => MonthOrdersMethod())
                .Add("Manufacturer by country", () => ManufactureByCountriesMethod())
                .Add("Exit", ConsoleMenu.Close);



            var menu = new ConsoleMenu(args, level: 0)
                .Add("Orders", () => OrderSubMenu.Show())
                .Add("Customers", () => customerSubMenu.Show())
                .Add("Products", () => ProductSubMenu.Show())
                .Add("Manufactures", () => ManufacturerSubMenu.Show())
                .Add("NonCrudMethods", () => NonCrudSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();




         




        }

    }
}



public class ManufactureByCountry
{
    public string ManufaturerName { get; set; }
    public string MadeIn { get; set; }
    public string ProductName { get; set; }

}

public class DateOrders
{
    public string Product { get; set; }
    public DateTime When { get; set; }
    public string Customer { get; set; }

}
public class MoneySpend
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Amount { get; set; }

}
public class PupularPrd
{
    public string productName { get; set; }
    public int Count { get; set; }
    public string ManufacturerName { get; set; }
    public string MadeIn { get; set; }
}
public class CountryMostPopularPrd
{
    public string Country { get; set; }
    public int Quantity { get; set; }
    public double AverageWarranty { get; set; }
}


/*
DBContext db = new DBContext();

var a = db.Products.ToArray();
var b = db.Manufacturers.ToArray();
var c = db.Orders.ToArray();
var d = db.Customers.ToArray();

CustomerRepository customerRepository = new CustomerRepository(db);
ManufacturerRepository manufacturerRepository = new ManufacturerRepository(db);
ProductRepository productRepository = new ProductRepository(db);
OrderRepository orderRepository = new OrderRepository(db);


var SupplyLogic = new ProductLogic(productRepository);
var OrderLogic = new OrderLogic(orderRepository);
var CustomerLogic = new CustomerLogic(customerRepository);


//ok => visszaadja csökkenő sorrendben hogy ki költött a legtöbbet
var A = OrderLogic.MostMoneySpend().ToList();
//  melyik a elso 3 legnépszerübb termék(legtöbbet vásárolt) mennyit vásárolnak belőle -/ kik - hol gyartja
var B = OrderLogic.MostPopularPrd().ToList();
// MelyikOrszagbanGyartjakALegtöbbetvasarolttermeket, termek db, atlagos garancia vallalas
var C = OrderLogic.PlaceOfPopularPrd().ToList();
/// ki gyart ott és mit 
var D = SupplyLogic.ManufactureByCountries("Japan").ToList();
var E = OrderLogic.MonthOrders(10).ToList();*/


///////////////////////////////////////////////////////////////////