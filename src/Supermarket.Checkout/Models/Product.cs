
namespace Supermarket.Checkout.Models
{
    public class Product
    {
        public string Sku { get; }
        public decimal UnitPrice { get; }

        public Product(string sku, decimal unitPrice)
        {
            Sku = sku;
            UnitPrice = unitPrice;
        }
    }
}
