namespace Supermarket.Checkout.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using Supermarket.Checkout.Models;

    public class GetProductRepository : IGetProduct
    {
        private readonly IReadOnlyCollection<Product> _products = new List<Product>
                                                                      {
                                                                          new Product("A99", 0.50m),
                                                                          new Product("B15", 0.30m),
                                                                          new Product("C40", 0.60m)
                                                                      };

        public Product GetBySku(string sku)
        {
            return this._products.Single(x => x.Sku == sku);
        }
    }
}