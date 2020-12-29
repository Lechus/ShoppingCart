namespace Supermarket.Checkout.Services
{
    using Supermarket.Checkout.Models;

    public interface IGetProduct
    {
        Product GetBySku(string sku);
    }
}