using EQ66L2_HFT_2023241.Models;
using System.Collections.Generic;

namespace EQ66L2_HFT_2023241.Logic
{
    public interface ICustomerLogic
    {
        void ChangeEmail(int id, string email);
        void Create(Customer item);
        void Delete(int id);
        Customer Read(int id);
        IEnumerable<Customer> ReadAll();
        void Update(Customer value);
    }
}