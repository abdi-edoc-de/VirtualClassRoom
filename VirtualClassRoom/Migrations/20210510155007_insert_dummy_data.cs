using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VirtualClassRoom.Migrations
{
    public partial class insert_dummy_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Instructors_InstructorId",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instructors",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Instructors");

            migrationBuilder.AddColumn<Guid>(
                name: "InstructorId",
                table: "Instructors",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instructors",
                table: "Instructors",
                column: "InstructorId");

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "InstructorId", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "nti@gmail.com", "Nati", "Beak" },
                    { new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), "Aman@gmail.com", "Aman", "Debe" },
                    { new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"), "Kidus@gmail.com", "Kidus", "Beak" },
                    { new Guid("2902b665-1190-4c70-9915-b9c2d7680450"), "biruk@gmail.com", "Biruk", "Beak" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("2aadd2df-7caf-45ab-9355-7f6332985a87"), "abdi@gmail.com", "Abdi", "Beak" },
                    { new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"), "hanan@gmail.com", "Hanan", "Debe" },
                    { new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"), "Kidus@gmail.com", "Sura", "Beak" },
                    { new Guid("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"), "beki@gmail.com", "Beki", "Beak" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "Description", "InstructorId", "Title" },
                values: new object[,]
                {
                    { new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"), "Commandeering a ship in rough waters isn't easy.  Commandeering it without getting caught is even harder.  In this course you'll learn how to sail away and avoid those pesky musketeers.", new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "Commandeering a Ship Without Getting Caught" },
                    { new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee"), "In this course, the author provides tips to avoid, or, if needed, overthrow pirate mutiny.", new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "Overthrowing Mutiny" },
                    { new Guid("d173e20d-159e-4127-9ce9-b0ac2564ad97"), "Every good pirate loves rum, but it also has a tendency to get you into trouble.  In this course you'll learn how to avoid that.  This new exclusive edition includes an additional chapter on how to run fast without falling while drunk.", new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), "Avoiding Brawls While Drinking as Much Rum as You Desire" },
                    { new Guid("40ff5488-fdab-45b5-bc3a-14302d59869a"), "In this course you'll learn how to sing all-time favourite pirate songs without sounding like you actually know the words or how to hold a note.", new Guid("2902b665-1190-4c70-9915-b9c2d7680450"), "Singalong Pirate Hits" }
                });

            migrationBuilder.InsertData(
                table: "CourseStudents",
                columns: new[] { "CourseId", "StudentId" },
                values: new object[,]
                {
                    { new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"), new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05") },
                    { new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee"), new Guid("2aadd2df-7caf-45ab-9355-7f6332985a87") },
                    { new Guid("d173e20d-159e-4127-9ce9-b0ac2564ad97"), new Guid("2aadd2df-7caf-45ab-9355-7f6332985a87") },
                    { new Guid("d173e20d-159e-4127-9ce9-b0ac2564ad97"), new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05") },
                    { new Guid("40ff5488-fdab-45b5-bc3a-14302d59869a"), new Guid("2aadd2df-7caf-45ab-9355-7f6332985a87") },
                    { new Guid("40ff5488-fdab-45b5-bc3a-14302d59869a"), new Guid("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51") }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Instructors_InstructorId",
                table: "Courses",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "InstructorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Instructors_InstructorId",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instructors",
                table: "Instructors");

            migrationBuilder.DeleteData(
                table: "CourseStudents",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { new Guid("40ff5488-fdab-45b5-bc3a-14302d59869a"), new Guid("2aadd2df-7caf-45ab-9355-7f6332985a87") });

            migrationBuilder.DeleteData(
                table: "CourseStudents",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { new Guid("40ff5488-fdab-45b5-bc3a-14302d59869a"), new Guid("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51") });

            migrationBuilder.DeleteData(
                table: "CourseStudents",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"), new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05") });

            migrationBuilder.DeleteData(
                table: "CourseStudents",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { new Guid("d173e20d-159e-4127-9ce9-b0ac2564ad97"), new Guid("2aadd2df-7caf-45ab-9355-7f6332985a87") });

            migrationBuilder.DeleteData(
                table: "CourseStudents",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { new Guid("d173e20d-159e-4127-9ce9-b0ac2564ad97"), new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05") });

            migrationBuilder.DeleteData(
                table: "CourseStudents",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee"), new Guid("2aadd2df-7caf-45ab-9355-7f6332985a87") });

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: new Guid("40ff5488-fdab-45b5-bc3a-14302d59869a"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: new Guid("d173e20d-159e-4127-9ce9-b0ac2564ad97"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: new Guid("2aadd2df-7caf-45ab-9355-7f6332985a87"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: new Guid("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"));

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: new Guid("2902b665-1190-4c70-9915-b9c2d7680450"));

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"));

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"));

            migrationBuilder.DropColumn(
                name: "InstructorId",
                table: "Instructors");

            migrationBuilder.AddColumn<Guid>(
                name: "TeacherId",
                table: "Instructors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instructors",
                table: "Instructors",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Instructors_InstructorId",
                table: "Courses",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
