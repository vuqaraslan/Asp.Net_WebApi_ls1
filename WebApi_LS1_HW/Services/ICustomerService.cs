using WebApi_LS1_HW.Entities;

namespace WebApi_LS1_HW.Services
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetCustomersByKeyAsync(string key = "");
        Task AddAsync(Customer customer);
        Task UpdateAsync(int id, Customer customer);
        Task DeleteAsync(int id);
    }
}
