using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VirtualClassRoom.Migrations
{
    public partial class resources : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                column: "Password",
                value: "$2a$11$sqGQJqD3JdNDojp8gdi/qedZ5JCoTmbN24h4rhYpf44hszq11Nkga");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: new Guid("2902b665-1190-4c70-9915-b9c2d7680450"),
                column: "Password",
                value: "$2a$11$cuji4rj1/7EfIcRI4LpsneM7t/C5nbHt8ck4kxfLHgHJNm7pV4Ziq");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                column: "Password",
                value: "$2a$11$7kKkmP7V3SN7xVImf7OGheL/6ReCwqoaaTtBsEHp.9rrQtQPGz12.");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                column: "Password",
                value: "$2a$11$fLhJF7/0Og/u6mJhsWL8UeRs6C37raNwxk9j8AvfoX6iFBnUtX15G");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                column: "Password",
                value: "$2a$11$dhRtqgIIy0oNvdmQXcwJ4ucGfJgL4Vj8wsW7/Q2XeNnIIIdpMQ2v2");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: new Guid("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"),
                column: "Password",
                value: "$2a$11$TVsfOm5nFmULA44pDi.oTe1eEJzgEOdift0QB9yVLewwO5n6nrclq");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
