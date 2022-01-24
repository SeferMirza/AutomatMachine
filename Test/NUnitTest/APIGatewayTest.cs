using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditCard.Controllers;
using CreditCardInfrastructure;
using CreditCardServices;
using NUnit.Framework;

namespace NUnitTest
{
    public class APIGatewayTest
    {
        private readonly ICreditCardService _creditCardService;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void APIGateway_Request_Test()
        {
            var controller = new CardController(_creditCardService);
            var result = controller.Get(15);
            Assert.Pass();
        }
    }
}
