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

            modelBuilder.Entity<Student>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Instructor>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Instructor>().HasData(
                new Instructor()
                {
                    InstructorId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    FirstName = "Nati",
                    LastName = "Beak",
                    Password = "12345678",
                    Email="nti@gmail.com",
                },
                new Instructor()
                {
                    InstructorId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    FirstName = "Aman",
                    LastName = "Debe",
                    Password = "12345678",
                    Email="Aman@gmail.com",
                },
                new Instructor()
                {
                    InstructorId = Guid.Parse("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                    FirstName = "Kidus",
                    LastName = "Beak",
                    Password = "12345678",
                    Email="Kidus@gmail.com",
                },
                new Instructor()
                {
                    InstructorId = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                    FirstName = "Biruk",
                    LastName = "Beak",
                    Password = "12345678",
                    Email="biruk@gmail.com",
                });

            modelBuilder.Entity<Course>().HasData(
               new Course
               {
                   CourseId = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                   InstructorId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                   Title = "Commandeering a Ship Without Getting Caught",
                   Description = "Commandeering a ship in rough waters isn't easy.  Commandeering it without getting caught is even harder.  In this course you'll learn how to sail away and avoid those pesky musketeers."
               },
               new Course
               {
                   CourseId = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea7ee"),
                   InstructorId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                   Title = "Overthrowing Mutiny",
                   Description = "In this course, the author provides tips to avoid, or, if needed, overthrow pirate mutiny."
               },
               new Course
               {
                   CourseId = Guid.Parse("d173e20d-159e-4127-9ce9-b0ac2564ad97"),
                   InstructorId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                   Title = "Avoiding Brawls While Drinking as Much Rum as You Desire",
                   Description = "Every good pirate loves rum, but it also has a tendency to get you into trouble.  In this course you'll learn how to avoid that.  This new exclusive edition includes an additional chapter on how to run fast without falling while drunk."
               },
               new Course
               {
                   CourseId = Guid.Parse("40ff5488-fdab-45b5-bc3a-14302d59869a"),
                   InstructorId = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                   Title = "Singalong Pirate Hits",
                   Description = "In this course you'll learn how to sing all-time favourite pirate songs without sounding like you actually know the words or how to hold a note."
               }
               );
            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                    StudentId = Guid.Parse("2aadd2df-7caf-45ab-9355-7f6332985a87"),
                    FirstName = "Abdi",
                    LastName = "Beak",
                    Password = "12345678",
                    Email="abdi@gmail.com",
                },
                new Student()
                {
                    StudentId = Guid.Parse("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                    FirstName = "Hanan",
                    LastName = "Debe",
                    Password = "12345678",
                    Email="hanan@gmail.com",
                },
                new Student()
                {
                    StudentId = Guid.Parse("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                    FirstName = "Sura",
                    LastName = "Beak",
                    Password = "12345678",
                    Email="Kidus@gmail.com",
                },
                new Student()
                {
                    StudentId = Guid.Parse("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"),
                    FirstName = "Beki",
                    LastName = "Beak",
                    Password = "12345678",
                    Email="beki@gmail.com",
                });
              modelBuilder.Entity<CourseStudent>().HasData(
                new CourseStudent()
                {
                    StudentId = Guid.Parse("2aadd2df-7caf-45ab-9355-7f6332985a87"),
                    CourseId= Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea7ee")
                },
                 new CourseStudent()
                {
                    StudentId = Guid.Parse("2aadd2df-7caf-45ab-9355-7f6332985a87"),
                    CourseId= Guid.Parse("d173e20d-159e-4127-9ce9-b0ac2564ad97")
                }, new CourseStudent()
                {
                    StudentId = Guid.Parse("2aadd2df-7caf-45ab-9355-7f6332985a87"),
                    CourseId= Guid.Parse("40ff5488-fdab-45b5-bc3a-14302d59869a")
                }, new CourseStudent()
                {
                    StudentId = Guid.Parse("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"),
                    CourseId= Guid.Parse("40ff5488-fdab-45b5-bc3a-14302d59869a")
                }, new CourseStudent()
                {
                    StudentId = Guid.Parse("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                    CourseId= Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b")
                }, new CourseStudent()
                {
                    StudentId = Guid.Parse("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                    CourseId= Guid.Parse("d173e20d-159e-4127-9ce9-b0ac2564ad97")
                });

        }
    }
}
