﻿using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Client.Services
{
    public interface IProductService
    {
        List<Product> Products { get; set; }

        Task GetProductsAsync();
        Task<Product> GetProductAsync(int id);
    }
}