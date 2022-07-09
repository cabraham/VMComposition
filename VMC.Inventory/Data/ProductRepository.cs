using VMC.Inventory.Models;

namespace VMC.Inventory.Data
{
    public class ProductRepository
    {
        private Dictionary<int, Product> productInventory;
        public ProductRepository()
        {
            productInventory = new Dictionary<int, Product>();
            foreach (var i in Enumerable.Range(1,5))
            {
                productInventory.Add(i, new Product { Id = i, Name = $"Product {i}" });
            }

            productInventory[1].Count = 3;
            productInventory[2].Count = 1;
            productInventory[3].Count = 6;
            productInventory[4].Count = 0;
            productInventory[5].Count = 5;
        }

        public Product Get(int productId)
        {
            return productInventory[productId];
        }
    }
}
