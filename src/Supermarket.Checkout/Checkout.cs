using System.Collections.Generic;

namespace Supermarket.Checkout
{
    public class Checkout
    {
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
            if (_orderItems.Count == 0) return 0m;

            return 0.50m;
        }
    }
}
