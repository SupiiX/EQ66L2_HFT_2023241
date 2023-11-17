using EQ66L2_HFT_2023241.Logic;
using EQ66L2_HFT_2023241.Models;
using EQ66L2_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EQ66L2_HFT_2023241.Client
{
    public class Program
    {
        static void Main(string[] args)
        {

            DBContext db = new DBContext();

            //test datafill
            var a = db.Products.ToArray();
            var b = db.Manufacturers.ToArray();
            var c = db.Orders.ToArray();
            var d = db.Customers.ToArray();


            CustomerRepository customerRepository = new CustomerRepository(db);
            ManufacturerRepository manufacturerRepository = new ManufacturerRepository(db);
            ProductRepository productRepository = new ProductRepository(db);
            OrderRepository orderRepository = new OrderRepository(db);

            var SupplyLogic = new SupplyLogic(productRepository, manufacturerRepository);

            var OrderLogic = new OrderLogic(orderRepository);

            var CustomerLogic = new CustomerLogic(customerRepository);

            //////

            var Q = OrderLogic.query();

            var i = OrderLogic.Query_2();


            var I = SupplyLogic.ManufactureProducts().ToList();




            ; 

        }
             
    }
}
