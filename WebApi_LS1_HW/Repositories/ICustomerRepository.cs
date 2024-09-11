using WebApi_LS1_HW.Entities;

namespace WebApi_LS1_HW.Repositories
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllCustomersAsync(string key="");
        Task Add(Customer customer);
        Task Update(int id, Customer customer);
        Task Delete(int id);
    }
}
