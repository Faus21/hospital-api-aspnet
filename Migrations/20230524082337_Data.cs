using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task9.Migrations
{
    /// <inheritdoc />
    public partial class Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2023, 6, 3, 8, 23, 37, 431, DateTimeKind.Utc).AddTicks(3559));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2023, 6, 2, 16, 19, 59, 619, DateTimeKind.Utc).AddTicks(6430));
        }
    }
}
