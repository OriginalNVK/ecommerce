using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Models;
using System.Threading.Tasks;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ServerDbContext _dbContext;

        public ProductController(ServerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var products = await _dbContext.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            // Không cần tính maxID nếu ProductId là auto-increment
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync(); // Sử dụng SaveChangesAsync để thực hiện bất đồng bộ

            return CreatedAtAction(nameof(GetProductById), new { id = product.ProductId }, product); // Trả về mã 201 và sản phẩm vừa thêm
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product updatedProduct)
        {
            var product = await _dbContext.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            product.ProductName = updatedProduct.ProductName;
            product.OldPrice = updatedProduct.OldPrice;
            product.NewPrice = updatedProduct.NewPrice;
            product.StockQuantity = updatedProduct.StockQuantity;
            product.ProductDescription = updatedProduct.ProductDescription;

            await _dbContext.SaveChangesAsync(); // Sử dụng SaveChangesAsync để thực hiện bất đồng bộ
            return Ok(product);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync(); // Sử dụng SaveChangesAsync để thực hiện bất đồng bộ
            return Ok();
        }
    }
}
