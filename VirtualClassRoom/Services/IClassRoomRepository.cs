using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.Entities;

namespace VirtualClassRoom.Services
{
    public interface IClassRoomRepository
    {
        public bool ClassRoomExist(Guid classRoomId);

        public ClassRoom GetVirtualClassRoom(Guid virtualRoomId);
        public void UpdateVirualClassRoom(Guid virtualRoomId, ClassRoom virtualClassRoom);
        public IEnumerable<ClassRoom> GetCourseClassRooms(Guid courseId);
        public void AddClassRoom(ClassRoom classRoom);

    }
}
