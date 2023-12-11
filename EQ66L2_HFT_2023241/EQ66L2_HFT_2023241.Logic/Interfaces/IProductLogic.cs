using EQ66L2_HFT_2023241.Models;
using System.Linq;

namespace EQ66L2_HFT_2023241.Logic.Interfaces
{
    public interface IProductLogic
    {
        void Create(Product item);
        void Delete(int id);
        Product Read(int id);
        IQueryable<Product> ReadAll();
        void Update(Product value);
    }
}