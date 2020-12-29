using NUnit.Framework;

namespace Supermarket.Checkout.UnitTests
{
    using Moq;

    using Supermarket.Checkout.Models;
    using Supermarket.Checkout.Services;

    [TestFixture]
    public class WhenTestingCheckout
    {
        private Mock<IGetProduct> _getProductMock;

        [SetUp]
        public void SetUp()
        {
            _getProductMock = new Mock<IGetProduct>();
            this._getProductMock.Setup(x => x.GetBySku("A99")).Returns(new Product("A99", 0.50m));
            this._getProductMock.Setup(x => x.GetBySku("B15")).Returns(new Product("B15", 0.30m));
            this._getProductMock.Setup(x => x.GetBySku("C40")).Returns(new Product("C40", 0.60m));
        }


        [Test]
        public void CanScanAnItem()
        {
            var sut = this.GetSut();

            sut.Scan("A99");

            Assert.Pass();
        }

        [Test]
        public void GivenA99Worth50p_ThenTheTotalPriceReturnedIs50p()
        {
            var sut = this.GetSut();
            sut.Scan("A99");

            var actual = sut.GetTotalPrice();

            Assert.That(actual, Is.EqualTo(0.50m));
        }
        
        [Test]
        public void GivenANoItemsScanned_ThenTheTotalPriceReturnedIsZero()
        {
            var sut = this.GetSut();

            var actual = sut.GetTotalPrice();

            Assert.That(actual, Is.EqualTo(0m));
        }

        [Test]
        public void GivenFourItemsWorth1pound90p_ThenTheTotalPriceReturnedIs1pound90p()
        {
            var sut = this.GetSut();
            sut.Scan("A99");
            sut.Scan("B15");
            sut.Scan("C40");
            sut.Scan("A99");

            var actual = sut.GetTotalPrice();

            Assert.That(actual, Is.EqualTo(1.90m));
        }
        
        private Checkout GetSut()
        {

            return new Checkout(this._getProductMock.Object);
        }
    }
}