using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using UnitOfWork;

namespace ASP_ANGULAR_API.Controllers
{
    [Route("api/Customer")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;   
            public CustomerController(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            [HttpGet]
            [Route("{Id:int}")]
            public IActionResult GetById(int Id)
            {
                return Ok(_unitOfWork.Customer.GetById(Id));
            }
            [HttpGet]
            [Route("GetPaginatedCustomer/{page:int}/{rows:int}")]
            public IActionResult GetPaginatedCustomer(int page, int rows)
            {
                return Ok(_unitOfWork.Customer.CustomerPagedList(page, rows));
            }
            [HttpPost]
            public IActionResult Post([FromBody]Customer customer)
            {
                if (!ModelState.IsValid) return BadRequest();
                return Ok(_unitOfWork.Customer.Insert(customer));
            }
            [HttpPut]
            public IActionResult Put([FromBody]Customer customer)
            {
                if (!ModelState.IsValid && _unitOfWork.Customer.Update(customer))
                {
                    return Ok(new { Message = "El cliente ha sido actualizado" });
                }
                return BadRequest();

            }
            [HttpDelete]
            public IActionResult Delete([FromBody]Customer customer)
            {
                if (customer.Id > 0)
                    return Ok(_unitOfWork.Customer.Delete(customer));
                return BadRequest();
            }

        
    }
}