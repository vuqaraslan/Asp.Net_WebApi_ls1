using WebApi_LS1_HW.Entities;

namespace WebApi_LS1_HW.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductsAsync(string key="");
        Task Add (Product product);
        Task Update (int id,Product product);
        Task Delete (int id);
    }
}
