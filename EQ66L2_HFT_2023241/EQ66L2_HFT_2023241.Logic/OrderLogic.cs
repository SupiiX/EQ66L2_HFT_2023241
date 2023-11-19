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

        



        public IEnumerable<object> MelyikOrszagbanGyartjakALegtöbbetvasarolttermeket()
        {

            return orderRepository.ReadAll().
                        GroupBy(x => x.Product.Manufacturer.PlaceOf).
                        OrderByDescending(x => x.Sum(x => x.Quantity)).
                        Select(x => new
                        {
                            Country = x.Key,
                            Quantity = x.Sum(x => x.Quantity),
                            //Customer = x.Select(x => x.Customer.CustomerName)  // exept
                        });

        }

        /// 

        public IEnumerable<P> KikoltotteALegtobbPenzt()
        {

            //return orderRepository.ReadAll().GroupBy(x => x.Customer.CustomerID).OrderBy(x => x.Sum(x => x.Quantity))
            //                .Select(x => new
            //                {
            //                    a = x.Key,

            //                    b = x.Select(x => x.Customer.CustomerName).ToString() 

            //                });
            //


            var quer = from order in orderRepository.ReadAll()
                       group order by order.CustomerID into customerGroup
                       let totalSpent = customerGroup.Sum(order => order.Product.Price * order.Quantity)
                       orderby totalSpent descending
                       select new P
                       {
                           Id = customerGroup.Key,
                           //Name = customerGroup.FirstOrDefault(x => x.Customer?.CustomerName),
                           Total = totalSpent
                       };

            return quer.ToList();

        }

        public class P
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Total { get; set; }
        }


        public int Queryyyyyyy()
        {
            return orderRepository.ReadAll().Select(x => new
            {
                warrant = x.Product.Warranty_year,
                name = x.Customer.CustomerName,
                quan = x.Quantity,

            }


            ).Max(x => x.quan);


        }

        public IEnumerable<object> query()
        {
            // Először lekérdezzük a rendeléseket és a hozzájuk tartozó vevőket egy listába
            var orders = orderRepository.ReadAll().Include(x => x.Customer).ToList();
            

            // Majd a listán végzünk csoportosítást és kiválasztást
            return orders.Select(x => x.Customer).GroupBy(x => x.CustomerID).Select(x => new
            {
                c = x.Key,
                a = x.FirstOrDefault().CustomerName,
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

}
