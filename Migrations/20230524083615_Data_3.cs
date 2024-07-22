using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task9.Migrations
{
    /// <inheritdoc />
    public partial class Data_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Medicament_Prescription",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "Medicament_Prescription",
                columns: new[] { "IdMedicament", "IdPrescription", "Decscription", "Dose" },
                values: new object[] { 2, 2, "Desc_2", 3 });

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2023, 6, 3, 8, 36, 15, 788, DateTimeKind.Utc).AddTicks(5629));

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 2,
                column: "DueDate",
                value: new DateTime(2023, 6, 3, 8, 36, 15, 788, DateTimeKind.Utc).AddTicks(5636));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Medicament_Prescription",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "Medicament_Prescription",
                columns: new[] { "IdMedicament", "IdPrescription", "Decscription", "Dose" },
                values: new object[] { 2, 1, "Desc_2", 3 });

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2023, 6, 3, 8, 34, 42, 131, DateTimeKind.Utc).AddTicks(6671));

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 2,
                column: "DueDate",
                value: new DateTime(2023, 6, 3, 8, 34, 42, 131, DateTimeKind.Utc).AddTicks(6678));
        }
    }
}
