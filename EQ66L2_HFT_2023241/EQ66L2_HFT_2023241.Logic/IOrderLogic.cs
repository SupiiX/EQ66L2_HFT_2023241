using EQ66L2_HFT_2023241.Models;
using System.Collections.Generic;

namespace EQ66L2_HFT_2023241.Logic
{
    public interface IOrderLogic
    {
        void ChangeProduct(int id, int NewProductId);
        void ChangeQuantity(int id, int Quantity);
        void Create(Order item);
        void Delete(int id);
        Order Read(int id);
        IEnumerable<Order> ReadAll();
        void Update(Order value);
    }
}