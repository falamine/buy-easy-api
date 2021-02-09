using System.Collections.Generic;
using System.Threading.Tasks;
using buy_easy_api.Entities;
using buy_easy_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace buy_easy_api.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController: ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _productService.GetProducts();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productService.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Create(Product product)
        {
            var newProduct = await _productService.CreateProduct(product);
            return Created("", newProduct);
        }

        [HttpGet]
        [Route("/search")]
        public async Task<ActionResult<IEnumerable<Product>>> Search(string query)
        {
            var result = await _productService.Search(query);
            if (result == null)
            {
                NoContent();
            }

            return result;
        }
    }
}