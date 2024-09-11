using Microsoft.EntityFrameworkCore;
using WebApi_LS1_HW.Data;
using WebApi_LS1_HW.Entities;

namespace WebApi_LS1_HW.Repositories
{
    public class EFProductRepository : IProductRepository
    {
        private readonly ShoppingDbContext? _shoppingDbContext;

        public EFProductRepository(ShoppingDbContext? shoppingDbContext)
        {
            _shoppingDbContext = shoppingDbContext;
        }

        public async Task Add(Product product)
        {
            await _shoppingDbContext.Products.AddAsync(product);
            await _shoppingDbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product = _shoppingDbContext.Products.FirstOrDefault(p => p.Id == id);
            _shoppingDbContext.Products.Remove(product);
            await _shoppingDbContext.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllProductsAsync(string key = "")
        {
            return await _shoppingDbContext.Products.Where(p => p.Name.ToLower().Contains(key.ToLower())).ToListAsync();
        }

        public async Task Update(int id, Product product)
        {
            var productForUpdate = _shoppingDbContext.Products.FirstOrDefault(p => p.Id == id);
            if (productForUpdate == null)
            {
                throw new InvalidOperationException("Product not found !");
            }
            productForUpdate.Name = product.Name;
            productForUpdate.Price = product.Price;
            productForUpdate.Discount = product.Discount;
            _shoppingDbContext.Products.Update(productForUpdate);
            await _shoppingDbContext.SaveChangesAsync();
        }
    }
}
