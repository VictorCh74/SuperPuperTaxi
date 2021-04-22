using System;
using System.Collections.Generic;
using System.Text;
using SuperPuperTaxi.Controllers;
using NUnit;
using NUnit.Framework;
using Moq;
using SuperPuperTaxi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace NUnitTestProject1
{
    [TestFixture]
    class AddDriverTest
    {
        [Test]
        public void CreateNewDriverTransfereDataToDB() {

            var mock = new Mock<IDriverRepository>();
            mock.Setup( d => d.Add(new TaxiDriver())).Returns(true);

            AddDriverController controller = new AddDriverController(mock.Object);
            var result = controller.CreateNewDriver(new TaxiDriver());

            Assert.IsInstanceOf<Task<IActionResult>>(result);
            
        }

    }
}
