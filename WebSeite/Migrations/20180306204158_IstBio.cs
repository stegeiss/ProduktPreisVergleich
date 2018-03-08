using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebSeite.Migrations
{
    public partial class IstBio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Geschaeft",
                columns: table => new
                {
                    AnschriftGeschaeftID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    Handy = table.Column<string>(nullable: true),
                    Hausnummer = table.Column<string>(nullable: true),
                    Homepage = table.Column<string>(nullable: true),
                    Kundennummer = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Ort = table.Column<string>(nullable: true),
                    PLZ = table.Column<int>(nullable: true),
                    Strasse = table.Column<string>(nullable: true),
                    Telefonnummer = table.Column<string>(nullable: true),
                    Zusatz = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Geschaeft", x => x.AnschriftGeschaeftID);
                });

            migrationBuilder.CreateTable(
                name: "Hersteller",
                columns: table => new
                {
                    AnschriftHerstellerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    Handy = table.Column<string>(nullable: true),
                    Hausnummer = table.Column<string>(nullable: true),
                    Homepage = table.Column<string>(nullable: true),
                    Kundennummer = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Ort = table.Column<string>(nullable: true),
                    PLZ = table.Column<int>(nullable: true),
                    Strasse = table.Column<string>(nullable: true),
                    Telefonnummer = table.Column<string>(nullable: true),
                    Zusatz = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hersteller", x => x.AnschriftHerstellerID);
                });

            migrationBuilder.CreateTable(
                name: "Kategorie",
                columns: table => new
                {
                    ProduktKategorieId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorie", x => x.ProduktKategorieId);
                });

            migrationBuilder.CreateTable(
                name: "Produkt",
                columns: table => new
                {
                    ProduktId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnschriftHerstellerID = table.Column<int>(nullable: false),
                    Inhalt = table.Column<string>(nullable: true),
                    InhaltMesseinheit = table.Column<int>(nullable: false),
                    IstBio = table.Column<bool>(nullable: false),
                    ProduktKategorieId = table.Column<string>(nullable: true),
                    ProduktKategorieId1 = table.Column<int>(nullable: true),
                    Produktcode = table.Column<string>(nullable: true),
                    Produktname = table.Column<string>(nullable: true),
                    Zusatztext = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkt", x => x.ProduktId);
                    table.ForeignKey(
                        name: "FK_Produkt_Hersteller_AnschriftHerstellerID",
                        column: x => x.AnschriftHerstellerID,
                        principalTable: "Hersteller",
                        principalColumn: "AnschriftHerstellerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produkt_Kategorie_ProduktKategorieId1",
                        column: x => x.ProduktKategorieId1,
                        principalTable: "Kategorie",
                        principalColumn: "ProduktKategorieId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Preis",
                columns: table => new
                {
                    PreisId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnschriftHerstellerID = table.Column<int>(nullable: false),
                    Kosten = table.Column<double>(nullable: false),
                    PreisDatum = table.Column<string>(nullable: true),
                    ProduktId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preis", x => x.PreisId);
                    table.ForeignKey(
                        name: "FK_Preis_Hersteller_AnschriftHerstellerID",
                        column: x => x.AnschriftHerstellerID,
                        principalTable: "Hersteller",
                        principalColumn: "AnschriftHerstellerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Preis_Produkt_ProduktId",
                        column: x => x.ProduktId,
                        principalTable: "Produkt",
                        principalColumn: "ProduktId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Preis_AnschriftHerstellerID",
                table: "Preis",
                column: "AnschriftHerstellerID");

            migrationBuilder.CreateIndex(
                name: "IX_Preis_ProduktId",
                table: "Preis",
                column: "ProduktId");

            migrationBuilder.CreateIndex(
                name: "IX_Produkt_AnschriftHerstellerID",
                table: "Produkt",
                column: "AnschriftHerstellerID");

            migrationBuilder.CreateIndex(
                name: "IX_Produkt_ProduktKategorieId1",
                table: "Produkt",
                column: "ProduktKategorieId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Geschaeft");

            migrationBuilder.DropTable(
                name: "Preis");

            migrationBuilder.DropTable(
                name: "Produkt");

            migrationBuilder.DropTable(
                name: "Hersteller");

            migrationBuilder.DropTable(
                name: "Kategorie");
        }
    }
}
