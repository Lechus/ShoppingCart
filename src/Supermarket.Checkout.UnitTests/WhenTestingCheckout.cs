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
    }
}