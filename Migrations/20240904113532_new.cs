using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelDesk.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 4, 17, 5, 32, 33, DateTimeKind.Local).AddTicks(3558));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 4, 17, 5, 32, 33, DateTimeKind.Local).AddTicks(3562));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 4, 17, 5, 32, 33, DateTimeKind.Local).AddTicks(3564));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 4, 17, 5, 32, 33, DateTimeKind.Local).AddTicks(3566));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 4, 17, 5, 32, 33, DateTimeKind.Local).AddTicks(3597));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 4, 17, 5, 32, 33, DateTimeKind.Local).AddTicks(3602));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 4, 17, 5, 32, 33, DateTimeKind.Local).AddTicks(3604));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 4, 17, 5, 32, 33, DateTimeKind.Local).AddTicks(3393));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 4, 17, 5, 32, 33, DateTimeKind.Local).AddTicks(3396));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 4, 17, 5, 32, 33, DateTimeKind.Local).AddTicks(3399));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 4, 17, 5, 32, 33, DateTimeKind.Local).AddTicks(3401));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 4, 16, 39, 4, 802, DateTimeKind.Local).AddTicks(5965));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 4, 16, 39, 4, 802, DateTimeKind.Local).AddTicks(5968));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 4, 16, 39, 4, 802, DateTimeKind.Local).AddTicks(5969));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 4, 16, 39, 4, 802, DateTimeKind.Local).AddTicks(5971));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 4, 16, 39, 4, 802, DateTimeKind.Local).AddTicks(5994));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 4, 16, 39, 4, 802, DateTimeKind.Local).AddTicks(5997));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 4, 16, 39, 4, 802, DateTimeKind.Local).AddTicks(5999));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 4, 16, 39, 4, 802, DateTimeKind.Local).AddTicks(5796));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 4, 16, 39, 4, 802, DateTimeKind.Local).AddTicks(5800));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 4, 16, 39, 4, 802, DateTimeKind.Local).AddTicks(5801));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 4, 16, 39, 4, 802, DateTimeKind.Local).AddTicks(5803));
        }
    }
}
