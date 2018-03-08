using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebSeite.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Preis_Hersteller_AnschriftHerstellerID",
                table: "Preis");

            migrationBuilder.DropColumn(
                name: "IstBio",
                table: "Produkt");

            migrationBuilder.RenameColumn(
                name: "AnschriftHerstellerID",
                table: "Preis",
                newName: "AnschriftGeschaeftID");

            migrationBuilder.RenameIndex(
                name: "IX_Preis_AnschriftHerstellerID",
                table: "Preis",
                newName: "IX_Preis_AnschriftGeschaeftID");

            migrationBuilder.AddForeignKey(
                name: "FK_Preis_Geschaeft_AnschriftGeschaeftID",
                table: "Preis",
                column: "AnschriftGeschaeftID",
                principalTable: "Geschaeft",
                principalColumn: "AnschriftGeschaeftID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Preis_Geschaeft_AnschriftGeschaeftID",
                table: "Preis");

            migrationBuilder.RenameColumn(
                name: "AnschriftGeschaeftID",
                table: "Preis",
                newName: "AnschriftHerstellerID");

            migrationBuilder.RenameIndex(
                name: "IX_Preis_AnschriftGeschaeftID",
                table: "Preis",
                newName: "IX_Preis_AnschriftHerstellerID");

            migrationBuilder.AddColumn<bool>(
                name: "IstBio",
                table: "Produkt",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Preis_Hersteller_AnschriftHerstellerID",
                table: "Preis",
                column: "AnschriftHerstellerID",
                principalTable: "Hersteller",
                principalColumn: "AnschriftHerstellerID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
