using EQ66L2_HFT_2023241.Logic;
using EQ66L2_HFT_2023241.Models;
using EQ66L2_HFT_2023241.Repository.Interfaces;
using Microsoft.EntityFrameworkCore.InMemory.Query.Internal;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EQ66L2_HFT_2023241.Test
{
    [TestFixture]
    public class ProductLogicTester
    {

        

        ProductLogic ProductLogic;

        Mock<IReposit<Product>> mockProductRepo;

        Mock<IReposit<Manufacturer>> mockManufacturerRepo;

        [SetUp]
        public void Init()
        {
           mockManufacturerRepo = new Mock<IReposit<Manufacturer>>();
           mockProductRepo = new Mock<IReposit<Product>>();




            mockManufacturerRepo.Setup(x => x.ReadAll()).Returns(new List<Manufacturer>()
            {

                 new Manufacturer { ManufacturerID = 17, ManufacturerName = "LG Electronics", PlaceOf = "South Korea", Products = new List<Product> { new Product { ProductID = 11, Price = 599, ProductName = "LG 4K TV", Warranty_year = 2 } } },
                new Manufacturer { ManufacturerID = 18, ManufacturerName = "Panasonic", PlaceOf = "Japan", Products = new List<Product> { new Product { ProductID = 12, Price = 499, ProductName = "Panasonic Microwave", Warranty_year = 1 } } },
                new Manufacturer { ManufacturerID = 19, ManufacturerName = "Dell", PlaceOf = "United States", Products = new List<Product> { new Product { ProductID = 13, Price = 899, ProductName = "Dell Gaming Laptop", Warranty_year = 2 }, new Product { ProductID = 9, Price = 799, ProductName = "Notabook Ultra Laptop", Warranty_year = 2 } } },
                new Manufacturer { ManufacturerID = 20, ManufacturerName = "Siemens", PlaceOf = "Germany", Products = new List<Product> { new Product { ProductID = 8, Price = 1200, ProductName = "MacBook Air", Warranty_year = 3 }, new Product { ProductID = 10, Price = 299, ProductName = "Nokia Smartphone", Warranty_year = 1 } } },



              //new Manufacturer { ManufacturerID = 17, ManufacturerName = "LG Electronics", PlaceOf = "South Korea" },
              //new Manufacturer { ManufacturerID = 18, ManufacturerName = "Panasonic", PlaceOf = "Japan" },
              //new Manufacturer { ManufacturerID = 19, ManufacturerName = "Dell", PlaceOf = "United States" },
              //new Manufacturer { ManufacturerID = 20, ManufacturerName = "Siemens", PlaceOf = "Germany" }

            }.AsQueryable()) ;

            mockProductRepo.Setup(x => x.ReadAll()).Returns(new List<Product>()
            {

                new Product { ProductID = 8, Price = 1200, ProductName = "MacBook Air", Warranty_year = 3, ManufacturerID = 120, Manufacturer = new Manufacturer { ManufacturerID = 20, ManufacturerName = "Siemens", PlaceOf = "Germany" }},
                new Product { ProductID = 9, Price = 799, ProductName = "Notabook Ultra Laptop", Warranty_year = 2, ManufacturerID = 15, Manufacturer = new Manufacturer { ManufacturerID = 19, ManufacturerName = "Dell", PlaceOf = "United States" }},
                new Product { ProductID = 10, Price = 299, ProductName = "Nokia Smartphone", Warranty_year = 1, ManufacturerID = 20, Manufacturer = new Manufacturer { ManufacturerID = 20, ManufacturerName = "Siemens", PlaceOf = "Germany" }},
                new Product { ProductID = 11, Price = 599, ProductName = "LG 4K TV", Warranty_year = 2, ManufacturerID = 17, Manufacturer = new Manufacturer { ManufacturerID = 17, ManufacturerName = "LG Electronics", PlaceOf = "South Korea" } },
                new Product { ProductID = 12, Price = 499, ProductName = "Panasonic Microwave", Warranty_year = 1, ManufacturerID = 18,Manufacturer =  new Manufacturer { ManufacturerID = 18, ManufacturerName = "Panasonic", PlaceOf = "Japan" } },
                new Product { ProductID = 13, Price = 899, ProductName = "Dell Gaming Laptop", Warranty_year = 2, ManufacturerID = 19, Manufacturer =  new Manufacturer { ManufacturerID = 19, ManufacturerName = "Dell", PlaceOf = "United States" } }

            }.AsQueryable());

            //SupplyLogic = new SupplyLogic(mockProductRepo.Object, mockManufacturerRepo.Object);

            ProductLogic = new ProductLogic(mockProductRepo.Object);

          }

        [Test]
        public void Create_Product_Correct()
        {
            var Product = new Product() { ProductName = "CocaCola", Price = 500};

            ProductLogic.Create(Product);

            mockProductRepo.Verify(x => x.Create(Product), Times.Once);
        }
        [Test]
        public void Create_Product_PriceExeption()
        {

            var Product = new Product() { ProductName = "Jeans", Price = -120 };

         //   mockProductRepo.Verify(x => x.Create(Product), Times.Never);

            Assert.Throws<Exception>(() => ProductLogic.Create(Product));
        }

        [Test]
        public void ManufactureByCountriesTester()
        {
            var country = "Germany";
            var actualResult = ProductLogic.ManufactureByCountries(country).ToList();

            var expectedResult = new List<ManufactureByCountry>
            {
                new ManufactureByCountry { ManufaturerName = "Siemens", ProductName = "MacBook Air" ,MadeIn = country},

            
            };

           // Assert.AreEqual(expectedResult, actualResult);

            Assert.IsNotEmpty(actualResult);
            

        }

        [Test]
        public void ManufactureByCountriesInvalidTester() 
        {
            var InvalidCountry = "Ge";

            Assert.Throws<Exception>(() => ProductLogic.ManufactureByCountries(InvalidCountry));

        }



        }
        



    } 



    

