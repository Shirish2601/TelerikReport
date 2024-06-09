using Microsoft.AspNetCore.Mvc;
using ProductInformation.API.Repository;
using ProductInformation.Models;
using System.Collections.Generic;

namespace ProductInformation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository _productRepository;

        public ProductController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("products")]
        public ActionResult<List<Product>> GetProducts()
        {
            var products = _productRepository.GetProducts();
            if (products == null || products.Count == 0)
            {
                return NotFound();
            }
            return Ok(products);
        }

        [HttpGet("products/{productId}")]
        public ActionResult<Product> GetProduct([FromRoute] int productId) => 
            _productRepository.GetProduct(productId);
    }
}
