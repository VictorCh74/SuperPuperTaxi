using System;
using SuperPuperTaxi.Controllers;
using NUnit;
using NUnit.Framework;
using Moq;
using SuperPuperTaxi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NUnitTestProject1
{
    [TestFixture]
    public class CompleteOrderControllerTest
    {

        [Test]
        public void RecordOrderGivesOrderToRegisterOrder()
        {
            
            var mockContext = new Mock<IRepository>();
            mockContext.Setup(c => c.AddOrder(new Order())).Returns(true);
            CompleteOrder controller = new CompleteOrder(mockContext.Object);

            var result =  controller.RecordOrder(new Order());

            Assert.IsInstanceOf<Task<IActionResult>>(result);
            Assert.IsNotNull(result);
        }

        [Test]
        public void AcceptReurnsView()
        {
            var mockContext = new Mock<IRepository>();
            CompleteOrder controller = new CompleteOrder(mockContext.Object);
            var order = new Order()
            {
                Id = 1,
                OrderTime = DateTime.Now,
                DepartureTime = "10-00",
                From = "Отсюда",
                Phone = "2325478",
                Price = 10,
                TaxiDriverId = 12,
                To = "Туда"
            };

            var result = controller.Accept(order);

            Assert.IsNotNull(result);
            
        }
    }
}
