using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Models;
using System.Linq;
using System.Threading.Tasks;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ServerDbContext _dbContext;

        public OrderController(ServerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("{OrderId}")]
        public async Task<IActionResult> GetOrderDetailById(int OrderId)
        {
            // Lấy order với OrderId
            var order = await _dbContext.Orders
                .Where(o => o.OrderId == OrderId)
                .FirstOrDefaultAsync();

            if (order == null)
            {
                return NotFound();
            }

            // Lấy chi tiết order (OrderDetails) và thông tin sản phẩm
            var orderDetails = await _dbContext.OrderDetails
                .Where(od => od.OrderId == OrderId)
                .Select(od => new
                {
                    ProductName = _dbContext.Products.Where(p => p.ProductId == od.ProductId).Select(p => p.ProductName).FirstOrDefault(),
                    Price = od.Price,
                    Quantity = od.Quantity
                })
                .ToListAsync();

            // Kết quả trả về với OrderId và các sản phẩm trong order
            var result = new
            {
                OrderId = OrderId,
                Products = orderDetails
            };

            return Ok(result);
        }
    }
}
