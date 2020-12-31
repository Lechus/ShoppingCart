namespace Supermarket.Checkout.Services
{
    using Supermarket.Checkout.Models;

    public interface IGetSpecialOffer
    {
        SpecialOffer GetBySku(string sku);
    }
}