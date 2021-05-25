using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.Entities;
using VirtualClassRoom.Models;
using VirtualClassRoom.Models.Users;
using VirtualClassRoom.Services;

namespace VirtualClassRoom.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/authenticate/Students")]
    public class StudentController:ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;


        public StudentController(IStudentRepository studentRepository, IAccountService accountService,
            IMapper mapper)
        {
            _studentRepository = studentRepository ??
                throw new ArgumentNullException(nameof(studentRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
            _accountService = accountService ??
                throw new ArgumentNullException(nameof(accountService));


        }

        [HttpGet(Name = "GetStudentInfo")]
        public ActionResult<UserDto> GetStudentInfo()
        {
            string authHeader = Request.Headers["Authorization"];
            string username = _accountService.Decrypt(authHeader);
            string[] token = username.Split(",");
            Guid id = Guid.Parse(token[0].Trim());
            string role = token[1].Trim();

            Student studentFromDb = _studentRepository.GetStudent(id);
            if (studentFromDb == null)
            {
                return NotFound();
            }
            UserDto studentToReturn = _mapper.Map<UserDto>(studentFromDb);
            return Ok(studentToReturn);

        }
        [AllowAnonymous]
        [HttpPost("CreateStudent")]
        public ActionResult<UserDto> CreateStudent([FromBody]UserCreationDto student)
        {
            Student studentEntity = _mapper.Map<Student>(student);
            _studentRepository.AddStudent(studentEntity);
            UserDto studentToReturn = _mapper.Map<UserDto>(studentEntity);
            return CreatedAtRoute("GetStudentInformation", new { studentId = studentToReturn.Id },
                studentToReturn);
        }

        [HttpGet("{studentId}",Name = "GetStudentInformation")]
        public ActionResult<UserDto> GetStudentInformation(Guid studentID)
        {
            if (studentID == Guid.Empty)
            {
                return NotFound();
            }
            Student student = _studentRepository.GetStudent(studentID);
            if(student == null)
            {
                return NotFound();
            }
            UserDto studentToReturn = _mapper.Map<UserDto>(student);
            return Ok(studentToReturn);
        }
        [HttpPatch("{studentID}")]
        public ActionResult UpdateStudent(Guid studentId,
                                        JsonPatchDocument<UserUpdateDto> patchStudent)
        {
            if (!_studentRepository.StudentExist(studentId))
            {
                return NotFound();
            }
            Student studentFromDb = _studentRepository.GetStudent(studentId);
            if (studentFromDb == null)
            {
                return NotFound();
            }
            var studentToPatch = _mapper.Map<UserUpdateDto>(studentFromDb);
            patchStudent.ApplyTo(studentToPatch);
            _mapper.Map(studentToPatch, studentFromDb);


            _studentRepository.UpdateStudent(studentId, studentFromDb);
            
            UserDto studentToReturn = _mapper.Map<UserDto>(studentFromDb);
            return Ok(studentToReturn);
        }



    }
}
