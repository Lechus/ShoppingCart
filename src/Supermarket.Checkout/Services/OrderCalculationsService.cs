using Supermarket.Checkout.Models;

namespace Supermarket.Checkout.Services
{
    public class OrderCalculationsService : IOrderCalculationsService
    {
        private readonly IGetSpecialOffer _specialOfferService;

        public OrderCalculationsService(IGetSpecialOffer specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }

        public decimal GetTotalPrice(OrderItem orderItem)
        {
            var specialOffer = _specialOfferService.GetBySku(orderItem.ProductSku);

            if (specialOffer != null) return _specialOfferService.CalculateSpecialOfferPrice(orderItem, specialOffer);

            return CalculatePrice(orderItem.UnitPrice, orderItem.Units);
        }

        private decimal CalculatePrice(decimal unitPrice, int units)
        {
            return unitPrice * units;
        }
    }
}