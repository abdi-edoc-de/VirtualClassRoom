﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.Entities;

namespace VirtualClassRoom.Services
{
    public interface IInstructorRepository
    {
        public Instructor FindInstructor(String email, String password);
        public Instructor GetInstructor(Guid instructorId);
        public void UpdateInstructor(Guid instructorId);
        public void AddInstructor(Instructor instructor);
        public void DeleteInstructor(Guid instructorId);

    }
}
