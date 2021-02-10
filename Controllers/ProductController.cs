using System.Collections.Generic;
using System.Threading.Tasks;
using buy_easy_api.Entities;
using buy_easy_api.Models;
using buy_easy_api.Services;
using buy_easy_api.Views.Product;
using Microsoft.AspNetCore.Mvc;

namespace buy_easy_api.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController: Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("listing")]
        public async Task<IActionResult> Listing()
        {
            var products = await _productService.GetProducts();
            return View("ProductList", new ListingPageModel
            {
                Products = products
            });
        }

        [HttpGet]
        [Route("details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var product = await _productService.GetProduct(id);
            return View("ProductDetail", product);
        }

        [HttpPost]
        [Route("search")]
        public async Task<IActionResult> SearchForProduct([FromForm] ProductSearchModel model)
        {
            var products = await _productService.Search(model.Name);
            return View("SearchResult", new SearchResultModel
            {
                Products = products
            });
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