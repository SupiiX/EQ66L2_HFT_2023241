using EQ66L2_HFT_2023241.Models;
using EQ66L2_HFT_2023241.Repository.Database;
using EQ66L2_HFT_2023241.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EQ66L2_HFT_2023241.Repository
{
    public class ProductRepository : Reposit<Product>
    {
        public ProductRepository(DBContext dbContext) : base(dbContext)
        {
        }
      
       

        public void UpdateProduct(Product product)
        {


            var OldProduct = Read(product.ProductID);
            var oldprop = OldProduct.GetType().GetProperties();
      
   
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
        

            var OldData = Read(value.ProductID);

          if (OldData != null)
            {
                OldData.Warranty_year = value.Warranty_year;
                OldData.ProductName = value.ProductName;
                OldData.Manufacturer = value.Manufacturer;
                OldData.Orders = value.Orders;
                OldData.Price = value.Price;
                OldData.ManufacturerID = value.ManufacturerID;

                dbContext.SaveChanges();
            }
          

            
        }
    }
}
