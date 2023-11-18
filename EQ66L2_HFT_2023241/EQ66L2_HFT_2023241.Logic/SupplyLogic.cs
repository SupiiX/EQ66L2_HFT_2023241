using System;
using System.Collections.Generic;
using System.Linq;
using EQ66L2_HFT_2023241.Logic.Interfaces;
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
            if (item.ProductName.Length < 3 )
            {
                throw new Exception("Product name is too short");

            }
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
            if (item.ManufacturerName.Length < 2 )
            {
                throw new Exception("Manufacturer name is too short ");

            }


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




        public void Query_1(string Country)
        {
            // parameteresen megadott orszaágban, kik gyártanak 




        }


        public IEnumerable<object> ManufactureProducts()
        {

            return ProductReposit.ReadAll().Select(x => new
            {
                name = x.ProductName,

                warranty = x.Warranty_year,

                a = x.Price,

            }).Where(x => x.warranty > 1 && x.a > 100);


        }























    }
}
