using WebApi_LS1_HW.Entities;
using WebApi_LS1_HW.Repositories;

namespace WebApi_LS1_HW.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository? _orderRepository;

        public OrderService(IOrderRepository? orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task AddAsync(Order order)
        {
            await _orderRepository.Add(order);
        }

        public async Task DeleteAsync(int id)
        {
            await _orderRepository.Delete(id);
        }

        public async Task<List<Order>> GetOrdersByKeyAsync(string key = "")
        {
            return await _orderRepository.GetAllOrdersAsync(key);
        }

        public async Task UpdateAsync(int id, Order order)
        {
            await _orderRepository.Update(id, order);
        }
    }
}
