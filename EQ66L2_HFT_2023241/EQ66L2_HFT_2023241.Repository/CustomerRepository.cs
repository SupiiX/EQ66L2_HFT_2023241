using EQ66L2_HFT_2023241.Models;
using EQ66L2_HFT_2023241.Repository.Database;
using EQ66L2_HFT_2023241.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EQ66L2_HFT_2023241.Repository
{
    public class CustomerRepository : Reposit<Customer>
    {
        //ctor
        public CustomerRepository(DBContext dbContext) : base(dbContext)
        {
        }


        public override Customer Read(int id)
        {
            return ReadAll().FirstOrDefault(x => x.CustomerID ==id);
        }

        public override void Update(Customer value)
        {
            var OldData = Read(value.CustomerID);

            foreach (var item in OldData.GetType().GetProperties())
            {
                 

                item.SetValue(OldData, item.GetValue(value));

            }
            dbContext.SaveChanges();
        }
    }
}
