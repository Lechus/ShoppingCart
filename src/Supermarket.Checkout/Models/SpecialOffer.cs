namespace Supermarket.Checkout.Models
{
    public class SpecialOffer
    {
        public string Sku { get; }

        public int Quantity { get; }

        public decimal OfferPrice { get; }

        public SpecialOffer(string sku, int quantity, decimal offerPrice)
        {
            Sku = sku;
            Quantity = quantity;
            OfferPrice = offerPrice;
        }
    }
}