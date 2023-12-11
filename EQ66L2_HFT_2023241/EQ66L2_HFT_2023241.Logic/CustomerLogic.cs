using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EQ66L2_HFT_2023241.Logic.Interfaces;
using EQ66L2_HFT_2023241.Models;
using EQ66L2_HFT_2023241.Repository.Interfaces;


namespace EQ66L2_HFT_2023241.Logic
{
    public class CustomerLogic : ICustomerLogic
    {

        IReposit<Customer> reposit;



        public CustomerLogic(IReposit<Customer> reposit)
        {
            this.reposit = reposit;
        }

        // CRUD


        public void Create(Customer item)
        {
            if (item.CustomerName.Length < 3 || item.CustomerName.Length == 0 )
            {
                throw new Exception("Name is too short");

            }
            if (!item.Email.Contains('@'))
            {
                throw new Exception("Invalid Email");

            }

             this.reposit.Create(item);
        }

        public void Delete(int id)
        {
            this.reposit.Delete(id);
        }

        public Customer Read(int id)
        {
            return this.reposit.Read(id);
        }

        public IEnumerable<Customer> ReadAll()
        {
            return this.reposit.ReadAll();
        }

        public void Update(Customer value)
        {
            this.reposit.Update(value);
        }

        
      




    }
}
