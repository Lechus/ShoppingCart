using NUnit.Framework;
using Supermarket.Checkout.Models;
using Supermarket.Checkout.Services;

namespace Supermarket.Checkout.UnitTests.Services
{
    [TestFixture]
    public class WhenTestingSpecialOfferService
    {
        [Test]
        public void GivenThreeA99_ThenTheTotalPriceReturnedIs1pound30p()
        {
            var sut = new SpecialOfferService();
            var orderItem = new OrderItem("A99", 0.50m, 3);
            var specialOffer = new SpecialOffer("A99", 3, 1.30m);

            var actual = sut.CalculateSpecialOfferPrice(orderItem, specialOffer);

            Assert.That(actual, Is.EqualTo(1.30m));
        }


        [Test]
        public void GivenTwoB15_ThenTheTotalPriceReturnedIs45p()
        {
            var sut = new SpecialOfferService();
            var specialOffer = new SpecialOffer("B15", 2, 0.45m);
            var orderItem = new OrderItem("B15", 0.30m, 2);

            var actual = sut.CalculateSpecialOfferPrice(orderItem, specialOffer);

            Assert.That(actual, Is.EqualTo(0.45m));
        }

        [Test]
        public void GivenThreeB15_ThenTheTotalPriceReturnedIs75p()
        {
            var sut = new SpecialOfferService();
            var specialOffer = new SpecialOffer("B15", 2, 0.45m);
            var orderItem = new OrderItem("B15", 0.30m, 3);

            var actual = sut.CalculateSpecialOfferPrice(orderItem, specialOffer);

            Assert.That(actual, Is.EqualTo(0.75m));
        }
    }
}