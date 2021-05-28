using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VirtualClassRoom.Migrations
{
    public partial class add_bcrybt_in_dummy_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                column: "Password",
                value: "$2a$11$0Z6CHJ7TuAvbW5cfRcAkBuEAlTxQLmY/SfoM2nnFrdxYwGHphopyu");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: new Guid("2902b665-1190-4c70-9915-b9c2d7680450"),
                column: "Password",
                value: "$2a$11$3qbMr4pcP7n54CK0q/v/1uYApGRmUfI1YsS75gJlJxHeAEdsnIyje");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                column: "Password",
                value: "$2a$11$loG9VSlNT6D2Jv2Ffqufr.ZUnost6uy64A5ffAGgp3NbtGCQxylOm");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                column: "Password",
                value: "$2a$11$B.U8fdroALQ8JdzVzvlsheWfHuAqzq0mWwdvnZqtidTPZaQkMTjAC");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                column: "Password",
                value: "$2a$11$H8p/I6UZAIdFtsaHaZyWJu5.O/2d6gddq0X.xxYkwJRVtDn8bYmp.");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: new Guid("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"),
                column: "Password",
                value: "$2a$11$807RpOs.9NpF9j9BW3ngpuZL5w6QHs4BvA4NXej23f64r3rrGzNUO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                column: "Password",
                value: "12345678");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: new Guid("2902b665-1190-4c70-9915-b9c2d7680450"),
                column: "Password",
                value: "12345678");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                column: "Password",
                value: "12345678");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                column: "Password",
                value: "12345678");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                column: "Password",
                value: "12345678");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: new Guid("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"),
                column: "Password",
                value: "12345678");
        }
    }
}
