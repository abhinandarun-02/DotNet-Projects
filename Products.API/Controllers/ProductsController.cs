using Microsoft.AspNetCore.Mvc;
using Products.API.Models;
using Products.API.Repository;

namespace Products.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public ActionResult GetAllProducts([FromQuery] int? amount)
        {
            if (amount==null)
            {
                var products = _productRepository.GetAllProducts();
                return Ok(products);
            }
            else
            {
                var products = _productRepository.GetAllProducts(amount);
                return Ok(products);
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetProductById([FromRoute] int id) {
            var product = _productRepository.GetProductById(id);
            if (product == null)
            {
                return NotFound($"Product with id={id} not found");
            }
            return Ok(product);
        }

        [HttpPost]
        public ActionResult CreateProduct([FromBody] Product product)
        {
            var createdProduct = _productRepository.CreateProduct(product);
            return Ok(createdProduct);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProduct([FromRoute] int id, [FromBody] Product product)
        {
            var updatedProduct = _productRepository.UpdateProduct(id, product);
            if (updatedProduct == null) {
                return NotFound($"Product with id={product.Id} not found");
            }
            return Ok(updatedProduct);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct([FromRoute] int id)
        {
            var product = _productRepository.DeleteProduct(id);
            if (!product)
            {
                return NotFound($"Product with id={id} not found");
            }
            return Ok(product);
        }
    }
}
