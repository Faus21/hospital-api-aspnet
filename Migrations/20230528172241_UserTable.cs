using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task9.Migrations
{
    /// <inheritdoc />
    public partial class UserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("User_pk", x => x.IdUser);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

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
    }
}
