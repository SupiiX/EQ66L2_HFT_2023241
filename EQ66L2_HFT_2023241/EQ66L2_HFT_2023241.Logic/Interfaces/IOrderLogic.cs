using EQ66L2_HFT_2023241.Models;
using System.Collections.Generic;

namespace EQ66L2_HFT_2023241.Logic.Interfaces
{
    public interface IOrderLogic
    {
        
        void Create(Order item);
        void Delete(int id);
        Order Read(int id);
        IEnumerable<Order> ReadAll();
        void Update(Order value);
        
        //non cruds

        IEnumerable<PupularPrd> MostPopularPrd();
        IEnumerable<MoneySpend> MostMoneySpend();
        IEnumerable<CountryMostPopularPrd> PlaceOfPopularPrd();
        IEnumerable<DateOrders> MonthOrders(int Month);
        
    }
}