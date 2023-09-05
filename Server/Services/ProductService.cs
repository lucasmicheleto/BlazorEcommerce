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
            var products = await _context.Products
                .Include(p => p.Variants)
                .ToListAsync();
            var res = new ServiceResponse<List<Product>>()
            {
                Success = true,
                Data = products
            };
            return res;
        }

        public async Task<ServiceResponse<Product>> GetProductAsync(int id)
        {
            var product = await _context.Products
                .Include(p => p.Variants)
                .ThenInclude(v => v.ProductType)
                .FirstOrDefaultAsync(p => p.Id == id);
            var res = new ServiceResponse<Product>()
            {
                Success = true,
                Data = product
            };
            return res;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsByCategoryAsync(string category)
        {
            var products = await _context.Products
                .Include(p => p.Variants)
                .Where(p => p.Category != null && p.Category.Url.ToLower() == category).ToListAsync();
            var res = new ServiceResponse<List<Product>>()
            {
                Success = true,
                Data = products
            };
            return res;
        }

        public async Task<ServiceResponse<List<Product>>> SearchProducts(string search, int page)
        {
            var response = new ServiceResponse<List<Product>>()
            {
                Data = await FindProductsBySearchText(search)
            };
            return response;
        }

        private async Task<List<Product>> FindProductsBySearchText(string search)
        {
            return await _context.Products
                            .Where(p => p.Title.Contains(search) ||
                            p.Description.Contains(search))
                            .Include(p => p.Variants)
                            .ToListAsync();
        }

        public async Task<ServiceResponse<List<string>>> GetProductSearchSuggetions(string searchText)
        {
            var products = await FindProductsBySearchText(searchText);

            List<string> result = new ();

            foreach (var product in products)
            {
                if (product.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(product.Title);
                }

                if (product.Description != null)
                {
                    var punctuation = product.Description.Where(char.IsPunctuation)
                        .Distinct().ToArray();
                    var words = product.Description.Split()
                        .Select(s => s.Trim(punctuation));

                    foreach (var word in words)
                    {
                        if (word.Contains(searchText, StringComparison.OrdinalIgnoreCase)
                            && !result.Contains(word))
                        {
                            result.Add(word);
                        }
                    }
                }
            }

            return new ServiceResponse<List<string>> { Data = result };
        }
    }
}
