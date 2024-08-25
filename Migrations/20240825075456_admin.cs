using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelDesk.Migrations
{
    /// <inheritdoc />
    public partial class admin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 25, 13, 24, 55, 837, DateTimeKind.Local).AddTicks(1823));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 25, 13, 24, 55, 837, DateTimeKind.Local).AddTicks(1825));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 25, 13, 24, 55, 837, DateTimeKind.Local).AddTicks(1827));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 25, 13, 24, 55, 837, DateTimeKind.Local).AddTicks(1828));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 25, 13, 24, 55, 837, DateTimeKind.Local).AddTicks(1846));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 25, 13, 24, 55, 837, DateTimeKind.Local).AddTicks(1849));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 25, 13, 24, 55, 837, DateTimeKind.Local).AddTicks(1850));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 25, 13, 24, 55, 837, DateTimeKind.Local).AddTicks(1702));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 25, 13, 24, 55, 837, DateTimeKind.Local).AddTicks(1704));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 25, 13, 24, 55, 837, DateTimeKind.Local).AddTicks(1706));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 25, 13, 24, 55, 837, DateTimeKind.Local).AddTicks(1707));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
