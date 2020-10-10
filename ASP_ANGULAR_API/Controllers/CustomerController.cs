using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using SystemsBusinnessLogic.Interfaces;

namespace ASP_ANGULAR_API.Controllers
{
    [Route("api/Customer")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerLogic _logic;
        public CustomerController(ICustomerLogic logic)
            {
                _logic = logic;
            }
            [HttpGet]
            [Route("{Id:int}")]
            public IActionResult GetById(int Id)
            {
                return Ok(_logic.GetById(Id));
            }
            [HttpGet]
            [Route("GetPaginatedCustomer/{page:int}/{rows:int}")]
            public IActionResult GetPaginatedCustomer(int page, int rows)
            {
                return Ok(_logic.GetPaginatedCustomer(page, rows));
            }
            [HttpPost]
            public IActionResult Post([FromBody]Customer customer)
            {
                if (!ModelState.IsValid) return BadRequest();
                return Ok(_logic.Insert(customer));
            }
            [HttpPut]
            public IActionResult Put([FromBody]Customer customer)
            {
                if (!ModelState.IsValid && _logic.Update(customer))
                {
                    return Ok(new { Message = "El cliente ha sido actualizado" });
                }
                return BadRequest();

            }
            [HttpDelete]
            public IActionResult Delete([FromBody]Customer customer)
            {
                if (customer.Id > 0)
                    return Ok(_logic.Delete(customer));
                return BadRequest();
            }

        
    }
}