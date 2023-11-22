using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace facturi_backend.Migrations
{
    /// <inheritdoc />
    public partial class InitializareDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Facturi",
                columns: table => new
                {
                    IdFactura = table.Column<int>(type: "int", nullable: false),
                    IdLocatie = table.Column<int>(type: "int", nullable: false),
                    NumarFactura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataFacturare = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NumeClient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturi", x => new { x.IdFactura, x.IdLocatie });
                });

            migrationBuilder.CreateTable(
                name: "DetaliiFacturi",
                columns: table => new
                {
                    IdDetaliiFactura = table.Column<int>(type: "int", nullable: false),
                    IdLocatie = table.Column<int>(type: "int", nullable: false),
                    IdFactura = table.Column<int>(type: "int", nullable: false),
                    NumeProdus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cantitate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PretUnitar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Valoare = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetaliiFacturi", x => new { x.IdDetaliiFactura, x.IdLocatie });
                    table.ForeignKey(
                        name: "FK_DetaliiFacturi_Facturi_IdFactura_IdLocatie",
                        columns: x => new { x.IdFactura, x.IdLocatie },
                        principalTable: "Facturi",
                        principalColumns: new[] { "IdFactura", "IdLocatie" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetaliiFacturi_IdFactura_IdLocatie",
                table: "DetaliiFacturi",
                columns: new[] { "IdFactura", "IdLocatie" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetaliiFacturi");

            migrationBuilder.DropTable(
                name: "Facturi");
        }
    }
}
