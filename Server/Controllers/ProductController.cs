using BlazorEcommerce.Server.Data;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorEcommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly BlCommerceDataContext _context;
        public ProductController(BlCommerceDataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
