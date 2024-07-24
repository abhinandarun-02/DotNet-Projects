using Products.API.Data;
using Products.API.Models;

namespace Products.API.Repository
{
    public class ProductEFCoreInMemoryRepository : IProductRepository
    {
        ProductDbContext _productDbContext;

        public ProductEFCoreInMemoryRepository(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }
        public bool CreateProduct(Product product)
        {
            _productDbContext.Products.Add(product);
            _productDbContext.SaveChanges();
            return true;
        }

        public bool DeleteProduct(int id)
        {
            _productDbContext.Products.Remove(GetProductById(id));
            _productDbContext.SaveChanges();
            return true;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productDbContext.Products;
        }

        public IEnumerable<Product> GetAllProducts(int? amount)
        {
            throw new NotImplementedException();
        }

        public Product GetProductById(int id)
        {
            return _productDbContext.Products.FirstOrDefault(p => p.Id == id);
        }

        public Product UpdateProduct(int id, Product product)
        {
            var existingProduct = GetProductById(id);
            if (existingProduct != null)
            {
                existingProduct.name = product.name;
                existingProduct.description = product.description;
                existingProduct.amount = product.amount;
                _productDbContext.SaveChanges();
            }
            return existingProduct;
        }
    }
}
