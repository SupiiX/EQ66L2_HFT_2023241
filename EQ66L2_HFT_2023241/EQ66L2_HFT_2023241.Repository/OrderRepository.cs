using EQ66L2_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EQ66L2_HFT_2023241.Repository
{
    public class OrderRepository : Reposit<Order>, IOrderRepository
    {
        public OrderRepository(DBContext dbContext) : base(dbContext)
        {
        }

        //private Order;

        public void ChangeProduct(int id, int NewProductId)
        {
        var Order = Read(id);

            if (Order != null) 
            {
                Order.ProductID = NewProductId;

                dbContext.SaveChanges();
            }
            //else
            //{
            //    throw new Exception("Error ID not found");
            //}

        }

        public void ChangeQuantity(int id, int Quantity)
        {
            var Order = Read(id);

            if (Order != null)
            {
                Order.Quantity = Quantity;

                dbContext.SaveChanges();
            }
            //else
            //{
            //    throw new Exception("Error ID not found");
            //}
        }

        public override Order Read(int id)
        {
            //dbContext.Orders.FirstOrDefault(x => x.OrderID == id);

            return ReadAll().FirstOrDefault(x => x.OrderID == id);
        
        
        
        }

        public override void Update(Order value)
        {
            //var OldData = Read(value.OrderID);

            //OldData.OrderDate = value.OrderDate;

            //OldData.Quantity = value.Quantity;

            //OldData.CustomerID = value.CustomerID;

            //OldData.ProductID = value.ProductID;


            var OldData = Read(value.OrderID);

            foreach (var item in OldData.GetType().GetProperties())
            {
                //  

                item.SetValue(OldData, item.GetValue(value));

            }

            dbContext.SaveChanges();
        }
    }
}
