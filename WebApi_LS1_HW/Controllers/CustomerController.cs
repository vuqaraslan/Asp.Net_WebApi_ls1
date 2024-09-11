using Microsoft.AspNetCore.Mvc;
using WebApi_LS1_HW.Dtos;
using WebApi_LS1_HW.Entities;
using WebApi_LS1_HW.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi_LS1_HW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService? _customerService;

        public CustomerController(ICustomerService? customerService)
        {
            _customerService = customerService;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public async Task<IEnumerable<CustomerDto>> Get(string key = "")
        {
            var customers = await _customerService.GetCustomersByKeyAsync(key);
            var result = customers.Select(c => new CustomerDto
            {
                Name = c.Name,
                Surname = c.Surname
            });
            return result;
        }

        //// GET api/<CustomerController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerDto customerDto)
        {
            var customer = new Customer
            {
                Name = customerDto.Name,
                Surname = customerDto.Surname
            };
            await _customerService.AddAsync(customer);
            return Ok(customer);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CustomerDto customerDto)
        {
            var customer = new Customer
            {
                Name = customerDto.Name,
                Surname = customerDto.Surname
            };
            try
            {
                await _customerService.UpdateAsync(id, customer);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _customerService.DeleteAsync(id);
            return NoContent();
        }


    }
}
