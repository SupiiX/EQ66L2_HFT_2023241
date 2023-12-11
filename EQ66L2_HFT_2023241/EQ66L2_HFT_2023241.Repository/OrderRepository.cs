using EQ66L2_HFT_2023241.Models;
using EQ66L2_HFT_2023241.Repository.Database;
using EQ66L2_HFT_2023241.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EQ66L2_HFT_2023241.Repository
{
    public class OrderRepository : Reposit<Order>
    {
        public OrderRepository(DBContext dbContext) : base(dbContext)
        {
        }


        public override Order Read(int id)
        {
            

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
