using BlazorEcommerce.Server.Data;

using Microsoft.EntityFrameworkCore;

namespace BlazorEcommerce.Server.Services
{
    public class ProductService : IProductService
    {
        private readonly BlCommerceDataContext _context;

        public ProductService(BlCommerceDataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
        {
            var products = await _context.Products.ToListAsync();
            var res = new ServiceResponse<List<Product>>()
            {
                Success = true,
                Data = products
            };
            return res;
        }

        public async Task<ServiceResponse<Product>> GetProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            var res = new ServiceResponse<Product>()
            {
                Success = true,
                Data = product
            };
            return res;
        }
    }
}
