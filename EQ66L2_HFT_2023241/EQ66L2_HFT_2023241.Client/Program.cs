using EQ66L2_HFT_2023241.Logic;
using EQ66L2_HFT_2023241.Models;
using EQ66L2_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EQ66L2_HFT_2023241.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {

            DBContext db = new DBContext();

            var a = db.Products.ToArray();
            var b = db.Manufacturers.ToArray();
            var c = db.Orders.ToArray();
            var d = db.Customers.ToArray();

            
            CustomerRepository customerRepository = new CustomerRepository(db);
            ManufacturerRepository manufacturerRepository = new ManufacturerRepository(db);
            ProductRepository productRepository = new ProductRepository(db);
            OrderRepository orderRepository = new OrderRepository(db);


            ManufacturerRepository manufacturerRepository1 = new ManufacturerRepository(db);
            ProductRepository productRepository1 = new ProductRepository(db);

            var logic = new SupplyLogic(productRepository1, manufacturerRepository1);

            var item = logic.ReadAll_Manufacturer();

            
            // Method1();

            ; 

        }
             
    }
}
