﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VirtualClassRoom.DbContexts;

namespace VirtualClassRoom.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210520123955_fixed")]
    partial class @fixed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VirtualClassRoom.Entities.ClassRoom", b =>
                {
                    b.Property<Guid>("ClassRoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClassRoomName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClassRoomId");

                    b.HasIndex("CourseId");

                    b.ToTable("ClassRooms");
                });

            modelBuilder.Entity("VirtualClassRoom.Entities.ClassRoomStudent", b =>
                {
                    b.Property<Guid>("ClassRoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Attendance")
                        .HasColumnType("bit");

                    b.HasKey("ClassRoomId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("ClassRoomStudents");
                });

            modelBuilder.Entity("VirtualClassRoom.Entities.Course", b =>
                {
                    b.Property<Guid>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("InstructorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("CourseId");

                    b.HasIndex("InstructorId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CourseId = new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                            Description = "Commandeering a ship in rough waters isn't easy.  Commandeering it without getting caught is even harder.  In this course you'll learn how to sail away and avoid those pesky musketeers.",
                            InstructorId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            Title = "Commandeering a Ship Without Getting Caught"
                        },
                        new
                        {
                            CourseId = new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee"),
                            Description = "In this course, the author provides tips to avoid, or, if needed, overthrow pirate mutiny.",
                            InstructorId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            Title = "Overthrowing Mutiny"
                        },
                        new
                        {
                            CourseId = new Guid("d173e20d-159e-4127-9ce9-b0ac2564ad97"),
                            Description = "Every good pirate loves rum, but it also has a tendency to get you into trouble.  In this course you'll learn how to avoid that.  This new exclusive edition includes an additional chapter on how to run fast without falling while drunk.",
                            InstructorId = new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                            Title = "Avoiding Brawls While Drinking as Much Rum as You Desire"
                        },
                        new
                        {
                            CourseId = new Guid("40ff5488-fdab-45b5-bc3a-14302d59869a"),
                            Description = "In this course you'll learn how to sing all-time favourite pirate songs without sounding like you actually know the words or how to hold a note.",
                            InstructorId = new Guid("2902b665-1190-4c70-9915-b9c2d7680450"),
                            Title = "Singalong Pirate Hits"
                        });
                });

            modelBuilder.Entity("VirtualClassRoom.Entities.CourseStudent", b =>
                {
                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CourseId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("CourseStudents");

                    b.HasData(
                        new
                        {
                            CourseId = new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee"),
                            StudentId = new Guid("2aadd2df-7caf-45ab-9355-7f6332985a87")
                        },
                        new
                        {
                            CourseId = new Guid("d173e20d-159e-4127-9ce9-b0ac2564ad97"),
                            StudentId = new Guid("2aadd2df-7caf-45ab-9355-7f6332985a87")
                        },
                        new
                        {
                            CourseId = new Guid("40ff5488-fdab-45b5-bc3a-14302d59869a"),
                            StudentId = new Guid("2aadd2df-7caf-45ab-9355-7f6332985a87")
                        },
                        new
                        {
                            CourseId = new Guid("40ff5488-fdab-45b5-bc3a-14302d59869a"),
                            StudentId = new Guid("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51")
                        },
                        new
                        {
                            CourseId = new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                            StudentId = new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05")
                        },
                        new
                        {
                            CourseId = new Guid("d173e20d-159e-4127-9ce9-b0ac2564ad97"),
                            StudentId = new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05")
                        });
                });

            modelBuilder.Entity("VirtualClassRoom.Entities.Instructor", b =>
                {
                    b.Property<Guid>("InstructorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InstructorId");

                    b.ToTable("Instructors");

                    b.HasData(
                        new
                        {
                            InstructorId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            Email = "nti@gmail.com",
                            FirstName = "Nati",
                            LastName = "Beak",
                            Password = "12345678"
                        },
                        new
                        {
                            InstructorId = new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                            Email = "Aman@gmail.com",
                            FirstName = "Aman",
                            LastName = "Debe",
                            Password = "12345678"
                        },
                        new
                        {
                            InstructorId = new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                            Email = "Kidus@gmail.com",
                            FirstName = "Kidus",
                            LastName = "Beak",
                            Password = "12345678"
                        },
                        new
                        {
                            InstructorId = new Guid("2902b665-1190-4c70-9915-b9c2d7680450"),
                            Email = "biruk@gmail.com",
                            FirstName = "Biruk",
                            LastName = "Beak",
                            Password = "12345678"
                        });
                });

            modelBuilder.Entity("VirtualClassRoom.Entities.Resource", b =>
                {
                    b.Property<Guid>("ResourceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ResourceId");

                    b.HasIndex("CourseId");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("VirtualClassRoom.Entities.Student", b =>
                {
                    b.Property<Guid>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentId = new Guid("2aadd2df-7caf-45ab-9355-7f6332985a87"),
                            Email = "abdi@gmail.com",
                            FirstName = "Abdi",
                            LastName = "Beak",
                            Password = "12345678"
                        },
                        new
                        {
                            StudentId = new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                            Email = "hanan@gmail.com",
                            FirstName = "Hanan",
                            LastName = "Debe",
                            Password = "12345678"
                        },
                        new
                        {
                            StudentId = new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                            Email = "Kidus@gmail.com",
                            FirstName = "Sura",
                            LastName = "Beak",
                            Password = "12345678"
                        },
                        new
                        {
                            StudentId = new Guid("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"),
                            Email = "beki@gmail.com",
                            FirstName = "Beki",
                            LastName = "Beak",
                            Password = "12345678"
                        });
                });

            modelBuilder.Entity("VirtualClassRoom.Entities.ClassRoom", b =>
                {
                    b.HasOne("VirtualClassRoom.Entities.Course", "Course")
                        .WithMany("ClassRooms")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VirtualClassRoom.Entities.ClassRoomStudent", b =>
                {
                    b.HasOne("VirtualClassRoom.Entities.ClassRoom", "ClassRoom")
                        .WithMany("ClassRoomStudents")
                        .HasForeignKey("ClassRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VirtualClassRoom.Entities.Student", "Student")
                        .WithMany("ClassRoomStudents")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VirtualClassRoom.Entities.Course", b =>
                {
                    b.HasOne("VirtualClassRoom.Entities.Instructor", "Instructor")
                        .WithMany("Courses")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VirtualClassRoom.Entities.CourseStudent", b =>
                {
                    b.HasOne("VirtualClassRoom.Entities.Course", "Course")
                        .WithMany("CourseStudents")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VirtualClassRoom.Entities.Student", "Student")
                        .WithMany("CourseStudents")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VirtualClassRoom.Entities.Resource", b =>
                {
                    b.HasOne("VirtualClassRoom.Entities.Course", "Course")
                        .WithMany("Resources")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}