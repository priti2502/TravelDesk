using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelDesk.Migrations
{
    /// <inheritdoc />
    public partial class travel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 22, 14, 5, 5, 707, DateTimeKind.Local).AddTicks(7527));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 22, 14, 5, 5, 707, DateTimeKind.Local).AddTicks(7531));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 22, 14, 5, 5, 707, DateTimeKind.Local).AddTicks(7534));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 22, 14, 5, 5, 707, DateTimeKind.Local).AddTicks(7536));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 22, 14, 5, 5, 707, DateTimeKind.Local).AddTicks(7571));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 22, 14, 5, 5, 707, DateTimeKind.Local).AddTicks(7575));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 22, 14, 5, 5, 707, DateTimeKind.Local).AddTicks(7577));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 22, 14, 5, 5, 707, DateTimeKind.Local).AddTicks(7287));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 22, 14, 5, 5, 707, DateTimeKind.Local).AddTicks(7293));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 22, 14, 5, 5, 707, DateTimeKind.Local).AddTicks(7295));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 8, 22, 14, 5, 5, 707, DateTimeKind.Local).AddTicks(7297));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
