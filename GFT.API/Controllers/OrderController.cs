using GFT.API.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GFT.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {

        [HttpPost]
        public ActionResult<string> Post([FromBody] string orderInput)
        {
            try
            {
                var order = new Order(orderInput);
                return Ok(order.ToString());
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
