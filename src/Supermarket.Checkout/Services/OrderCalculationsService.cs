using Supermarket.Checkout.Models;

namespace Supermarket.Checkout.Services
{
    public class OrderCalculationsService : IOrderCalculationsService
    {
        private readonly IGetSpecialOffer _specialOfferRepository;

        public OrderCalculationsService(IGetSpecialOffer specialOfferRepository)
        {
            _specialOfferRepository = specialOfferRepository;
        }

        public decimal GetTotalPrice(OrderItem orderItem)
        {
            var specialOffer = _specialOfferRepository.GetBySku(orderItem.ProductSku);

            if (specialOffer != null) return CalculateSpecialOfferPrice(orderItem, specialOffer);

            return CalculatePrice(orderItem);
        }

        private decimal CalculateSpecialOfferPrice(OrderItem orderItem, SpecialOffer specialOffer)
        {
            var specialOfferUnits = orderItem.Units / specialOffer.Quantity;
            var regularPriceUnits = orderItem.Units % specialOffer.Quantity;

            return CalculatePrice(specialOffer.OfferPrice, specialOfferUnits) + CalculatePrice(orderItem.UnitPrice, regularPriceUnits);
        }

        private decimal CalculatePrice(OrderItem orderItem)
        {
            return CalculatePrice(orderItem.UnitPrice, orderItem.Units);
        }

        private decimal CalculatePrice(decimal unitPrice, int units)
        {
            return unitPrice * units;
        }
    }
}