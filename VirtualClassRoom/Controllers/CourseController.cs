using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.Entities;
using VirtualClassRoom.Helpers;
using VirtualClassRoom.Models;
using VirtualClassRoom.Models.Course;
using VirtualClassRoom.Services;
using VirtualClassRoom.Services.CourseStudents;

namespace VirtualClassRoom.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/Course")]

    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;
        private readonly ICourseStudentRepository _courseStudentRepository;



        public CourseController(ICourseRepository courseRepository, IAccountService accountService,
            IMapper mapper, ICourseStudentRepository courseStudentRepository)
        {
            _courseRepository = courseRepository ??
                throw new ArgumentNullException(nameof(courseRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
            _accountService = accountService ??
                throw new ArgumentNullException(nameof(accountService));
            _courseStudentRepository = courseStudentRepository ??
                throw new ArgumentNullException(nameof(accountService));


        }
        [HttpPost]
        public async Task<ActionResult<CourseDto>> AddCourse([FromBody]CourseCreationDto course)
        {
            string authHeader = Request.Headers["Authorization"];
            string username = _accountService.Decrypt(authHeader);
            string[] token = username.Split(",");
            Guid id = Guid.Parse(token[0]);
            string role = token[1];

            if (role != "Instructor")
            {
                return NotFound();
            }
            Course courseToDb = _mapper.Map<Course>(course);

            var temp = await _courseRepository.AddCourse(id, courseToDb);
            CourseDto courseToReturn = _mapper.Map<CourseDto>(temp);
            courseToReturn.InstructorId = id;
            return CreatedAtRoute("GetCourse",
                new { courseId = courseToReturn.CourseId }, courseToReturn);

        }


        [HttpGet("{courseId}", Name = "GetCourse")]
        public async Task<ActionResult<CourseDto>> GetCourse(Guid courseId)
        {
            string authHeader = Request.Headers["Authorization"];
            string username = _accountService.Decrypt(authHeader);
            string[] token = username.Split(",");
            Guid id = Guid.Parse(token[0]);
            string role = token[1];

            if (role != "Instructor")
            {
                return NotFound();
            }
            Course course = await _courseRepository.GetCourse(courseId);
            CourseDto courseToReturn = _mapper.Map<CourseDto>(course);
            return Ok(courseToReturn);

        }
        [HttpPost("{courseId}")]
        public async Task<ActionResult<IEnumerable<UserDto>>> AddStudents(Guid courseId, IEnumerable<CourseStudentCreationDto> courseStudents)
        {
            var courseStudentsFromDb = _mapper.Map<IEnumerable<CourseStudent>>(courseStudents);
            
            foreach (var courseStudent in courseStudentsFromDb)
            {
                await _courseStudentRepository.AddStudentInCourse(courseStudent);
            }
            var studentIds = courseStudentsFromDb.Select(s => s.StudentId);
            var studentFromDb = await _courseStudentRepository.GetStudents(studentIds);
            var studentToReturn = _mapper.Map<IEnumerable<UserDto>>(studentFromDb);
            var idsAsString = string.Join(",", studentIds);
            return CreatedAtRoute("GetStudents", new { courseId, ids = idsAsString },
                                    studentToReturn);

        }
        [HttpPost("student/{courseId}")]
        public async Task<ActionResult<CourseCreationDto>> AddStudent(Guid courseId, CourseStudentCreationDto courseStudents)
        {
            var courseStudentsFromDb = _mapper.Map<CourseStudent>(courseStudents);

           
            await _courseStudentRepository.AddStudentInCourse(courseStudentsFromDb);



            return Ok(courseStudents);

        }
        [HttpGet("courseId/student/({ids})", Name = "GetStudents")]
        public async Task<ActionResult<UserDto>> GetStudents(Guid courseId,
            [FromRoute][ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            if (ids == null)
            {
                return BadRequest();
            }
            var studentsFromDb = await _courseStudentRepository.GetStudents(ids);

            if (ids.Count() != studentsFromDb.Count())
            {
                return NotFound();
            }
            var studentsToReturn = _mapper
                .Map<IEnumerable<UserDto>>(studentsFromDb);
            return Ok(studentsToReturn);
        }
        [HttpGet("{courseId}/Students")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetStudents(Guid courseId)
        {
            string authHeader = Request.Headers["Authorization"];
            string username = _accountService.Decrypt(authHeader);
            string[] token = username.Split(",");
            Guid id = Guid.Parse(token[0]);
            string role = token[1];


            var students = await _courseStudentRepository.GetStudents(courseId);
            if (students == null)
            {
                return NotFound();
            }
            var studentsToReturn = _mapper
                .Map<IEnumerable<UserDto>>(students);

            return Ok(studentsToReturn);

        }
        [HttpPatch("{courseId}")]
        public async Task<ActionResult> UpdateCourse(Guid courseId, JsonPatchDocument<CourseCreationDto> patchCourse)
        {
            string authHeader = Request.Headers["Authorization"];
            string username = _accountService.Decrypt(authHeader);
            string[] token = username.Split(",");
            Guid id = Guid.Parse(token[0]);
            string role = token[1];

            if (role != "Instructor")
            {
                return NotFound();
            }
            if (!await _courseRepository.CourseExist(courseId))
            {
                return NotFound();
            }
            Course courseFromDb = await _courseRepository.GetCourse(courseId);
            if (courseFromDb == null)
            {
                return NotFound();
            }
            var courseToPathc = _mapper.Map<CourseCreationDto>(courseFromDb);
            patchCourse.ApplyTo(courseToPathc,ModelState);
            if (!TryValidateModel(patchCourse))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(courseToPathc, courseFromDb);
            var _ = await _courseRepository.UpdateCourse(courseFromDb);
            return Ok(courseFromDb);
        }
        [HttpGet("studentCourses")]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetStudentsEnrolledCourses()
        {
            string authHeader = Request.Headers["Authorization"];
            string username = _accountService.Decrypt(authHeader);
            string[] token = username.Split(",");
            Guid id = Guid.Parse(token[0]);
            string role = token[1];
            if (role != "Student")
            {
                return NotFound();
            }
            var courses = await _courseRepository.GetEnrolledCourses(id);
            if (courses == null)
            {
                return NotFound();

            }
            var coursesToReturn = _mapper.Map<IEnumerable< CourseDto>>(courses);
            
            return Ok(coursesToReturn);
        }
        [HttpGet("studentCourses/{courseId}")]
        public async Task<ActionResult<CourseDto>> GetStudentsEnrolledCourse(Guid courseId)
        {
            string authHeader = Request.Headers["Authorization"];
            string username = _accountService.Decrypt(authHeader);
            string[] token = username.Split(",");
            Guid id = Guid.Parse(token[0]);
            string role = token[1];
            if (role != "Student")
            {
                return NotFound();
            }
            var courses = await _courseRepository.GetCourse(id,courseId);
           
            if (courses == null)
            {
                return NotFound();

            }
            var coursesToReturn = _mapper.Map<CourseDto>(courses);

            return Ok(coursesToReturn);
        }
        [HttpGet("instructorCourses")]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetInstructorscourse()
        {
            string authHeader = Request.Headers["Authorization"];
            string username = _accountService.Decrypt(authHeader);
            string[] token = username.Split(",");
            Guid id = Guid.Parse(token[0]);
            string role = token[1];
            if (role != "Instructor")
            {
                return NotFound();
            }
            var courses = await _courseRepository.GetCoursesForInstructor(id);
            if (courses.Count() == 0)
            {
                return NotFound();

            }
            var coursesToReturn = _mapper.Map<IEnumerable<CourseDto>>(courses);

            return Ok(coursesToReturn);
        }


        [HttpDelete("{courseId}/Student/{studentId")]
        public async Task<ActionResult> RemoveStudentFromCourse(Guid courseId,Guid studentId)
        {
            if(!  _courseStudentRepository.StudentExistInCourse(studentId,courseId))
            {
                return NotFound();
            }
            await _courseStudentRepository.RemoveStudentFromCourse(studentId,courseId);
            return NoContent();
        }


    }
};
