using buy_easy_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace buy_easy_api.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController: ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }
    }
}