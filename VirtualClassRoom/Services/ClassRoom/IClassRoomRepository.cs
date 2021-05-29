using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.Entities;

namespace VirtualClassRoom.Services
{
    public interface IClassRoomRepository
    {
        public Task<bool> ClassRoomExist(Guid classRoomId);

        public Task<ClassRoom> GetVirtualClassRoom(Guid virtualRoomId);
        public Task<ClassRoom> UpdateVirualClassRoom(Guid virtualRoomId, ClassRoom virtualClassRoom);
        public Task<IEnumerable<ClassRoom>> GetCourseClassRooms(Guid courseId);
        public Task<ClassRoom> AddClassRoom(ClassRoom classRoom);

    }
}
