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
        public void CreateCrudMethodTest()
        {
            /// act
            var O = new Order { OrderID = 40, Quantity = 3, OrderDate = new DateTime(2023, 10, 20), CustomerID = 10, ProductID = 5 };
            // assert
            mockOrderRepo.Verify(x => x.Create(It.IsAny<Order>()), Times.Once);


        }


    }
}
