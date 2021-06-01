﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.DbContexts;
using VirtualClassRoom.Entities;

namespace VirtualClassRoom.Services.ClassRoomStudents
{
    public class ClassRoomStudentRepsitory : IClassRoomStudentRepository
    {
        private readonly AppDbContext _appDbContext;

        public ClassRoomStudentRepsitory(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }
        public async Task<ClassRoomStudent> AddClassRoomStudent(ClassRoomStudent classRoomStudent)
        {
            if(classRoomStudent == null)
            {
                throw new ArgumentNullException(nameof(classRoomStudent));

            }
            await _appDbContext.ClassRoomStudents.AddAsync(classRoomStudent);
            await _appDbContext.SaveChangesAsync();
            return classRoomStudent;
        }
    }
}