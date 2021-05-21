﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.DbContexts;
using VirtualClassRoom.Entities;

namespace VirtualClassRoom.Services
{
     class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _appDbContext;

        public CourseRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext)); 
        }
        public void AddCourse(Guid instructorId, Course course)
        {
            if (instructorId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(instructorId));
            }
            var instructor = _appDbContext.Instructors.FirstOrDefault(i => i.InstructorId == instructorId);
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }
            course.InstructorId = instructorId;
            course.Instructor = instructor ?? throw new ArgumentNullException(nameof(instructor));
            _appDbContext.Courses.Add(course);
            _appDbContext.SaveChanges();
        }

  
        public ICollection<CourseStudent> GetEnrolledCourses(Guid studentId)
        {
            if (studentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(studentId));
            }

            return _appDbContext.CourseStudents
                        .Where(c => c.StudentId == studentId)
                        .ToList();
        }
        public ICollection<Course> GetCourses()
        {            
            return _appDbContext.Courses.ToList();
        }

        public ICollection<Course> GetCoursesForInstructor(Guid instructorId)
        {
            if (instructorId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(instructorId));
            }

            return _appDbContext.Courses
                        .Where(c => c.InstructorId == instructorId)
                        .ToList();
        }
        
        public void UpdateCourse(Guid courseId)
        {
            if (courseId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(courseId));
            }
            Course course = _appDbContext.Courses.FirstOrDefault(c => c.CourseId == courseId)??
                 throw new ArgumentNullException(nameof(course)); ;
            //if (course == null)
            //{
            //    throw new ArgumentNullException(nameof(course));

            //}
            _appDbContext.Update(course);
            _appDbContext.SaveChanges();

        }

        public void DeleteCourse(Guid courseId)
        {
            if (courseId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(courseId));
            }
            var course = _appDbContext.Courses.FirstOrDefault(c => c.CourseId == courseId);
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));

            }
            _appDbContext.Courses.Remove(course);
            _appDbContext.SaveChanges();

        }

        public bool CourseExist(Guid courseId)
        {
            if (courseId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(courseId));
            }
            return _appDbContext.Courses.Any(s => s.CourseId == courseId);
        }

        public Course GetCourse(Guid courseId)
        {
            if(courseId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(courseId));
            }
            return _appDbContext.Courses.FirstOrDefault(c => c.CourseId == courseId);
            
        }
    }
}