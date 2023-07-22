using BlazorEcommerce.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            var res = await _service.GetProductsAsync();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get([FromRoute]int id)
        {
            var res = await _service.GetProductAsync(id);
            return Ok(res);
        }

        [HttpGet("category/{categoryUrl}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetByCategory([FromRoute] string categoryUrl)
        {
            var res = await _service.GetProductsByCategoryAsync(categoryUrl);
            return Ok(res);
        }
    }
}
