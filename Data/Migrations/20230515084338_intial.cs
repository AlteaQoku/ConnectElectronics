using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConnectElectronics.Data.Migrations
{
    public partial class intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategorit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pershkrimi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Markat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Shteti = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Markat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Porosit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KlientId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KlientUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Emri = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Mbiemri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Qyteti = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumerKontakti = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataPorosis = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Shenime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShumaT = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Porosit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produkte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cmimi = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Sasia = table.Column<int>(type: "int", nullable: true),
                    Oferte = table.Column<bool>(type: "bit", nullable: true),
                    Pershkrimi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KategoriID = table.Column<int>(type: "int", nullable: false),
                    MarkaID = table.Column<int>(type: "int", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkte", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produkte_Kategorit_KategoriID",
                        column: x => x.KategoriID,
                        principalTable: "Kategorit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produkte_Markat_MarkaID",
                        column: x => x.MarkaID,
                        principalTable: "Markat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Porosi_Detajet",
                columns: table => new
                {
                    ProduktId = table.Column<int>(type: "int", nullable: false),
                    PorosiId = table.Column<int>(type: "int", nullable: false),
                    Pr_Sasia = table.Column<int>(type: "int", nullable: true),
                    ShumaProdukt = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Porosi_Detajet", x => new { x.PorosiId, x.ProduktId });
                    table.ForeignKey(
                        name: "FK_Porosi_Detajet_Porosit_PorosiId",
                        column: x => x.PorosiId,
                        principalTable: "Porosit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Porosi_Detajet_Produkte_ProduktId",
                        column: x => x.ProduktId,
                        principalTable: "Produkte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Porosi_Detajet_ProduktId",
                table: "Porosi_Detajet",
                column: "ProduktId");

            migrationBuilder.CreateIndex(
                name: "IX_Produkte_KategoriID",
                table: "Produkte",
                column: "KategoriID");

            migrationBuilder.CreateIndex(
                name: "IX_Produkte_MarkaID",
                table: "Produkte",
                column: "MarkaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Porosi_Detajet");

            migrationBuilder.DropTable(
                name: "Porosit");

            migrationBuilder.DropTable(
                name: "Produkte");

            migrationBuilder.DropTable(
                name: "Kategorit");

            migrationBuilder.DropTable(
                name: "Markat");
        }
    }
}
