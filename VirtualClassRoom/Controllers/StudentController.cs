using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.Services;

namespace VirtualClassRoom.Controllers
{
    [ApiController]
    [Route("api/Students")]
    public class StudentController:ControllerBase
    {
        private readonly ICourseRepository _CourseRepository;

        public StudentController(ICourseRepository courseRepository)
        {
            _CourseRepository = courseRepository;
        }
        [HttpGet]
        public IActionResult GetCourses()
        {

            var courses = _CourseRepository.GetCourses();
            if(courses == null)
            {
                return NotFound();
            }
            return Ok(courses);

        }
        [HttpGet("{studentID}")]
        public IActionResult GetCoursesForStudent(Guid studentID)
        {

            var courses = _CourseRepository.GetEnrolledCourses(studentID);
            if (courses == null)
            {
                return NotFound();
            }
            return Ok(courses);


        }

    }
}
