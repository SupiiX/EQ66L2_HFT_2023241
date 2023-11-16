using System;
using System.Collections.Generic;
using System.Linq;
using EQ66L2_HFT_2023241.Models;
using EQ66L2_HFT_2023241.Repository;


namespace EQ66L2_HFT_2023241.Logic
{
    // Product && Manufacturer Reposit
    public class SupplyLogic : ISupplyLogic
    {
        IProductRepository ProductReposit;

        IManufacturerRepository ManufacturerReposit;

        public SupplyLogic(IProductRepository productReposit, IManufacturerRepository manufacturerReposit)
        {
            ProductReposit = productReposit;
            ManufacturerReposit = manufacturerReposit;
        }

        // CRUD 


        ////  Product

        public void Create_Product(Product item)
        {
            ProductReposit.Create(item);
        }

        public void Delete_Product(int id)
        {
            ProductReposit.Delete(id);
        }

        public Product Read_Product(int id)
        {
            return ProductReposit.Read(id);
        }

        public IEnumerable<Product> ReadAll_Product()
        {
            return ProductReposit.ReadAll();
        }

        public void Update_Product(Product value)
        {
            ProductReposit.Update(value);
        }

        public void Product_ChangeManufacturer(int id, int NewManufacturerId)
        {
            ProductReposit.ChangeManufacturer(id, NewManufacturerId);

        }


        ///// Manufacturer 

        public void Create_Manufacturer(Manufacturer item)
        {
            ManufacturerReposit.Create(item);
        }

        public void Delete_Manufacturer(int id)
        {
            ManufacturerReposit.Delete(id);
        }

        public Manufacturer Read_Manufacturer(int id)
        {
            return ManufacturerReposit.Read(id);
        }

        public IEnumerable<Manufacturer> ReadAll_Manufacturer()
        {
            return ManufacturerReposit.ReadAll();
        }

        public void Update_Manufacturer(Manufacturer value)
        {
            ManufacturerReposit.Update(value);
        }

        public void ChangePlace(int id, string County)
        {
            ManufacturerReposit.ChangePlace(id, County);
        }

        //////////// Non Crud methods


        public IEnumerable<object> ManufactureProducts()
        {

            return ProductReposit.ReadAll().Select(x => new
            {
                place = x.Manufacturer.PlaceOf,

                gari = x.Warranty_year,

                emberot = x.Customers.Count(),


            }).Where(x => x.place != "China" && x.gari > 1 && x.emberot > 1);


        }























    }
}
