using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EQ66L2_HFT_2023241.Models;
using EQ66L2_HFT_2023241.Repository;


namespace EQ66L2_HFT_2023241.Logic
{
    public class CustomerLogic
    {
        ICustomerRepository CustomerRepository;

        public CustomerLogic(ICustomerRepository customerRepository)
        {
            CustomerRepository = customerRepository;
        }

        // CRUD

        
        public void Create(Customer item)
        {
            CustomerRepository.Create(item);
        }

        public void Delete(int id)
        {
            CustomerRepository.Delete(id);
        }

        public Customer Read(int id)
        {
            return CustomerRepository.Read(id);
        }

        public IEnumerable<Customer> ReadAll()
        {
            return CustomerRepository.ReadAll();
        }

        public void Update(Customer value)
        {
            CustomerRepository.Update(value);
        }

        public void ChangeEmail(int id, string email)
        {
            CustomerRepository.ChangeEmail(id, email);
        }
    
        /// Non CRUD


    
    
    }
}
