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
    }
}
