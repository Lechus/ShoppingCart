using System.Collections.Generic;
using Supermarket.Checkout.Models;

namespace Supermarket.Checkout
{
    using Supermarket.Checkout.Services;

    public class Checkout
    {
        private readonly IGetProduct _productRepository;

        private readonly IOrderCalculationsService _orderCalculations;

        private readonly IDictionary<string, OrderItem> _orderItems;

        public Checkout(IGetProduct productRepository, IOrderCalculationsService orderCalculations)
        {
            _productRepository = productRepository;
            _orderCalculations = orderCalculations;
            _orderItems = new Dictionary<string, OrderItem>();
        }

        public void Scan(string sku)
        {
            var product = _productRepository.GetBySku(sku);

            if (_orderItems.TryGetValue(sku, out OrderItem orderItem))
            {
                orderItem.AddUnits(1);
            }
            else
            {
                _orderItems.Add(sku, new OrderItem(product.Sku, product.UnitPrice, 1));
            }
        }

        public decimal GetTotalPrice()
        {
            var total = 0m;

            if (_orderItems.Count == 0) return total;
            
            foreach (var orderItem in _orderItems)
            {
                total += _orderCalculations.GetTotalPrice(orderItem.Value);
            }

            return total;
        }
    }
}
