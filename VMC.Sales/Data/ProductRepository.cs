using VMC.Sales.Models;

namespace VMC.Sales.Data
{
    public class ProductRepository
    {
        private Dictionary<int, ProductPrice> productPrices;

        public ProductRepository()
        {
            productPrices = new Dictionary<int, ProductPrice>();
            foreach (var i in Enumerable.Range(1, 5))
            {
                productPrices.Add(i, new ProductPrice { Id = i, Price = (decimal)3.5 * i });
            }
        }

        public ProductPrice Get(int productId)
        {
            return productPrices[productId];
        }

    }
}
