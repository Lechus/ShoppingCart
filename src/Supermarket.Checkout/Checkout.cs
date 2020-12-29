using System.Collections.Generic;
using Supermarket.Checkout.Models;

namespace Supermarket.Checkout
{
    using Supermarket.Checkout.Services;

    public class Checkout
    {
        private readonly IGetProduct _productRepository;
        private readonly IDictionary<string, OrderItem> _orderItems;

        public Checkout(IGetProduct productRepository)
        {
            _productRepository = productRepository;
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
                _orderItems.Add(sku, new OrderItem(product, 1));
            }
        }

        public decimal GetTotalPrice()
        {
            var total = 0m;

            if (_orderItems.Count == 0) return total;
            
            foreach (var orderItem in _orderItems)
            {
                total += orderItem.Value.Units * orderItem.Value.Product.UnitPrice;
            }

            return total;
        }
    }
}
