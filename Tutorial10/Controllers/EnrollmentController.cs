using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Tutorial10.Models;

namespace Tutorial10.Controllers
{
    [ApiController]
    [Route("api/enrollment")]
    public class EnrollmentController : ControllerBase
    {
        private readonly s18588Context _context;

        public EnrollmentController()
        {
            _context = new s18588Context();
        }

        [HttpPost]
        public IActionResult EntrollStudent(Enrollment enrollment)
        {

            if (enrollment.StartDate == null)
            {
                return BadRequest("Wrong body");
            }


            var studies = this._context.Enrollment.First(x => x.IdStudy == enrollment.IdStudy);
            
            enrollment = this._context.Enrollment.First(x => x.Semester == 1 && x.IdStudy == studies.IdStudy);

            DateTime today = DateTime.Today;
            
            if (enrollment == null)
            {
                var newEnrollment = new Enrollment();
                newEnrollment.IdStudy = studies.IdStudy;
                newEnrollment.StartDate = today;
                this._context.Enrollment.Add(newEnrollment);
                enrollment = newEnrollment;
            }

            Student student = new Student();

            student.FirstName = student.FirstName;

            student.LastName= student.LastName;

            student.IndexNumber= student.IndexNumber;

            student.BirthDate = today; // not sure how to make date

            var b = student.IdEnrollment == enrollment.IdEnrollment;
            
            this._context.Student.Add(student);
            this._context.SaveChanges();
            return Ok(student);

        }
    }
}