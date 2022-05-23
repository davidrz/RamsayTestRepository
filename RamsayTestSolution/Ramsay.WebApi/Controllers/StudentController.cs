using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ramsay.Models;
using Ramsay.UnitOfWork;
using System;

namespace Ramsay.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        protected IUnitOfWork _unitOfWork;
        public StudentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetStudents")]
        public IActionResult GetStudents()
        {
            try
            {
                var response = _unitOfWork.Student.GetAll();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("CreateStudent")]
        public IActionResult CreateStudent([FromBody] Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = _unitOfWork.Student.Insert(student);
            return Ok(response);
        }

        [HttpPut]
        [Route("UpdateStudent")]
        public IActionResult UpdateStudent([FromBody] Student student)
        {
            if (ModelState.IsValid && _unitOfWork.Student.Update(student))
            {
                return Ok(new { Message = "The Student is updated" });
            }

            return BadRequest(new { Message = "The student could not be updated" });
        }

        [HttpDelete]
        [Route("DeleteStudent/{id}")]
        public IActionResult DeleteStudent(int id)
        {
            if (id > 0)
            {
                _unitOfWork.Student.DeleteStudent(id);
                return Ok(new { Message = "The Student is Deleted" });
            }

            return BadRequest(new { Message = "The student could not be removed" });
        }
    }
}
