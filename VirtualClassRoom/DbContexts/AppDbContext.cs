using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.Entities;

namespace VirtualClassRoom.DbContexts
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<ClassRoomStudent> ClassRoomStudents { get; set; }
        public DbSet<CourseStudent> CourseStudents { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassRoomStudent>()
                .HasKey(c => new { c.ClassRoomId, c.StudentId });
            modelBuilder.Entity<CourseStudent>()
               .HasKey(c => new { c.CourseId, c.StudentId });

        }
    }
}
