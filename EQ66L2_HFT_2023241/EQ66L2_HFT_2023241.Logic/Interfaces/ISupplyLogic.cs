using EQ66L2_HFT_2023241.Models;
using System.Collections.Generic;

namespace EQ66L2_HFT_2023241.Logic.Interfaces
{
    public interface ISupplyLogic
    {
        void ChangePlace(int id, string County);
        void Create_Manufacturer(Manufacturer item);
        void Create_Product(Product item);
        void Delete_Manufacturer(int id);
        void Delete_Product(int id);
        void Product_ChangeManufacturer(int id, int NewManufacturerId);
        IEnumerable<Manufacturer> ReadAll_Manufacturer();
        IEnumerable<Product> ReadAll_Product();
        Manufacturer Read_Manufacturer(int id);
        Product Read_Product(int id);
        void Update_Manufacturer(Manufacturer value);
        void Update_Product(Product value);
    }
}