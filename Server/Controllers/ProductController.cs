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

        [HttpGet("search/{searchText}/{page}")]
        public async Task<ActionResult<IEnumerable<Product>>> SearchProducts([FromRoute] string searchText, int page)
        {
            var res = await _service.SearchProducts(searchText, page);
            return Ok(res);
        }

        [HttpGet("searchsuggetions/{searchText}")]
        public async Task<ActionResult<IEnumerable<string>>> SearchProductSuggestions([FromRoute] string searchText)
        {
            var res = await _service.GetProductSearchSuggetions(searchText);
            return Ok(res);
        }
    }
}
