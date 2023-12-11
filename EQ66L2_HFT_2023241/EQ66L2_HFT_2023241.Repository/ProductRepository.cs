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

            foreach (var item in OldData.GetType().GetProperties())
            {
                

                item.SetValue(OldData, item.GetValue(value));

            }
            dbContext.SaveChanges();

            dbContext.SaveChanges();
        }
    }
}
