using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task9.Migrations
{
    /// <inheritdoc />
    public partial class Data_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2023, 6, 3, 8, 34, 42, 131, DateTimeKind.Utc).AddTicks(6671));

            migrationBuilder.InsertData(
                table: "Prescription",
                columns: new[] { "IdPrescription", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[] { 2, new DateTime(2023, 6, 3, 8, 34, 42, 131, DateTimeKind.Utc).AddTicks(6678), 3, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2023, 6, 3, 8, 27, 7, 749, DateTimeKind.Utc).AddTicks(5084));
        }
    }
}
