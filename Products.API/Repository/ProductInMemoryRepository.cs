//using Microsoft.AspNetCore.Http.HttpResults;
//using Microsoft.AspNetCore.Mvc;
//using Products.API.Models;

//namespace Products.API.Repository
//{
//    public class ProductInMemoryRepository : IProductRepository
//    {
//        private List<Product> _productList;

//        public ProductInMemoryRepository()
//        {
//            _productList = new List<Product>{
//                new Product("Apple", "Iphone", 1400),
//                new Product("Samsung", "S24", 1100),
//                new Product("Asus", "Zenphone", 800),
//            };
//        }

//        public IEnumerable<Product> GetAllProducts()
//        {
//            return _productList;
//        }

//        public IEnumerable<Product> GetAllProducts(int? amount)
//        {
//            var filteredProducts = _productList.Where(p => p.amount > amount).ToList();
//            return filteredProducts;
//        }

//        public Product GetProductById(Guid id)
//        {
//            var product = _productList.FirstOrDefault(c=>c.id == id);
//            return product;
//        }

//        Product IProductRepository.CreateProduct(Product product)
//        {
//            _productList.Add(product);
//            return product;
//        }

//        Product IProductRepository.UpdateProduct(Guid id, Product product)
//        {
//            var existingProduct = _productList.FirstOrDefault(p => p.id == id);
//            if (existingProduct != null)
//            {
//                existingProduct.name = product.name;
//                existingProduct.description = product.description;
//                existingProduct.amount = product.amount;
//            }
//            return existingProduct;
//        }

//        Product IProductRepository.DeleteProduct(Guid id)
//        {
//            var product = _productList.FirstOrDefault(p => p.id == id);
//            _productList.Remove(product);

//            return product;
//        }

//    }
//}
