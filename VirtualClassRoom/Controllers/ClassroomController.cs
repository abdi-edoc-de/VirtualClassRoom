using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.Services;
using VirtualClassRoom.Entities;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using VirtualClassRoom.Models.ClassRooms;

namespace VirtualClassRoom.Controllers
{
    [Authorize]
    [Route("api/Courses/{courseId}/Classrooms")]
    [ApiController]
    public class ClassroomController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IClassRoomRepository _ClassroomRepository;

        public ClassroomController(IClassRoomRepository classRoomRepository,IMapper mapper)
        {
            _mapper = mapper;
            _ClassroomRepository = classRoomRepository;
        }

        [HttpGet("{ClassroomID}",Name ="GetClassRoom")]
        public ActionResult<ClassRoomDto> GetVirtualClassroom(Guid ClassroomID)
        {
            var classroom = _ClassroomRepository.GetVirtualClassRoom(ClassroomID);
            if (classroom == null)
            {
                return NotFound();
            }
            ClassRoomDto classRoomToReturn = _mapper.Map<ClassRoomDto>(classroom);
            
            return Ok(classRoomToReturn);
        }

        [HttpGet(Name = "GetVirtualClassroomsForCourse")]
        public ActionResult< IEnumerable<ClassRoomDto>> GetVirtualClassroomsForCourse(Guid courseId)
        {

            var classrooms = _ClassroomRepository.GetCourseClassRooms(courseId);
            if(classrooms == null)
            {
                return NotFound();

            }
            var classRoomToReturn = _mapper.Map<IEnumerable<ClassRoomDto>>(classrooms);
            return Ok(classRoomToReturn);
        }

        [HttpPost]
        [Consumes("application/json")]
        public ActionResult<ClassRoomDto> PostVirtualClassroom(Guid courseId, [FromBody] ClassRoomUpdateDto classRoomDTO)
        {
            ClassRoom classRoom = new ClassRoom
            {
                Url = Guid.NewGuid().ToString(),
                CourseId = courseId,
                ClassRoomName = classRoomDTO.ClassRoomName
            };
            _ClassroomRepository.AddClassRoom(classRoom);
            var classRoomToReturn = _mapper.Map<ClassRoomDto>(classRoom);
            return CreatedAtAction("GetClassRoom", 
                             new { CourseId= courseId, ClassRoomId = classRoomToReturn.ClassRoomId },
                             classRoomToReturn);
        }

        [HttpGet("{ClassroomID}/join")]
        public IActionResult JoinVirtualClassroom(Guid ClassroomID)
        {
            // TODO: Implement Join Classroom feature
            return Ok(ClassroomID);
        }

        [HttpPatch("{ClassroomID}")]
        public IActionResult UpdateVirtualClassroom(Guid ClassroomID, ClassRoomDto classRoom)
        {
            var classroom = _ClassroomRepository.GetVirtualClassRoom(ClassroomID);
            if (classroom == null)
            {
                return NotFound();
            }
            classroom.ClassRoomName = classRoom.ClassRoomName;
            _ClassroomRepository.UpdateVirualClassRoom(ClassroomID, classroom);
            return Accepted();
        }
    }
}
