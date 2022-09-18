using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ProductController()
        {

        }
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult GetData()
        {
            try
            {
                List<Product> listProduct = new List<Product>();
                listProduct.Add(new Product() { ID = 12314, Name = "Apple", Price = 150 });
                listProduct.Add(new Product() { ID = 12315, Name = "Banana", Price = 160 });
                listProduct.Add(new Product() { ID = 12316, Name = "Guava", Price = 170 });
                return Ok(listProduct);
            }
            catch (Exception exp)
            {
                return BadRequest(exp);
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Administrator")]
        public IActionResult GetByID(int id)
        {
            try
            {
                var prod = new Product() { ID = 12314, Name = "Apple", Price = 150 };
                return Ok(prod);
            }
            catch (Exception exp)
            {
                return BadRequest(exp);
            }
        }
    }
}
