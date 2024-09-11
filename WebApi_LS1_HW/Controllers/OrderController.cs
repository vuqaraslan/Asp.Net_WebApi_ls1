using Microsoft.AspNetCore.Mvc;
using WebApi_LS1_HW.Dtos;
using WebApi_LS1_HW.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi_LS1_HW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService? _orderService;

        public OrderController(IOrderService? orderService)
        {
            _orderService = orderService;
        }


        // GET: api/<OrderController>
        [HttpGet]
        public async Task<IEnumerable<OrderDto>> Get(string key = "")
        {
            var orders = await _orderService.GetOrdersByKeyAsync(key);
            var result = orders.Select(o => new OrderDto
            {
                OrderDate = o.OrderDate,
                CustomerId = o.CustomerId,
                ProductId = o.ProductId
            });
            return result;
        }


        //// GET api/<OrderController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<OrderController>
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            return Ok(value);
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return Ok(value);
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _orderService.DeleteAsync(id);
            return NoContent();
        }   
    }
}
