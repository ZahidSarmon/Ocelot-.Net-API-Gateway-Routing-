using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Article.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Api.Article.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        public ProductController()
        {
            
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetData()
        {
            try{
                List<ProductModel> listProduct=new List<ProductModel>();
                listProduct.Add(new ProductModel(){ID=12314,Name="Apple",Price=150});
                listProduct.Add(new ProductModel(){ID=12315,Name="Banana",Price=160});
                listProduct.Add(new ProductModel(){ID=12316,Name="Guava",Price=170});
                return Ok(listProduct);
            }catch(Exception exp)
            {
                return BadRequest(exp);
            }
        }
        
        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetByID(int id)
        {
            try{
                var prod=new ProductModel(){ID=12314,Name="Apple",Price=150};
                return Ok(prod);
            }catch(Exception exp)
            {
                return BadRequest(exp);
            }
        }

    }
}