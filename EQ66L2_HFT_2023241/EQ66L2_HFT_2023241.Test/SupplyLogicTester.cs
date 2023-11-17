using EQ66L2_HFT_2023241.Logic;
using EQ66L2_HFT_2023241.Models;
using EQ66L2_HFT_2023241.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EQ66L2_HFT_2023241.Test
{
    [TestFixture]
    public class SupplyLogicTester
    {

        SupplyLogic SupplyLogic;

        Mock<IProductRepository> mockProductRepo;

        Mock<IManufacturerRepository> mockManufacturerRepo;

        [SetUp]
        public void Init()
        {
           mockManufacturerRepo = new Mock<IManufacturerRepository>();
           mockProductRepo = new Mock<IProductRepository>();




           mockManufacturerRepo.Setup(x => x.ReadAll()).Returns(new List<Manufacturer>()
            {

              new Manufacturer { ManufacturerID = 17, ManufacturerName = "LG Electronics", PlaceOf = "South Korea" },
              new Manufacturer { ManufacturerID = 18, ManufacturerName = "Panasonic", PlaceOf = "Japan" },
              new Manufacturer { ManufacturerID = 19, ManufacturerName = "Dell", PlaceOf = "United States" },
              new Manufacturer { ManufacturerID = 20, ManufacturerName = "Siemens", PlaceOf = "Germany" }

            }.AsQueryable());

            mockProductRepo.Setup(x => x.ReadAll()).Returns(new List<Product>()
            {

                new Product { ProductID = 8, Price = 1200, ProductName = "MacBook Air", Warranty_year = 3, ManufacturerID = 14 },
                new Product { ProductID = 9, Price = 799, ProductName = "ThinkPad Laptop", Warranty_year = 2, ManufacturerID = 15 },
                new Product { ProductID = 10, Price = 299, ProductName = "Nokia Smartphone", Warranty_year = 1, ManufacturerID = 16 },
                new Product { ProductID = 11, Price = 599, ProductName = "LG 4K TV", Warranty_year = 2, ManufacturerID = 17 },
                new Product { ProductID = 12, Price = 499, ProductName = "Panasonic Microwave", Warranty_year = 1, ManufacturerID = 18 },
                new Product { ProductID = 13, Price = 899, ProductName = "Dell Gaming Laptop", Warranty_year = 2, ManufacturerID = 19 }

            }.AsQueryable());

            SupplyLogic = new SupplyLogic(mockProductRepo.Object, mockManufacturerRepo.Object);



        }



    } 



    
}
