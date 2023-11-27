using EQ66L2_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EQ66L2_HFT_2023241.Repository
{
    public class ProductRepository : Reposit<Product>, IProductRepository
    {
        public ProductRepository(DBContext dbContext) : base(dbContext)
        {
        }

        //  
        public void ChangeManufacturer(int id, int NewManufacturerId)
        {
            var Product = Read(id);
            if (Product != null)
            {
                Product.ManufacturerID = NewManufacturerId;

                dbContext.SaveChanges();

            }
            //else
            //{
            //    throw new Exception("Error ID not found");
            //}
        }

        public void UpdateProduct(Product product)
        {

            //which product do we wanna update 
            var OldProduct = Read(product.ProductID);
            var oldprop = OldProduct.GetType().GetProperties();
            //List<string> strings = new List<string>();
            //foreach (var prop in oldprop)
            //{
            //    strings.Add(prop.GetValue(prop, OldProduct));

            //}
       
            // OldProduct.ProductID = product.ProductID;

            OldProduct.ProductName = product.ProductName;

            OldProduct.ManufacturerID = product.ManufacturerID;

            OldProduct.Manufacturer = product.Manufacturer;

            OldProduct.Orders = product.Orders;

            OldProduct.Price = product.Price;

            OldProduct.Warranty_year = product.Warranty_year;

            dbContext.SaveChanges();
            
        }

        public override Product Read(int id)
        {
            return ReadAll().FirstOrDefault(x => x.ProductID == id);
        }

        public override void Update(Product value)
        {
            //var OldProduct = Read(value.ProductID);

            //OldProduct.ProductName = value.ProductName;

            //OldProduct.ManufacturerID = value.ManufacturerID;

            //OldProduct.Manufacturer = value.Manufacturer;

            //OldProduct.Orders = value.Orders;

            //OldProduct.Price = value.Price;

            //OldProduct.Warranty_year = value.Warranty_year;

            var OldData = Read(value.ProductID);

            foreach (var item in OldData.GetType().GetProperties())
            {
                //  

                item.SetValue(OldData, item.GetValue(value));

            }
            dbContext.SaveChanges();

            dbContext.SaveChanges();
        }
    }
}
