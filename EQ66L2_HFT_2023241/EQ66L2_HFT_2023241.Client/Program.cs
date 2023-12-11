using ConsoleTools;
using EQ66L2_HFT_2023241.Logic;
using EQ66L2_HFT_2023241.Models;
using EQ66L2_HFT_2023241.Repository;
using EQ66L2_HFT_2023241.Repository.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace EQ66L2_HFT_2023241.Client
{
    public class Program
    {
          
                 

     
       ///////////////////////////////////////////////////////////////////
   

       

       public static void Main(string[] args)
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
            var E = OrderLogic.MonthOrders(10).ToList();



            ;


        }

    }
}
