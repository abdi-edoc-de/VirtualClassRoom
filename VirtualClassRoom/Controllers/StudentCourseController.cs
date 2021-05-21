using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.Services;

namespace VirtualClassRoom.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/authenticate/Students/{studentId}")]

    public class StudentCourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;


        public StudentCourseController(ICourseRepository courseRepository, IAccountService accountService,
            IMapper mapper)
        {
            _courseRepository = courseRepository ??
                throw new ArgumentNullException(nameof(courseRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
            _accountService = accountService ??
                throw new ArgumentNullException(nameof(accountService));


        }
        //[HttpGet("{courseId}")]
        //public ActionResult GetCourse(Guid courseId,Guid studentId)
        //{


        //    throw new NotImplementedException();
        //}

    }
}
