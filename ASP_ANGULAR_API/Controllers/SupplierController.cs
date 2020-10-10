using ASP_ANGULAR_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using SystemsBusinnessLogic.Interfaces;

namespace ASP_ANGULAR_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierLogic _logic;
        public SupplierController(ISupplierLogic logic)
        {
            _logic = logic;
        }
        [HttpGet]
        [Route("{Id:int}")]
        public IActionResult GetById(int Id)
        {
            return Ok(_logic.GetById(Id));
        }
        [HttpPost]
        [Route("GetPaginatedSupplier")]
        public IActionResult GetPaginatedSupplier([FromBody]getPaginatedSupplier request)
        {
            return Ok(_logic.SupplierPagedList(request.Page, request.Rows, request.searchTerm));
        }
        [HttpPost]
        public IActionResult Post([FromBody]Supplier supplier)
        {
            if (!ModelState.IsValid) return BadRequest();
            return Ok(_logic.Insert(supplier));
        }
        [HttpPut]
        public IActionResult Put([FromBody]Supplier supplier)
        {
            if (!ModelState.IsValid && _logic.Update(supplier))
            {
                return Ok(new { Message = "El proveedor ha sido actualizado" });
            }
            return BadRequest();

        }
        [HttpDelete]
        public IActionResult Delete([FromBody]Supplier supplier)
        {
            if (supplier.Id > 0)
                return Ok(_logic.Delete(supplier));
            return BadRequest();
        }


    
}
}