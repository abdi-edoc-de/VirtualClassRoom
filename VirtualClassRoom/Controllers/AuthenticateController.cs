using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.Models.User;
using VirtualClassRoom.Models.Users;
using VirtualClassRoom.Services;

namespace VirtualClassRoom.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/authenticate")]
    public class AuthenticationController : ControllerBase
    {

        private readonly IStudentRepository _studentRepository;
        private readonly IInstructorRepository _instructorRepository;
        private readonly IAccountService _accountService;

        private readonly IMapper _mapper;

        public AuthenticationController(IStudentRepository studentRepository,
            IInstructorRepository instructorRepository,
            IAccountService accountService,
            IMapper mapper)
        {
            _instructorRepository = instructorRepository ??
                throw new ArgumentNullException(nameof(instructorRepository));
            _studentRepository = studentRepository ??
                throw new ArgumentNullException(nameof(studentRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
            _accountService = accountService ??
                throw new ArgumentNullException(nameof(accountService));

        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<UserAuthenticationDto>> Authenticate([FromBody] UserCred userCred)
        {
            var token = await _accountService.Authenticate(userCred.UserName, userCred.Password);
            if (token == null)
                return NotFound();
            if (token.ElementAt(1) == "Student")
            {
                var student =await _studentRepository.FindStudent(userCred.UserName, userCred.Password);
                if (student == null)
                {
                    return NotFound();
                }
                UserAuthenticationDto studentToReturn = _mapper.Map<UserAuthenticationDto>(student);
                studentToReturn.Token = token.ElementAt(0);
                studentToReturn.Role = token.ElementAt(1);
                return Ok(studentToReturn);

            }
            else if(token.ElementAt(1)=="Instructor")
            {

                var instructor =await _instructorRepository.FindInstructor(userCred.UserName, userCred.Password);
                if (instructor == null)
                {
                    return NotFound();
                }
                UserAuthenticationDto instructorToReturn = _mapper.Map<UserAuthenticationDto>(instructor);
                instructorToReturn.Token = token.ElementAt(0);
                instructorToReturn.Role = token.ElementAt(1);
                return Ok(instructorToReturn);
            }
            return NotFound();



        }
    }
}
