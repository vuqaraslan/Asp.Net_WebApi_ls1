using WebApi_LS1_HW.Entities;

namespace WebApi_LS1_HW.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrdersAsync(string key="");
        Task Add(Order order);
        Task Update(int id, Order order);
        Task Delete(int id);
    }
}
