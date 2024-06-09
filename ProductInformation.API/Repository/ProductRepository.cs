using Newtonsoft.Json;
using ProductInformation.Models;

namespace ProductInformation.API.Repository
{
    public class ProductRepository
    {
        private readonly List<Product>? _products;
        public ProductRepository()
        {
            var fileContent = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Product.json");
            _products = JsonConvert.DeserializeObject<List<Product>>(fileContent);
        }

        public List<Product>? GetProducts()
        {
            return _products;
        }

        public Product GetProduct(int productId)
        {
            return _products.FirstOrDefault(product => product.ProductId == productId);
        }
    }
}
