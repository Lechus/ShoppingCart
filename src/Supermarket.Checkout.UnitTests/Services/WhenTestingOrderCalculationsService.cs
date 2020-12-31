using Moq;
using NUnit.Framework;
using Supermarket.Checkout.Models;
using Supermarket.Checkout.Services;

namespace Supermarket.Checkout.UnitTests.Services
{
    [TestFixture]
    public class WhenTestingOrderCalculationsService
    {
        [SetUp]
        public void SetUp()
        {
            _getSpecialOfferMock = new Mock<IGetSpecialOffer>();
        }

        private Mock<IGetSpecialOffer> _getSpecialOfferMock;


        [Test]
        public void GivenOrderItemWithoutSpecialOffer_ThenTheTotalPriceReturnedIs1pound0p()
        {
            var sut = GetSut();

            var actual = sut.GetTotalPrice(new OrderItem("A99", 0.50m, 2));

            Assert.That(actual, Is.EqualTo(1.0m));
        }

        [Test]
        public void GivenOrderItemWithSpecialOffer_ThenTheTotalPriceReturnedIsExpected()
        {
            var sut = GetSut();
            var orderItem = new OrderItem("A99", 0.50m, 3);
            var expected = 1.30m;
            var specialOffer = new SpecialOffer("A99", 3, expected);

            _getSpecialOfferMock.Setup(x => x.GetBySku(orderItem.ProductSku)).Returns(specialOffer);
            _getSpecialOfferMock.Setup(x => x.CalculateSpecialOfferPrice(orderItem, specialOffer)).Returns(expected);


            var actual = sut.GetTotalPrice(orderItem);

            Assert.That(actual, Is.EqualTo(expected));
        }

        private OrderCalculationsService GetSut()
        {
            return new OrderCalculationsService(_getSpecialOfferMock.Object);
        }
    }
}