namespace BlazorEcommerce.Server.Services
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> GetProductsAsync();
        Task<ServiceResponse<Product>> GetProductAsync(int id);
        Task<ServiceResponse<List<Product>>> GetProductsByCategoryAsync(string category);
        Task<ServiceResponse<List<Product>>> SearchProducts(string search, int page);
        Task<ServiceResponse<List<string>>> GetProductSearchSuggetions(string search);
        Task<ServiceResponse<List<Product>>> GetFeaturedProducts();

    }
}