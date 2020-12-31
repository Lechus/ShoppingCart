namespace Supermarket.Checkout.Models
{
    using System;

    public class OrderItem
    {
        private int _units;

        public Guid Id { get; }

        public string ProductSku { get; }
        public decimal UnitPrice { get; }

        public int Units => _units;

        public OrderItem(string sku, decimal unitPrice, int units = 1)
        {
            Id = Guid.NewGuid();
            ProductSku = sku;
            UnitPrice = unitPrice;
            _units = units;
        }

        public void AddUnits(int units)
        {
            _units += units;
        }
    }
}