using crudcrudapi.Models;
using crudcrudapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace crudcrudapi.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsService _service;

        public ProductsController(ProductsService service)
        {
            _service = service;
        }

        // **GET ALL PRODUCTS**
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _service.GetAllProducts();
            return Ok(products);
        }

        // **GET PRODUCT BY ID**
        [HttpGet("{product_id}")]
        public async Task<IActionResult> GetProduct(string product_id)
        {
            var product = await _service.GetProduct(product_id);
            if (product == null)
            {
                return NotFound(new { message = $"Product with ID {product_id} not found" });
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductCreate productcreate_obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Create the product using the service
            var createdProduct = await _service.CreateProduct(productcreate_obj);

            // Return the created product with its ID
            return CreatedAtAction(nameof(GetProduct), new { product_id = createdProduct.ProductId }, createdProduct);
        }


        // **UPDATE A PRODUCT**
        [HttpPut("{product_id}")]
        public async Task<IActionResult> UpdateProduct(string product_id, [FromBody] Product product_obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var test = "apple";
            await _service.UpdateProduct(product_id, product_obj);
            return NoContent();
        }

        // **DELETE A PRODUCT**
        [HttpDelete("{product_id}")]
        public async Task<IActionResult> DeleteProduct(string product_id)
        {
            await _service.DeleteProduct(product_id);
            return NoContent();
        }
    }
}
