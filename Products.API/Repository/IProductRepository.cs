using Products.API.Models;

namespace Products.API.Repository
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts();
        public IEnumerable<Product> GetAllProducts(int? amount);
        public Product GetProductById(int id);
        public bool CreateProduct(Product product);
        public Product UpdateProduct(int id, Product product);
        public bool DeleteProduct(int id);
    }
}
