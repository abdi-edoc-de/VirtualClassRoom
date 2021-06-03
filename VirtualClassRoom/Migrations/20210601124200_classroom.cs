using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VirtualClassRoom.Migrations
{
    public partial class classroom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "ClassRooms",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "EndTime",
                table: "ClassRooms",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "StartTime",
                table: "ClassRooms",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                column: "Password",
                value: "$2a$11$bRbr9l84KKqnrd4m6ZjBV.YGEoL95zjhbBfY0QVWW8/6WCevVTLh6");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: new Guid("2902b665-1190-4c70-9915-b9c2d7680450"),
                column: "Password",
                value: "$2a$11$70jCllPZ5QkjqZBfOO.5ee8WUYsO0AisBclC3t87OoufOAzm6ZW96");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                column: "Password",
                value: "$2a$11$VFHL6K63UG3HVrwqZ/Vcs.sxa4bltXnwBNjKqiXuzAppErLplnk/y");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                column: "Password",
                value: "$2a$11$/QdVtUAKSPxpQ16N99G4Auu0DPkJuDqnVWMaLvpBSpEl..Sk4PivG");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                column: "Password",
                value: "$2a$11$.kkvx941mM6bd73LiiaOOeX6D879oDnmu54XDG5lFM2.fDCb15R9y");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: new Guid("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"),
                column: "Password",
                value: "$2a$11$q4GMN9lmtiVvy60nE9MLEeiqGdv12xFiz6qB4WntU8CbykZWswIK2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "ClassRooms");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "ClassRooms");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "ClassRooms");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                column: "Password",
                value: "$2a$11$23fC4ov59E2VQPTSoymiNuLXcy1xROsz1at3S9tQTmX8RrzVJeCFe");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: new Guid("2902b665-1190-4c70-9915-b9c2d7680450"),
                column: "Password",
                value: "$2a$11$Eyq2MFC1y1EBn3wljGhUyuXY8egTdAQ17oU7xiv6Gu/fMqo3/LpyO");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                column: "Password",
                value: "$2a$11$OUqdJpdUQLTsnV6JsIP3YOZpqpT6S.pZapbz758y6bourvkIf4hyW");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                column: "Password",
                value: "$2a$11$nEezOO1Iw90eT.nvu6UTdObU9qVk1hKFa2Um8zkEZMUxjhGjscyNW");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                column: "Password",
                value: "$2a$11$IL2ALUwcDbkuR4Gw6b/UG.KDG9XJLeewbdTkFePDv4BbmmSivVTmy");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: new Guid("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"),
                column: "Password",
                value: "$2a$11$ACnhGAR6GWGhgFL9h0dEjeYXuMDuSHZzxCtSoLUoeQ8AtxpsppC.O");
        }
    }
}
