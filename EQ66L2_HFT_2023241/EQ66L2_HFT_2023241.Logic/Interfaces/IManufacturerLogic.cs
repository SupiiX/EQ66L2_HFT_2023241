using EQ66L2_HFT_2023241.Models;
using System.Collections.Generic;

namespace EQ66L2_HFT_2023241.Logic.Interfaces
{
    public interface IManufacturerLogic
    {
        void Create(Manufacturer item);
        void Delete(int id);
        Manufacturer Read(int id);
        IEnumerable<Manufacturer> ReadAll();
        void Update(Manufacturer value);
    }
}