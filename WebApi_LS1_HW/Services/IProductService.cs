using WebApi_LS1_HW.Entities;

namespace WebApi_LS1_HW.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsByKeyAsync(string key="");
        Task AddAsync(Product product);
        Task UpdateAsync(int id,Product product);
        Task DeleteAsync(int id);
    }
}
