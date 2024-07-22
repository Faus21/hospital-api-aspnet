using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task9.Migrations
{
    /// <inheritdoc />
    public partial class Data_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2023, 6, 3, 8, 27, 7, 749, DateTimeKind.Utc).AddTicks(5084));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2023, 6, 3, 8, 23, 37, 431, DateTimeKind.Utc).AddTicks(3559));
        }
    }
}
