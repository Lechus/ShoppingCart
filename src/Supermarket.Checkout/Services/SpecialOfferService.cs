using System.Collections.Generic;
using System.Linq;
using Supermarket.Checkout.Models;

namespace Supermarket.Checkout.Services
{
    public class SpecialOfferService : IGetSpecialOffer
    {
        private readonly IReadOnlyCollection<SpecialOffer> _specialOffers = new List<SpecialOffer>
                                                                      {
                                                                          new SpecialOffer("A99", 3, 1.30m),
                                                                          new SpecialOffer("B15", 2, 0.45m)
                                                                      };

        public SpecialOffer GetBySku(string sku)
        {
            return _specialOffers.Single(x => x.Sku == sku);
        }

        public decimal CalculateSpecialOfferPrice(OrderItem orderItem, SpecialOffer specialOffer)
        {
            var specialOfferUnits = orderItem.Units / specialOffer.Quantity;
            var regularPriceUnits = orderItem.Units % specialOffer.Quantity;

            return CalculatePrice(specialOffer.OfferPrice, specialOfferUnits) + CalculatePrice(orderItem.UnitPrice, regularPriceUnits);
        }

        private decimal CalculatePrice(decimal unitPrice, int units)
        {
            return unitPrice * units;
        }
    }
}