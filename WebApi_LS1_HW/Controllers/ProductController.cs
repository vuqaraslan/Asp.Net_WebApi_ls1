using Microsoft.AspNetCore.Mvc;
using WebApi_LS1_HW.Dtos;
using WebApi_LS1_HW.Entities;
using WebApi_LS1_HW.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi_LS1_HW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService? _productService;

        public ProductController(IProductService? productService)
        {
            _productService = productService;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IEnumerable<ProductDto>> Get(string key = "")
        {
            var products = await _productService.GetProductsByKeyAsync(key);
            var result = products.Select(p => new ProductDto
            {
                Name = p.Name,
                Price = p.Price,
                Discount = p.Discount,
            });
            return result;
        }

        //// GET api/<ProductController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}
        [HttpGet("HigherPrice")]
        public async Task< IActionResult> HigherPrice()
        {
            var expensiveProduct = _productService.GetProductsByKeyAsync().Result.OrderByDescending(p => p.Price).ToArray()[0];
            if (expensiveProduct != null)
            {
                return Ok(expensiveProduct);
            }
            return NotFound("Product not found !");
        }

        [HttpGet("HigherDiscount")]
        public async Task<IActionResult> HigherDiscount()
        {
            var expensiveProduct = _productService.GetProductsByKeyAsync().Result.OrderByDescending(p => p.Discount).ToArray()[0];
            if (expensiveProduct != null)
            {
                return Ok(expensiveProduct);
            }
            return NotFound("Product not found !");
        }


        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductDto productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Discount = productDto.Discount
            };
            await _productService.AddAsync(product);
            return Ok(product);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProductDto productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Discount = productDto.Discount
            };
            try
            {
                await _productService.UpdateAsync(id, product);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteAsync(id);
            return NoContent();
        }
    }
}
