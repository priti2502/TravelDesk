using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelDesk.Migrations
{
    /// <inheritdoc />
    public partial class updateerkj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 4, 16, 29, 31, 98, DateTimeKind.Local).AddTicks(2562));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 4, 16, 29, 31, 98, DateTimeKind.Local).AddTicks(2565));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 4, 16, 29, 31, 98, DateTimeKind.Local).AddTicks(2567));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 4, 16, 29, 31, 98, DateTimeKind.Local).AddTicks(2570));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 4, 16, 29, 31, 98, DateTimeKind.Local).AddTicks(2600));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 4, 16, 29, 31, 98, DateTimeKind.Local).AddTicks(2602));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 4, 16, 29, 31, 98, DateTimeKind.Local).AddTicks(2604));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 4, 16, 29, 31, 98, DateTimeKind.Local).AddTicks(2339));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 4, 16, 29, 31, 98, DateTimeKind.Local).AddTicks(2343));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 4, 16, 29, 31, 98, DateTimeKind.Local).AddTicks(2345));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 4, 16, 29, 31, 98, DateTimeKind.Local).AddTicks(2347));
        }
    }
}
