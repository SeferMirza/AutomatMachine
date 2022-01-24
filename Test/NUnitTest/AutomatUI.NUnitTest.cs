using AutomatUI.Controllers;
using AutomatUI.Models;
using Common;
using Data.Repository;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NUnitTest
{
    public class AutomatUI_HomeController_Test
    {
        private IRepository _repository;

        [SetUp]
        public void Setup()
        {
            _repository = new Repository();
        }

        [Test]
        public void AutomatUI_HomeController_Index_Test()
        {
            var mock = new Mock<ILogger<HomeController>>();
            ILogger<HomeController> logger = mock.Object;

            //or use this short equivalent 
            logger = Mock.Of<ILogger<HomeController>>();

            HomeController controller = new HomeController(logger, _repository);

            ViewModel model = new ViewModel();
            model.SlotId = 1;
            model.Adet = 1;
            model.OdemeYontemi = "Nakit";
            JsonMessage result = (JsonMessage)controller.Index(model);

            Assert.AreEqual("İşlem Tamam!", result.Body);
        }
    }
}
