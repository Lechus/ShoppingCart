using NUnit.Framework;

namespace Supermarket.Checkout.UnitTests
{
    [TestFixture]
    public class WhenTestingCheckout
    {
        [Test]
        public void CanScanAnItem()
        {
            var sut = new Checkout();

            sut.Scan("A99");

            Assert.Pass();
        }
        
        [Test]
        public void GivenA99Worth50p_ThenTheTotalPriceReturnedIs50p()
        {
            var sut = new Checkout();
            sut.Scan("A99");

            var actual = sut.GetTotalPrice();

            Assert.That(actual, Is.EqualTo(0.50m));
        }
        
        [Test]
        public void GivenANoItemsScanned_ThenTheTotalPriceReturnedIsZero()
        {
            var sut = new Checkout();

            var actual = sut.GetTotalPrice();

            Assert.That(actual, Is.EqualTo(0m));
        }
    }
}