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
    [Route("api/Course/{courseId}/Classrooms")]
    [ApiController]
    public class ClassroomController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IClassRoomRepository _ClassroomRepository;

        public ClassroomController(IClassRoomRepository classRoomRepository, IMapper mapper)
        {
            _mapper = mapper;
            _ClassroomRepository = classRoomRepository;
        }

        [HttpGet("{ClassroomID}", Name = "GetClassRoom")]
        public async Task<ActionResult<ClassRoomDto>> GetVirtualClassroom(Guid ClassroomID)
        {
            var classroom = await _ClassroomRepository.GetVirtualClassRoom(ClassroomID);
            if (classroom == null)
            {
                return NotFound();
            }
            ClassRoomDto classRoomToReturn = _mapper.Map<ClassRoomDto>(classroom);

            return Ok(classRoomToReturn);
        }

        [HttpGet(Name = "GetVirtualClassroomsForCourse")]
        public async Task<ActionResult<IEnumerable<ClassRoomDto>>> GetVirtualClassroomsForCourse(Guid courseId)
        {

            var classrooms = await _ClassroomRepository.GetCourseClassRooms(courseId);
            if (classrooms == null)
            {
                return NotFound();

            }
            var classRoomToReturn = _mapper.Map<IEnumerable<ClassRoomDto>>(classrooms);
            return Ok(classRoomToReturn);
        }

        [HttpPost]
        //[Consumes("application/json")]
        public async Task<ActionResult<ClassRoomCreationDto>> PostVirtualClassroom(Guid courseId, [FromBody] ClassRoomCreationDto classRoomDTO)
        {

           
            var classRoom = _mapper.Map<ClassRoom>(classRoomDTO);
            classRoom.Url = Guid.NewGuid().ToString();
            var _ = await _ClassroomRepository.AddClassRoom(classRoom);
            var classRoomToReturn = _mapper.Map<ClassRoomDto>(classRoom);
            return CreatedAtRoute("GetClassRoom",
                             new { CourseId = courseId, ClassRoomId = classRoomToReturn.ClassRoomId },
                             classRoomToReturn);
        }

        [HttpGet("{ClassroomID}/join")]
        public async Task<ActionResult> JoinVirtualClassroom(Guid ClassroomID)
        {
            // TODO: Implement Join Classroom feature
            return Ok(ClassroomID);
        }

        [HttpPatch("{ClassroomID}")]
        public async Task<ActionResult> UpdateVirtualClassroom(Guid ClassroomID, ClassRoomDto classRoom)
        {
            var classroom = await _ClassroomRepository.GetVirtualClassRoom(ClassroomID);
            if (classroom == null)
            {
                return NotFound();
            }
            classroom.ClassRoomName = classRoom.ClassRoomName;
            var _ = await _ClassroomRepository.UpdateVirualClassRoom(ClassroomID, classroom);
            return Accepted();
        }
        [HttpDelete("{ClassroomID}")]
        public async Task<ActionResult> DeleteClassRoom(Guid ClassroomID)
        {
            var classroom = await _ClassroomRepository.DeleteClassRoom(ClassroomID);
            if (classroom == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
