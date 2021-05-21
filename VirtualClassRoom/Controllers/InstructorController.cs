using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.Entities;
using VirtualClassRoom.Models;
using VirtualClassRoom.Services;

namespace VirtualClassRoom.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/authenticate/Instructor")]
    public class InstructorController: ControllerBase
    {
        private readonly IInstructorRepository _instructorRepository;
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;


        public InstructorController(IInstructorRepository instructorRepository
            , IAccountService accountService,
            IMapper mapper)
        {
           _instructorRepository = instructorRepository ??
                throw new ArgumentNullException(nameof(instructorRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
            _accountService = accountService ??
                throw new ArgumentNullException(nameof(accountService));
        }


        [HttpGet(Name = "GetInstrucotrInfo")]
        public ActionResult<UserDto> GetInstrucotrInfo()
        {
            string authHeader = Request.Headers["Authorization"];
            string username = _accountService.Decrypt(authHeader);
            string[] token = username.Split(",");
            Guid id = Guid.Parse(token[0].Trim());
            string role = token[1].Trim();

            Instructor instructorFromDb = _instructorRepository.GetInstructor(id);
            if (instructorFromDb == null)
            {
                return NotFound();
            }
            UserDto instructorToReturn = _mapper.Map<UserDto>(instructorFromDb);
            return Ok(instructorToReturn);
        }
        [AllowAnonymous]
        [HttpPost("CreateInstructor")]
        public ActionResult<UserDto> CreateInstructor([FromBody] UserCreationDto instructor)
        {
            Instructor instructorEntity = _mapper.Map<Instructor>(instructor);
            _instructorRepository.AddInstructor(instructorEntity);
            UserDto instructorToReturn = _mapper.Map<UserDto>(instructorEntity);
            return CreatedAtRoute("GetInstructorInformation", new { instructorId = instructorToReturn.Id },
                instructorToReturn);
        }

        [HttpGet("{instructorId}", Name = "GetInstructorInformation")]
        public ActionResult<UserDto> GetInstructorInformation(Guid instructorId)
        {
            if (instructorId == Guid.Empty)
            {
                return NotFound();
            }
            Instructor instructor = _instructorRepository.GetInstructor(instructorId);
            if (instructor == null)
            {
                return NotFound();
            }
            UserDto instrucorToReturn = _mapper.Map<UserDto>(instructor);
            return Ok(instrucorToReturn);
        }

    }
}
