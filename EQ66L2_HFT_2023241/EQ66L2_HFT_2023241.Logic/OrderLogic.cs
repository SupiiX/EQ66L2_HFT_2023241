using EQ66L2_HFT_2023241.Logic.Interfaces;
using EQ66L2_HFT_2023241.Models;
using EQ66L2_HFT_2023241.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EQ66L2_HFT_2023241.Logic
{
    public class OrderLogic : IOrderLogic
    {
        IOrderRepository orderRepository;


        public OrderLogic(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        /// CRUD 


        public void Create(Order item)
        {
            if (item.CustomerID <= 0 )
            {
                throw new Exception("Customer ID error");

            }
            if (item.OrderDate > DateTime.Now ) 
            {
                throw new Exception("Order Date Error");
            
            }
            if(item.Quantity <=0 )
            {
                throw new Exception("You cant order 0 or less product");
            }


            orderRepository.Create(item);
        }

        public void Delete(int id)
        {
            orderRepository.Delete(id);
        }

        public Order Read(int id)
        {
            return orderRepository.Read(id);
        }

        public IEnumerable<Order> ReadAll()
        {
            return orderRepository.ReadAll();
        }

        public void Update(Order value)
        {
            orderRepository.Update(value);
        }

        public void ChangeProduct(int id, int NewProductId)
        {
            orderRepository.ChangeProduct(id, NewProductId);
        }

        public void ChangeQuantity(int id, int Quantity)
        {
            orderRepository.ChangeQuantity(id, Quantity);
        }

        //////////////////////////////////////////////////
        /// Non CRUD
           

        public IEnumerable<PupularPrd> Query_2()
        {
            // melyik a elso 3 legnépszerübb termék (legtöbbet vásárolt) mennyit vásárolnak belőle-/kik-hol gyartja  

            return (from X in orderRepository.ReadAll().Include(x => x.Product).ToList()
                   group X by new { X.ProductID, X.Product.ProductName } into grop
                   orderby grop.Sum(x => x.Quantity) descending
                   select new PupularPrd
                   {
                       //id = grop.Key,
                       productName = grop.Key.ProductName,

                       Count = grop.Sum(x => x.Quantity),

                      ManufacturerName = grop.FirstOrDefault().Product.Manufacturer.ManufacturerName,

                      MadeIn = grop.FirstOrDefault().Product.Manufacturer.PlaceOf

                   }).Take(3);
        }


        public IEnumerable<object> query()
        {
                       
            // Először lekérdezzük a rendeléseket és a hozzájuk tartozó vevőket egy listába
            var orders = orderRepository.ReadAll().Include(x => x.Customer).ToList();


            // Majd a listán végzünk csoportosítást és kiválasztást
            return orders.GroupBy(x => x.CustomerID).Select(x => new
            {
                ID = x.Key,
                Name = x.FirstOrDefault().Customer.CustomerName,  
                Osszeg = x.Sum(x => x.Product.Price * x.Quantity)

            }).OrderByDescending(x => x.Osszeg);
        }

        
        public IEnumerable<object> Query3()
        {

            return orderRepository.ReadAll().Include(x => x.Product).ToList().
                        GroupBy(x => x.Product.Manufacturer.PlaceOf).
                        OrderByDescending(x => x.Sum(x => x.Quantity)).
                        Select(x => new
                        {
                            Country = x.Key,
                            Quantity = x.Sum(x => x.Quantity),
                            o = x.Average(x => x.Product.Warranty_year)
                        });
        }

  
       


    }

    public class PupularPrd
    {
        public string productName;
        public int Count;
        public string ManufacturerName;
        public string MadeIn;
    }

    public class P
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Total { get; set; }
    }
}
