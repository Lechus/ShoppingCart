namespace Supermarket.Checkout.Services
{
    using System.Linq;

    using Supermarket.Checkout.Models;

    public class OrderCalculationsService
    {
        private SpecialOffer[] specialOffers;

        public OrderCalculationsService()
        {
            specialOffers = new SpecialOffer[2]
                                {
                                    new SpecialOffer("A99", 3, 1.30m), 
                                    new SpecialOffer("B15", 2, 0.45m) 
                                };
        }

        public decimal GetTotalPrice(OrderItem orderItem)
        {
            var specialOffer =
                specialOffers.SingleOrDefault(x => x.Sku == orderItem.ProductSku && x.Quantity == orderItem.Units);

            if (specialOffer != null) return specialOffer.OfferPrice;

            return orderItem.UnitPrice * orderItem.Units;
        }
    }
}