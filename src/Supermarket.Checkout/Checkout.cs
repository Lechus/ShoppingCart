using System.Collections.Generic;

namespace Supermarket.Checkout
{
    using System.Linq;

    using Supermarket.Checkout.Models;

    public class Checkout
    {
        private readonly IReadOnlyCollection<Product> _products = new List<Product>
                                                                           {
                                                                               new Product("A99", 0.50m),
                                                                               new Product("B15", 0.30m),
                                                                               new Product("C40", 0.60m)
                                                                           };
        private readonly IDictionary<string, int> _orderItems;

        public Checkout()
        {
            _orderItems = new Dictionary<string, int>();
        }

        public void Scan(string sku)
        {
            if (_orderItems.TryGetValue(sku, out int units))
            {
                _orderItems[sku] = ++units;
            }
            else
            {
                _orderItems.Add(sku, 1);
            }
        }

        public decimal GetTotalPrice()
        {
            var total = 0m;

            if (_orderItems.Count == 0) return total;
            
            foreach (var orderItem in this._orderItems)
            {
                var product = this._products.Single(x => x.Sku == orderItem.Key);
                total += orderItem.Value * product.UnitPrice;
            }

            return total;
        }
    }
}
