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
                new Order { OrderID = 13, Quantity = 5, OrderDate = new DateTime(2023, 11, 15), CustomerID = 4, ProductID = 7},
                new Order { OrderID = 15, Quantity = 4, OrderDate = new DateTime(2023, 11, 1), CustomerID = 2, ProductID = 10 },
                new Order { OrderID = 16, Quantity = 7, OrderDate = new DateTime(2023, 11, 18), CustomerID = 8, ProductID = 20 },
                new Order { OrderID = 17, Quantity = 1, OrderDate = new DateTime(2023, 10, 10), CustomerID = 9, ProductID = 16 },
                new Order { OrderID = 18, Quantity = 6, OrderDate = new DateTime(2023, 9, 22), CustomerID = 4, ProductID = 3 },
                new Order { OrderID = 19, Quantity = 3, OrderDate = new DateTime(2023, 1, 5), CustomerID = 2, ProductID = 18 }


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
             new PupularPrd() { productName = "LED Bulbs (4 pack)", Count = 7, ManufacturerName = "Philips", MadeIn = "Netherlands" },
             new PupularPrd() { productName = "iPhone 13", Count = 6, ManufacturerName = "Apple", MadeIn = "United States" },
             new PupularPrd() { productName = "UltraWide Monitor", Count = 5, ManufacturerName = "LG", MadeIn = "South Korea" }

            };
         
            // 
            Assert.AreEqual(expected, actual);

        }







    }
}
