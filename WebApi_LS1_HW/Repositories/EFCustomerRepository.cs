using Microsoft.EntityFrameworkCore;
using WebApi_LS1_HW.Data;
using WebApi_LS1_HW.Entities;

namespace WebApi_LS1_HW.Repositories
{
    public class EFCustomerRepository : ICustomerRepository
    {
        private readonly ShoppingDbContext? _shoppingDbContext;

        public EFCustomerRepository(ShoppingDbContext? shoppingDbContext)
        {
            _shoppingDbContext = shoppingDbContext;
        }

        public async Task Add(Customer customer)
        {
            await _shoppingDbContext.Customers.AddAsync(customer);
            await _shoppingDbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var customer = _shoppingDbContext.Customers.FirstOrDefault(c => c.Id == id);
            _shoppingDbContext.Customers.Remove(customer);
            await _shoppingDbContext.SaveChangesAsync();
        }

        public async Task<List<Customer>> GetAllCustomersAsync(string key = "")
        {
            return await _shoppingDbContext.Customers.Where(c => c.Name.ToLower().Contains(key.ToLower()) ||
                                                                 c.Surname.ToLower().Contains(key.ToLower())).ToListAsync();
        }

        public async Task Update(int id, Customer customer)
        {
            var customerForUpdate = _shoppingDbContext.Customers.FirstOrDefault(c => c.Id == id);
            if (customerForUpdate == null)
            {
                throw new InvalidOperationException("Customer not found !");
            }
            customerForUpdate.Name = customer.Name;
            customerForUpdate.Surname = customer.Surname;
            _shoppingDbContext.Customers.Update(customerForUpdate);
            await _shoppingDbContext.SaveChangesAsync();
        }
    }
}
