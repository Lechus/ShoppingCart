namespace Supermarket.Checkout.Models
{
    using System;

    public class OrderItem
    {
        private int _units;

        public Guid Id { get; }

        public Product Product { get; }

        public int Units => _units;

        public OrderItem(Product product, int units = 1)
        {
            Id = Guid.NewGuid();
            Product = product;
            _units = units;
        }

        public void AddUnits(int units)
        {
            _units += units;
        }
    }
}