using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderAPI.Models;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public OrderController()
        {

        }
        [HttpGet]
        [Authorize(Roles = "Administrator,User")]
        public async Task<IActionResult> GetData()
        {
            try
            {
                List<Order> listOrder = new List<Order>();
                listOrder.Add(new Order()
                {
                    ID = 123,
                    Name = "Apple",
                    Unit = "Kg",
                    Qty = 4,
                    TotalAmount = 430
                });
                listOrder.Add(new Order()
                {
                    ID = 124,
                    Name = "Banana",
                    Unit = "Kg",
                    Qty = 2,
                    TotalAmount = 480
                });
                listOrder.Add(new Order()
                {
                    ID = 125,
                    Name = "Guava",
                    Unit = "Kg",
                    Qty = 3,
                    TotalAmount = 490
                });
                return Ok(listOrder);
            }
            catch (Exception exp)
            {
                return BadRequest(exp);
            }
        }
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetByID(int id)
        {
            try
            {
                var ord = new Order()
                {
                    ID = 124,
                    Name = "Banana",
                    Unit = "Kg",
                    Qty = 2,
                    TotalAmount = 480
                };
                return Ok(ord);
            }
            catch (Exception exp)
            {
                return BadRequest(exp);
            }
        }
    }
}
