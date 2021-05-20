﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.Services;
using VirtualClassRoom.Entities;
namespace VirtualClassRoom.Controllers
{
    [Route("api/Courses/{CourseID}/Classrooms")]
    [ApiController]
    public class ClassroomController : ControllerBase
    {
        private readonly IClassRoomRepository _ClassroomRepository;

        public ClassroomController(IClassRoomRepository classRoomRepository)
        {
            _ClassroomRepository = classRoomRepository;
        }

        [HttpGet("{ClassroomID}")]
        public IActionResult GetVirtualClassroom(Guid ClassroomID)
        {
            var classroom = _ClassroomRepository.GetVirtualClassRoom(ClassroomID);
            if (classroom == null)
            {
                return NotFound();
            }
            return Ok(classroom);
        }

        [HttpGet]
        public IActionResult GetVirtualClassroomsForCourse(Guid CourseID)
        {
            var classrooms = _ClassroomRepository.GetCourseClassRooms(CourseID);
            return Ok(classrooms);
        }

        [HttpPost]
        [Consumes("application/json")]
        public IActionResult PostVirtualClassroom(Guid CourseID, [FromBody] ClassRoomDTO classRoomDTO)
        {
            ClassRoom classRoom = new ClassRoom
            {
                Url = Guid.NewGuid().ToString(),
                CourseId = CourseID,
                ClassRoomName = classRoomDTO.ClassRoomName
            };
            _ClassroomRepository.AddClassRoom(classRoom);
            return Ok();// CreatedAtAction("GetVirtualClassroom", new { id = classRoom.ClassRoomId }, classRoom);
        }

        [HttpGet("{ClassroomID}/join")]
        public IActionResult JoinVirtualClassroom(Guid ClassroomID)
        {
            // TODO: Implement Join Classroom feature
            return Ok(ClassroomID);
        }

        [HttpPatch("{ClassroomID}")]
        public IActionResult UpdateVirtualClassroom(Guid ClassroomID, ClassRoomDTO classRoom)
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