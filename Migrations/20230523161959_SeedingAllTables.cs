using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Task9.Migrations
{
    /// <inheritdoc />
    public partial class SeedingAllTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdDoctor",
                table: "Prescription",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdPatient",
                table: "Prescription",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    IdDoctor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Doctor_pk", x => x.IdDoctor);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    IdPatient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("Patient_pk", x => x.IdPatient);
                });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[] { 1, "1234@gmail.com", "Mykyta", "Ushakov" });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "IdPatient", "FirstName", "LastName" },
                values: new object[] { 1, "Andrii", "Korovai" });

            migrationBuilder.InsertData(
                table: "Prescription",
                columns: new[] { "IdPrescription", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[] { 1, new DateTime(2023, 6, 2, 16, 19, 59, 619, DateTimeKind.Utc).AddTicks(6430), 1, 1 });

            migrationBuilder.InsertData(
                table: "Medicament_Prescription",
                columns: new[] { "IdMedicament", "IdPrescription", "Decscription", "Dose" },
                values: new object[,]
                {
                    { 1, 1, "Desc_1", 10 },
                    { 2, 1, "Desc_2", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_IdDoctor",
                table: "Prescription",
                column: "IdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_IdPatient",
                table: "Prescription",
                column: "IdPatient");

            migrationBuilder.AddForeignKey(
                name: "Prescription_Doctor",
                table: "Prescription",
                column: "IdDoctor",
                principalTable: "Doctor",
                principalColumn: "IdDoctor",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "Prescription_Patient",
                table: "Prescription",
                column: "IdPatient",
                principalTable: "Patient",
                principalColumn: "IdPatient",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Prescription_Doctor",
                table: "Prescription");

            migrationBuilder.DropForeignKey(
                name: "Prescription_Patient",
                table: "Prescription");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropIndex(
                name: "IX_Prescription_IdDoctor",
                table: "Prescription");

            migrationBuilder.DropIndex(
                name: "IX_Prescription_IdPatient",
                table: "Prescription");

            migrationBuilder.DeleteData(
                table: "Medicament_Prescription",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Medicament_Prescription",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "IdDoctor",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "IdPatient",
                table: "Prescription");
        }
    }
}
