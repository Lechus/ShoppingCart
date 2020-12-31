namespace Supermarket.Checkout.Services
{
    using Supermarket.Checkout.Models;

    public interface IGetSpecialOffer
    {
        SpecialOffer GetBySku(string sku);

        decimal CalculateSpecialOfferPrice(OrderItem orderItem, SpecialOffer specialOffer);
    }
}