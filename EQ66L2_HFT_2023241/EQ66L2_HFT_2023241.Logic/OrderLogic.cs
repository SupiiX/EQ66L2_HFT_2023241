using EQ66L2_HFT_2023241.Models;
using EQ66L2_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EQ66L2_HFT_2023241.Logic
{
    public class OrderLogic 
    {
        IOrderRepository orderRepository;


        public OrderLogic(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        /// CRUD 

        
        public void Create(Order item)
        {
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

        /// Non CRUD


    }
}
