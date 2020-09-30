using ASP_ANGULAR_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using UnitOfWork;

namespace ASP_ANGULAR_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SupplierController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public SupplierController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [Route("{Id:int}")]
        public IActionResult GetById(int Id)
        {
            return Ok(_unitOfWork.Supplier.GetById(Id));
        }
        [HttpPost]
        [Route("GetPaginatedSupplier")]
        public IActionResult GetPaginatedSupplier([FromBody]getPaginatedSupplier request)
        {
            return Ok(_unitOfWork.Supplier.SupplierPagedList(request.Page, request.Rows, request.searchTerm));
        }
        [HttpPost]
        public IActionResult Post([FromBody]Supplier supplier)
        {
            if (!ModelState.IsValid) return BadRequest();
            return Ok(_unitOfWork.Supplier.Insert(supplier));
        }
        [HttpPut]
        public IActionResult Put([FromBody]Supplier supplier)
        {
            if (!ModelState.IsValid && _unitOfWork.Supplier.Update(supplier))
            {
                return Ok(new { Message = "El proveedor ha sido actualizado" });
            }
            return BadRequest();

        }
        [HttpDelete]
        public IActionResult Delete([FromBody]Supplier supplier)
        {
            if (supplier.Id > 0)
                return Ok(_unitOfWork.Supplier.Delete(supplier));
            return BadRequest();
        }


    
}
}