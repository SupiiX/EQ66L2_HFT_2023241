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


        public void Query_1(string Country)
        {
            // parameteresen megadott orszaágban, kik gyártanak 

        }

        public IEnumerable<object> Query_2()
        {
            // melyik a legnépszerübb termék ?  / mennyit vásárolnak belőle-/kik-hol gyartja  

            //  return orderRepository.ReadAll().GroupBy(x => x.Quantity).ToList();
            //var quantityProperty = orderRepository.ReadAll();

            //return orderRepository.ReadAll().Include(x => x.Product).GroupBy(x => x.ProductID).OrderByDescending(x=> x.Sum(x => x.Quantity)).Select(x => new
            //{
            //    Id = x.Key,
            //    Name = x.First().Product.ProductName,
            //    Much = x.Sum(x => x.Quantity)


            //}).ToList();

            // elötte readall().include(x => objektum)...list=() adatot begyujteni 

           // var F = orderRepository.ReadAll().GroupBy(x => x.ProductID).OrderByDescending(x => x.Sum(x => x.Quantity)).Select(x => new { K = x.Key }).ToList();

            return from X in orderRepository.ReadAll().Include(x => x.Product).ToList()
                   group X by new { X.ProductID, X.Product.ProductName} into grop
                   orderby grop.Sum(x => x.Quantity) descending
                   select new
                   {
                       id = grop.Key,

                       b = grop.FirstOrDefault().Product.Manufacturer.ManufacturerName,

                       Name = grop.Key.ProductName,

                       count = grop.Sum(x => x.Quantity)

                   };



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
}
