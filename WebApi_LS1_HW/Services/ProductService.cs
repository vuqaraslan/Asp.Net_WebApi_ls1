using WebApi_LS1_HW.Entities;
using WebApi_LS1_HW.Repositories;

namespace WebApi_LS1_HW.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository? _productRepository;

        public ProductService(IProductRepository? productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task AddAsync(Product product)
        {
            await _productRepository.Add(product);
        }

        public async Task DeleteAsync(int id)
        {
            await _productRepository.Delete(id);
        }

        public async Task<List<Product>> GetProductsByKeyAsync(string key = "")
        {
            return await _productRepository.GetAllProductsAsync(key);
        }

        public async Task UpdateAsync(int id, Product product)
        {
            await _productRepository.Update(id, product); 
        }
    }
}
