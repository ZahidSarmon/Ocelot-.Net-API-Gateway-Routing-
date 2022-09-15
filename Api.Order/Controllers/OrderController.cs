using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Order.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace Api.Order.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        public OrderController()
        {
            
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetData()
        {
            try{
                List<ModelOrder> listOrder=new List<ModelOrder>();
                listOrder.Add(new ModelOrder(){
                    ID=123,Name="Apple",Unit="Kg",Qty=4,TotalAmount=430
                });
                listOrder.Add(new ModelOrder(){
                    ID=124,Name="Banana",Unit="Kg",Qty=2,TotalAmount=480
                });
                listOrder.Add(new ModelOrder(){
                    ID=125,Name="Guava",Unit="Kg",Qty=3,TotalAmount=490
                });
                return Ok(listOrder);
            }catch(Exception exp)
            {
                return BadRequest(exp);
            }
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByID(int id)
        {
            try{
                var ord=new ModelOrder(){
                    ID=124,Name="Banana",Unit="Kg",Qty=2,TotalAmount=480
                };
                return Ok(ord);
            }catch(Exception exp)
            {
                return BadRequest(exp);
            }
        }
    }
}