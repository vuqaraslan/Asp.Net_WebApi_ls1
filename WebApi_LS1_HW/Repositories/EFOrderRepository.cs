using Microsoft.EntityFrameworkCore;
using WebApi_LS1_HW.Data;
using WebApi_LS1_HW.Entities;
namespace WebApi_LS1_HW.Repositories
{

    public class EFOrderRepository : IOrderRepository
    {
        private readonly ShoppingDbContext? _shoppingDbContext;

        public EFOrderRepository(ShoppingDbContext? shoppingDbContext)
        {
            _shoppingDbContext = shoppingDbContext;
        }

        public async Task Add(Order order)
        {
            await _shoppingDbContext.Orders.AddAsync(order);
            await _shoppingDbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var order = _shoppingDbContext.Orders.FirstOrDefault(o => o.Id == id);
            _shoppingDbContext.Orders.Remove(order);
            await _shoppingDbContext.SaveChangesAsync();
        }

        public async Task<List<Order>> GetAllOrdersAsync(string key = "2024")
        {
            return await _shoppingDbContext.Orders.ToListAsync();
        }

        public async Task Update(int id, Order order)
        {
            var orderForUpdate = _shoppingDbContext.Orders.FirstOrDefault(o => o.Id == id);
            if (orderForUpdate == null)
            {
                throw new InvalidOperationException("Order not found !");
            }
            orderForUpdate.OrderDate = order.OrderDate;
            _shoppingDbContext.Orders.Update(orderForUpdate);
            await _shoppingDbContext.SaveChangesAsync();
        }
    }
}
