using WebApi_LS1_HW.Entities;

namespace WebApi_LS1_HW.Services
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrdersByKeyAsync(string key = "");
        Task AddAsync(Order order);
        Task UpdateAsync(int id, Order order);
        Task DeleteAsync(int id);
    }
}
