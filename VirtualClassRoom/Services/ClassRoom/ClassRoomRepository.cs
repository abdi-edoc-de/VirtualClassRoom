
using Microsoft.EntityFrameworkCore;
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
        public async Task<ClassRoom> AddClassRoom(ClassRoom classRoom)
        {
            if (classRoom == null)
            {
                throw new ArgumentNullException(nameof(classRoom));
            }
            _appDbContext.ClassRooms.Add(classRoom);
            await _appDbContext.SaveChangesAsync();
            return classRoom;


        }

        public async Task<bool> ClassRoomExist(Guid classRoomId)
        {
            if (classRoomId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(classRoomId));
            }
            return await _appDbContext.ClassRooms.AnyAsync(s => s.ClassRoomId == classRoomId);
        }

        public async Task<IEnumerable<ClassRoom>> GetCourseClassRooms(Guid courseId)
        {
            if (courseId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(courseId));

            }
            IEnumerable<ClassRoom> classRooms = await _appDbContext.ClassRooms
                .Where(cr => cr.CourseId == courseId).ToListAsync() ?? throw new ArgumentNullException(nameof(classRooms));
            return classRooms;
        }

        public async Task<ClassRoom> GetVirtualClassRoom(Guid virtualRoomId)
        {
            if (virtualRoomId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(virtualRoomId));

            }
            ClassRoom classRoom = await _appDbContext.ClassRooms.FirstOrDefaultAsync(cr => cr.ClassRoomId == virtualRoomId) ??
                throw new ArgumentNullException(nameof(classRoom));
            return classRoom;
        }


        public async Task<ClassRoom> UpdateVirualClassRoom(Guid virtualRoomId, ClassRoom virtualClassRoom)
        {

            if (virtualRoomId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(virtualRoomId));

            }
            ClassRoom classRoom = _appDbContext.ClassRooms.FirstOrDefault(cr => cr.ClassRoomId == virtualRoomId) ??
               throw new ArgumentNullException(nameof(classRoom));
            _appDbContext.ClassRooms.Update(virtualClassRoom);
            await _appDbContext.SaveChangesAsync();
            return virtualClassRoom;

        }
    }
}
