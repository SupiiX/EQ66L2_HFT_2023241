using Castle.Core.Resource;
using EQ66L2_HFT_2023241.Logic;
using EQ66L2_HFT_2023241.Logic.Interfaces;
using EQ66L2_HFT_2023241.Models;
using EQ66L2_HFT_2023241.Repository.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EQ66L2_HFT_2023241.Test
{

    [TestFixture]
    public class CustomerLogicTester
    {

        CustomerLogic Logic;

        Mock<IReposit<Customer>> mockCustomerRepo;

        [SetUp]
        public void Inint()
        {
            mockCustomerRepo = new Mock<IReposit<Customer>>();

            mockCustomerRepo.Setup(x => x.ReadAll()).Returns(new List<Customer>()
            {

               new Customer { CustomerID = 15, CustomerName = "László", Email = "laszlo@example.com" },
               new Customer { CustomerID = 17, CustomerName = "Csaba", Email = "csaba@example.com" },
                new Customer { CustomerID = 18, CustomerName = "Réka", Email = "reka@example.com" },
                new Customer { CustomerID = 19, CustomerName = "Zoltán", Email = "zoltan@example.com" },
                new Customer { CustomerID = 20, CustomerName = "Dóra", Email = "dora@example.com" },
                new Customer { CustomerID = 21, CustomerName = "Attila", Email = "attila@example.com" },




            }.AsQueryable());

            Logic = new CustomerLogic(mockCustomerRepo.Object);
        }

        [Test]
        public void CreateCorrect()
        {
            var I = new Customer() { CustomerID = 5, CustomerName = "Alfonz", Email = "Alfonz@example.hu" };

           Logic.Create(I);

            mockCustomerRepo.Verify(x => x.Create(I), Times.Once);

        }

        [Test]
        public void CreateInvalidName()
        {
            var I = new Customer() { CustomerID = 10, CustomerName = "Te" };

            Assert.Throws<Exception>(() => Logic.Create(I));

        }
        [Test]
        public void CreateInvalidEmail()
        {
            var I = new Customer() { CustomerName = "Gyuszi", Email = "gyuszikaVMi" };

            Assert.Throws<Exception>(() => Logic.Create(I));

        }

    }
}
