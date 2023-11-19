using EQ66L2_HFT_2023241.Models;
using EQ66L2_HFT_2023241.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EQ66L2_HFT_2023241.Logic;
using Microsoft.EntityFrameworkCore.InMemory.Query.Internal;
using System.Drawing;
using System.Xml.Linq;
using System.Runtime.Intrinsics.X86;
using Microsoft.EntityFrameworkCore;

namespace EQ66L2_HFT_2023241.Test
{
    [TestFixture]
    public class OrderLogicTester
    {

        OrderLogic Logic;

        Mock<IOrderRepository> mockOrderRepo;

        [SetUp]
        public void Init()
        {
            mockOrderRepo = new Mock<IOrderRepository>();

            mockOrderRepo.Setup(x => x.ReadAll()).Returns(new List<Order>()
            { 
                new Order(13, 10, new DateTime(2023, 11, 15), 4, 7, new Customer { }, new Product { ProductID = 7, Price = 450, ProductName = "Envy Printer", Warranty_year = 2, ManufacturerID = 8, Manufacturer = new Manufacturer { ManufacturerID = 8, ManufacturerName = "HP", PlaceOf = "United States" }  }),
                new Order(15, 9, new DateTime(2023, 11, 1), 2, 10, new Customer { }, new Product { ProductID = 10, Price = 300, ProductName = "ROG Gaming Mouse", Warranty_year = 1, ManufacturerID = 11 , Manufacturer = new Manufacturer { ManufacturerID = 11, ManufacturerName = "Asus", PlaceOf = "Taiwan" } }),
                new Order(16, 8, new DateTime(2023, 11, 18), 8, 20, new Customer { }, new Product { ProductID = 20, Price = 40, ProductName = "LED Bulbs (4 pack)", Warranty_year = 2, ManufacturerID = 21, Manufacturer = new Manufacturer { ManufacturerID = 21, ManufacturerName = "Philips", PlaceOf = "Netherlands" } }),
                new Order(17, 7, new DateTime(2023, 10, 10), 9, 16, new Customer { }, new Product { ProductID = 16, Price = 320, ProductName = "EOS DSLR Camera", Warranty_year = 2, ManufacturerID = 17, Manufacturer = new Manufacturer { ManufacturerID = 17, ManufacturerName = "Canon", PlaceOf = "Japan" }  }),
                new Order(18, 7, new DateTime(2023, 9, 22), 4, 3, new Customer { }, new Product { ProductID = 3, Price = 300, ProductName = "iPhone 13", Warranty_year = 1, ManufacturerID = 4, Manufacturer  = new Manufacturer { ManufacturerID = 4, ManufacturerName = "Apple", PlaceOf = "United States" } }),
                new Order(19, 5, new DateTime(2023, 1, 5), 2, 18, new Customer { }, new Product { ProductID = 18, Price = 500, ProductName = "Redmi Note 10", Warranty_year = 1, ManufacturerID = 19 , Manufacturer = new Manufacturer { ManufacturerID = 19, ManufacturerName = "Xiaomi", PlaceOf = "China" }}),

                //new Order { OrderID = 13, Quantity = 10, OrderDate = new DateTime(2023, 11, 15), CustomerID = 4, ProductID = 7 },
                //new Order { OrderID = 15, Quantity = 9, OrderDate = new DateTime(2023, 11, 1), CustomerID = 2, ProductID = 10 },
                //new Order { OrderID = 16, Quantity = 8, OrderDate = new DateTime(2023, 11, 18), CustomerID = 8, ProductID = 20 },
                //new Order { OrderID = 17, Quantity = 7, OrderDate = new DateTime(2023, 10, 10), CustomerID = 9, ProductID = 16 },
                //new Order { OrderID = 18, Quantity = 6, OrderDate = new DateTime(2023, 9, 22), CustomerID = 4, ProductID = 3 },
                //new Order { OrderID = 19, Quantity = 5, OrderDate = new DateTime(2023, 1, 5), CustomerID = 2, ProductID = 18 }


            }.AsQueryable());

          Logic = new OrderLogic(mockOrderRepo.Object);
        }

        [Test]
        public void Create_CorrectName()
        {
            var Corr = new Order { OrderDate = new DateTime(2023, 8, 5), Quantity = 4, CustomerID = 7 };

            Logic.Create(Corr);

            mockOrderRepo.Verify(x => x.Create(Corr), Times.Once);

        }


        [Test]
        public void Create_InvalidDate()
        {
            /// act
            var O = new Order { OrderID = 40, Quantity = 3, OrderDate = new DateTime(2024, 10, 20), CustomerID = 10, ProductID = 5 };
            // assert
            Assert.Throws<Exception>(() => Logic.Create(O));

        }

        [Test]
        public void Create_InvalidQuantity()
        {
            // act with wrong data 
            var invalidOrder = new Order { OrderID = 41, Quantity = -1, OrderDate = new DateTime(2023, 10, 20), CustomerID = 10, ProductID = 5 };

            // Assert
            Assert.Throws<Exception>(() => Logic.Create(invalidOrder));
        }

        [Test]
        public void Query2Tester()
        {
            var actual = Logic.Query_2().ToList();


            var expected = new List<PupularPrd>()
            {
                new PupularPrd() {Count = 10 , productName = "Envy Printer", MadeIn = "United States", ManufacturerName= "HP" },
                new PupularPrd() {Count = 9 , productName = "ROG Gaming Mouse", MadeIn = "Taiwan", ManufacturerName= "Asus" },
                new PupularPrd() {Count = 8, productName = "LED Bulbs (4 pack)", MadeIn = "Netherlands", ManufacturerName = "Philips" }

            };

            ;

          // Assert.AreEqual(actual, expected);
           //Assert.AreSame(actual, expected);


          //Assert.IsNotEmpty(actual); // jo

          //Assert.AreEqual(actual.Count, expected.Count);// ugyan annyi db
        }

    }
}
