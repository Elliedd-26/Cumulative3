using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySchoolAPI.Migrations
{
    /// <inheritdoc />
    public partial class FixTeacherModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Subject",
                table: "Teachers",
                newName: "TeacherLname");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Teachers",
                newName: "TeacherFname");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Teachers",
                newName: "TeacherId");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeNumber",
                table: "Teachers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "HireDate",
                table: "Teachers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "Teachers",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeNumber",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "HireDate",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Teachers");

            migrationBuilder.RenameColumn(
                name: "TeacherLname",
                table: "Teachers",
                newName: "Subject");

            migrationBuilder.RenameColumn(
                name: "TeacherFname",
                table: "Teachers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Teachers",
                newName: "Id");
        }
    }
}
