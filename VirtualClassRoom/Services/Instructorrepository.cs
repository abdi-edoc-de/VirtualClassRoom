﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.DbContexts;
using VirtualClassRoom.Entities;

namespace VirtualClassRoom.Services
{
    public class InstructorRepository:IInstructorRepository
    {
        private readonly AppDbContext _appDbContext;

        public InstructorRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }
        public void AddInstructor(Instructor instructor)
        {
            if (instructor == null)
            {
                throw new ArgumentNullException(nameof(instructor));
            }
            _appDbContext.Instructors.Add(instructor);
            _appDbContext.SaveChanges();
        }

        public void DeleteInstructor(Guid instructorId)
        {
            if (instructorId == null)
            {
                throw new ArgumentNullException(nameof(instructorId));
            }
            Instructor instructor = _appDbContext.Instructors.FirstOrDefault(s => s.InstructorId == instructorId) ??
                throw new ArgumentNullException(nameof(instructor));
            _appDbContext.Instructors.Remove(instructor);
        }

        public Instructor FindInstructor(string email, string password)
        {
            if (String.IsNullOrWhiteSpace(email) || String.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException(nameof(email));
            }
            email = email.Trim();
            password = password.Trim();
            Instructor instructor = _appDbContext.Instructors.FirstOrDefault(s => s.Email == email && s.Password == password) ??
                throw new ArgumentNullException(nameof(instructor));
            return instructor;


        }

        public Instructor GetInstructor(Guid instructorId)
        {
            if (instructorId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(instructorId));
            }

            return _appDbContext.Instructors
                        .FirstOrDefault(c => c.InstructorId == instructorId);

        }

        public void UpdateInstructor(Guid instructorId)
        {
            if (instructorId == null)
            {
                throw new ArgumentNullException(nameof(instructorId));
            }
            Instructor instructor = _appDbContext.Instructors.FirstOrDefault(c => c.InstructorId == instructorId);
            if (instructor == null)
            {
                throw new ArgumentNullException(nameof(instructor));

            }
            _appDbContext.Update(instructor);
            _appDbContext.SaveChanges();
        }
    }
}
