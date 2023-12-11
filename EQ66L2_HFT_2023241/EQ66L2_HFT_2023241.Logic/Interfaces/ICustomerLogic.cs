using EQ66L2_HFT_2023241.Models;
using System.Collections.Generic;

namespace EQ66L2_HFT_2023241.Logic.Interfaces
{
    public interface ICustomerLogic
    {
        
        void Create(Customer item);
        void Delete(int id);
        Customer Read(int id);
        IEnumerable<Customer> ReadAll();
        void Update(Customer value);

    }
}