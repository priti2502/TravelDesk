using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelDesk.Migrations
{
    /// <inheritdoc />
    public partial class traveladmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 25, 13, 21, 4, 664, DateTimeKind.Local).AddTicks(8911));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 25, 13, 21, 4, 664, DateTimeKind.Local).AddTicks(8914));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 25, 13, 21, 4, 664, DateTimeKind.Local).AddTicks(8916));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 25, 13, 21, 4, 664, DateTimeKind.Local).AddTicks(8918));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 25, 13, 21, 4, 664, DateTimeKind.Local).AddTicks(8950));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 25, 13, 21, 4, 664, DateTimeKind.Local).AddTicks(8954));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 25, 13, 21, 4, 664, DateTimeKind.Local).AddTicks(8956));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 25, 13, 21, 4, 664, DateTimeKind.Local).AddTicks(8675));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 25, 13, 21, 4, 664, DateTimeKind.Local).AddTicks(8679));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 25, 13, 21, 4, 664, DateTimeKind.Local).AddTicks(8680));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 25, 13, 21, 4, 664, DateTimeKind.Local).AddTicks(8682));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 25, 13, 20, 3, 29, DateTimeKind.Local).AddTicks(8498));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 25, 13, 20, 3, 29, DateTimeKind.Local).AddTicks(8502));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 25, 13, 20, 3, 29, DateTimeKind.Local).AddTicks(8504));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 25, 13, 20, 3, 29, DateTimeKind.Local).AddTicks(8506));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 25, 13, 20, 3, 29, DateTimeKind.Local).AddTicks(8539));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 25, 13, 20, 3, 29, DateTimeKind.Local).AddTicks(8543));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 25, 13, 20, 3, 29, DateTimeKind.Local).AddTicks(8546));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 25, 13, 20, 3, 29, DateTimeKind.Local).AddTicks(8299));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 25, 13, 20, 3, 29, DateTimeKind.Local).AddTicks(8303));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 25, 13, 20, 3, 29, DateTimeKind.Local).AddTicks(8305));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 25, 13, 20, 3, 29, DateTimeKind.Local).AddTicks(8307));
        }
    }
}
