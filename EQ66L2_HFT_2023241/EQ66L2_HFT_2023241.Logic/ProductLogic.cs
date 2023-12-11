﻿using EQ66L2_HFT_2023241.Logic.Interfaces;
using EQ66L2_HFT_2023241.Models;
using EQ66L2_HFT_2023241.Repository;
using EQ66L2_HFT_2023241.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EQ66L2_HFT_2023241.Logic
{
    public class ProductLogic : IProductLogic
    {
        IReposit<Product> reposit;

        public ProductLogic(IReposit<Product> reposit)
        {
            this.reposit = reposit;
        }



        public void Create(Product item)
        {
            if (item.ProductName.Length < 3)
            {
                throw new Exception("Product name is too short");

            }
            if (item.Price <= 0)
            {
                throw new Exception("Price cant be 0 or lower");

            }

            this.reposit.Create(item);
        }

        public void Delete(int id)
        {
            this.reposit.Delete(id);
        }

        public Product Read(int id)
        {
            return this.reposit.Read(id);
        }

        public IQueryable<Product> ReadAll()
        {
            return this.reposit.ReadAll();
        }

        public void Update(Product value)
        {
            this.reposit.Update(value);
        }







    }
}
