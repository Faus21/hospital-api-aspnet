using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task9.Migrations
{
    /// <inheritdoc />
    public partial class newUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ExpirationDate",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2023, 6, 7, 20, 30, 49, 718, DateTimeKind.Utc).AddTicks(4454));

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 2,
                column: "DueDate",
                value: new DateTime(2023, 6, 7, 20, 30, 49, 718, DateTimeKind.Utc).AddTicks(4461));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "User");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "User");

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2023, 6, 7, 17, 22, 40, 921, DateTimeKind.Utc).AddTicks(5505));

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 2,
                column: "DueDate",
                value: new DateTime(2023, 6, 7, 17, 22, 40, 921, DateTimeKind.Utc).AddTicks(5519));
        }
    }
}
