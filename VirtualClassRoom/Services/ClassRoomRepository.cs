
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.DbContexts;
using VirtualClassRoom.Entities;
using VirtualClassRoom.Services;

namespace VirtualClassRoom.Services

{
    public class ClassRoomRepository : IClassRoomRepository
    {
        private readonly AppDbContext _appDbContext;

        public ClassRoomRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }
        public void AddClassRoom(ClassRoom classRoom)
        {
            if (classRoom == null)
            {
                throw new ArgumentNullException(nameof(classRoom));
            }
            _appDbContext.ClassRooms.Add(classRoom);
            _appDbContext.SaveChanges();


        }

        public IEnumerable<ClassRoom> GetCourseClassRooms(Guid courseId)
        {
            if (courseId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(courseId));

            }
            IEnumerable<ClassRoom> classRooms = _appDbContext.ClassRooms
                .Where(cr => cr.CourseId == courseId).ToList() ?? throw new ArgumentNullException(nameof(classRooms));
            return classRooms;
        }

        public ClassRoom GetVirtualClassRoom(Guid virtualRoomId)
        {
            if (virtualRoomId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(virtualRoomId));

            }
            ClassRoom classRoom = _appDbContext.ClassRooms.FirstOrDefault(cr => cr.ClassRoomId == virtualRoomId) ??
                throw new ArgumentNullException(nameof(classRoom));
            return classRoom;
        }


        public void UpdateVirualClassRoom(Guid virtualRoomId, ClassRoom virtualClassRoom)
        {

            if (virtualRoomId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(virtualRoomId));

            }
            ClassRoom classRoom = _appDbContext.ClassRooms.FirstOrDefault(cr => cr.ClassRoomId == virtualRoomId) ??
               throw new ArgumentNullException(nameof(classRoom));
            _appDbContext.ClassRooms.Update(virtualClassRoom);
            _appDbContext.SaveChanges();
        }
    }
}
