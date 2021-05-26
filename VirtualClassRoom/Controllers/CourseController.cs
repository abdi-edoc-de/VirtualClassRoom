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
            IMapper mapper,ICourseStudentRepository courseStudentRepository)
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
        public ActionResult AddCourse([FromBody] CourseCreationDto course)
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

            _courseRepository.AddCourse(id,courseToDb);
            CourseDto courseToReturn = _mapper.Map<CourseDto>(course);
            courseToReturn.InstructorId = id;
            return CreatedAtRoute("GetCourse",
                new { id = courseToReturn.CourseId },courseToReturn);

        }


        [HttpGet("{courseId}",Name = "GetCourse")]
        public ActionResult<CourseDto> GetCourse(Guid courseId)
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
            Course course = _courseRepository.GetCourse(courseId);
            CourseDto courseToReturn = _mapper.Map<CourseDto>(course);
            return Ok(courseToReturn);

        }
        [HttpPost("{courseId}")]
        public ActionResult AddStudents(Guid courseId,IEnumerable<CourseStudentCreationDto> courseStudents)
        {
            var courseStudentsFromDb = _mapper.Map<IEnumerable<CourseStudent>>(courseStudents);

            foreach(var courseStudent in courseStudentsFromDb)
            {
                _courseStudentRepository.AddStudentInCourse(courseStudent);
            }
            var studentIds = courseStudentsFromDb
                .Select(s => s.StudentId);
            var studentToReturn = _courseStudentRepository.GetStudents(studentIds);
            var idsAsString = string.Join(",",studentIds);
            return CreatedAtRoute("GetStudents",new { courseId,ids= idsAsString },
                                    studentToReturn);

        }
        [HttpGet("courseId/({ids})", Name = "GetStudents")]
        public ActionResult GetStudents(Guid courseId,
            [FromRoute][ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            if (ids == null)
            {
                return BadRequest();
            }
            var studentsFromDb = _courseStudentRepository.GetStudents(ids);

            if(ids.Count() != studentsFromDb.Count())
            {
                return NotFound();
            }
            var studentsToReturn = _mapper
                .Map<IEnumerable<UserDto>>(studentsFromDb);
            return Ok(studentsToReturn);
        }
        [HttpGet("{courseId}/Students")]
        public ActionResult<IEnumerable<UserDto>> GetStudents(Guid courseId)
        {
            string authHeader = Request.Headers["Authorization"];
            string username = _accountService.Decrypt(authHeader);
            string[] token = username.Split(",");
            Guid id = Guid.Parse(token[0]);
            string role = token[1];


            var students = _courseStudentRepository.GetStudents(courseId);
            if (students == null)
            {
                return NotFound();
            }
            var studentsToReturn = _mapper
                .Map<IEnumerable<UserDto>>(students);

            return Ok(studentsToReturn);

        }
        [HttpPatch("")]
        public ActionResult UpdateCourse(Guid courseId,JsonPatchDocument<CourseCreationDto> patchCourse)
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
            if (!_courseRepository.CourseExist(courseId))
            {
                return NotFound();
            }
            Course courseFromDb = _courseRepository.GetCourse(courseId);
            if (courseFromDb == null)
            {
                return NotFound();
            }
            var courseToPathc = _mapper.Map<CourseCreationDto>(courseFromDb);
            patchCourse.ApplyTo(courseToPathc);
            _mapper.Map(courseToPathc, courseFromDb);
            _courseRepository.UpdateCourse(courseFromDb);
            return Ok(courseFromDb);
        }



    }
};
