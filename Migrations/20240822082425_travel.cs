using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelDesk.Migrations
{
    /// <inheritdoc />
    public partial class travel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 22, 13, 54, 25, 190, DateTimeKind.Local).AddTicks(2995));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 22, 13, 54, 25, 190, DateTimeKind.Local).AddTicks(2997));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 22, 13, 54, 25, 190, DateTimeKind.Local).AddTicks(2999));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 22, 13, 54, 25, 190, DateTimeKind.Local).AddTicks(3000));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 22, 13, 54, 25, 190, DateTimeKind.Local).AddTicks(3059));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 22, 13, 54, 25, 190, DateTimeKind.Local).AddTicks(3062));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 22, 13, 54, 25, 190, DateTimeKind.Local).AddTicks(3064));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 22, 13, 54, 25, 190, DateTimeKind.Local).AddTicks(2828));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 22, 13, 54, 25, 190, DateTimeKind.Local).AddTicks(2831));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 22, 13, 54, 25, 190, DateTimeKind.Local).AddTicks(2833));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 22, 13, 54, 25, 190, DateTimeKind.Local).AddTicks(2834));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 22, 13, 13, 7, 976, DateTimeKind.Local).AddTicks(100));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 22, 13, 13, 7, 976, DateTimeKind.Local).AddTicks(102));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 22, 13, 13, 7, 976, DateTimeKind.Local).AddTicks(104));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 22, 13, 13, 7, 976, DateTimeKind.Local).AddTicks(106));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 22, 13, 13, 7, 976, DateTimeKind.Local).AddTicks(127));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 22, 13, 13, 7, 976, DateTimeKind.Local).AddTicks(129));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 22, 13, 13, 7, 976, DateTimeKind.Local).AddTicks(131));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 22, 13, 13, 7, 975, DateTimeKind.Local).AddTicks(9979));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 22, 13, 13, 7, 975, DateTimeKind.Local).AddTicks(9983));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 22, 13, 13, 7, 975, DateTimeKind.Local).AddTicks(9985));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 22, 13, 13, 7, 975, DateTimeKind.Local).AddTicks(9987));
        }
    }
}
