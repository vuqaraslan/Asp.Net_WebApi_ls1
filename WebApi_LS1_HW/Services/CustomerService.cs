using WebApi_LS1_HW.Entities;
using WebApi_LS1_HW.Repositories;

namespace WebApi_LS1_HW.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository? _customerRepository;

        public CustomerService(ICustomerRepository? customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task AddAsync(Customer customer)
        {
            await _customerRepository.Add(customer);
        }

        public async Task DeleteAsync(int id)
        {
            await _customerRepository.Delete(id);
        }

        public async Task<List<Customer>> GetCustomersByKeyAsync(string key = "")
        {
            return await _customerRepository.GetAllCustomersAsync(key);
        }

        public async Task UpdateAsync(int id, Customer customer)
        {
            await _customerRepository.Update(id, customer);
        }
    }
}
