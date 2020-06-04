using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Tutorial10.Models;

namespace Tutorial10.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentController : ControllerBase
    {
        private s18588Context _context;

        public StudentController()
        {
            _context = new s18588Context();
        }

        [HttpGet]
        public IActionResult GetStudent()
        {
            return Ok(_context.Student);
        }

        [HttpPost]
        public IActionResult CreateStudent(Student s)
        {
            try
            {
                this._context.Student.Add(s);
                this._context.SaveChanges();
                return Ok(s);
            }
            catch
            {
                return BadRequest(s);
            }
            
        }

        [HttpPut]
        public IActionResult ModifyStudent(Student student)
        {
            var result = this._context.Student.SingleOrDefault(v => v.IndexNumber == student.IndexNumber);
            if (result != null)
            {
                result = student;
                this._context.SaveChanges();

            }

            return Ok(student);
        }

        [HttpDelete]
        public IActionResult DeleteStudent(string id)
        {
            var result = this._context.Student.First(x => x.IndexNumber == id);
            this._context.Remove(result);
            this._context.SaveChanges();
            return Ok();
        }
        

    }
}