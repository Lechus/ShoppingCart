using NUnit.Framework;

using Supermarket.Checkout.Models;
using Supermarket.Checkout.Services;

namespace Supermarket.Checkout.UnitTests
{
    [TestFixture]
    public class WhenTestingOrderCalculationsService
    {
        [Test]
        public void GivenTwoA99_ThenTheTotalPriceReturnedIs1pound0p()
        {
            var sut = new OrderCalculationsService();

            var actual = sut.GetTotalPrice(new OrderItem("A99", 0.50m, 2));

            Assert.That(actual, Is.EqualTo(1.0m));
        }

        [Test]
        public void GivenThreeA99_ThenTheTotalPriceReturnedIs1pound30p()
        {
            var sut = new OrderCalculationsService();

            var actual = sut.GetTotalPrice(new OrderItem("A99", 0.50m, 3));

            Assert.That(actual, Is.EqualTo(1.30m));
        }

        [Test]
        public void GivenTwoB15_ThenTheTotalPriceReturnedIs45p()
        {
            var sut = new OrderCalculationsService();

            var actual = sut.GetTotalPrice(new OrderItem("B15", 0.30m, 2));

            Assert.That(actual, Is.EqualTo(0.45m));
        }
    }
}