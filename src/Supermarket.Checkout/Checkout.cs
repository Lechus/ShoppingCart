using System.Collections.Generic;
using System.Linq;
using Supermarket.Checkout.Models;

namespace Supermarket.Checkout
{
    public class Checkout
    {
        private readonly IReadOnlyCollection<Product> _products = new List<Product>
                                                                           {
                                                                               new Product("A99", 0.50m),
                                                                               new Product("B15", 0.30m),
                                                                               new Product("C40", 0.60m)
                                                                           };
        private readonly IDictionary<string, OrderItem> _orderItems;

        public Checkout()
        {
            _orderItems = new Dictionary<string, OrderItem>();
        }

        public void Scan(string sku)
        {
            var product = _products.Single(x => x.Sku == sku);

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
