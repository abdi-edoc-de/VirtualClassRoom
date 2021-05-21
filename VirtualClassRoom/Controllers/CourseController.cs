using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.Entities;
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
        [HttpGet("{courseId}")]
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
        public ActionResult AddStudent(Guid courseId,IEnumerable<CourseStudentCreationDto> courseStudents)
        {
            var courseStudentsFromDb = _mapper.Map<IEnumerable<CourseStudent>>(courseStudents);
            foreach(var courseStudent in courseStudentsFromDb)
            {
                _courseStudentRepository.AddStudentInCourse(courseStudent);
            }
            return Ok();

        }

    }
};
