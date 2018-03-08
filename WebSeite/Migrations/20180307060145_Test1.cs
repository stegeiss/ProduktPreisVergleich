using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebSeite.Migrations
{
    public partial class Test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Produktname",
                table: "Produkt",
                newName: "ProduktName");

            migrationBuilder.AddColumn<bool>(
                name: "IstBio",
                table: "Produkt",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ProduktTyp",
                table: "Produkt",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OeffnungsZeitenDienstag",
                table: "Geschaeft",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OeffnungsZeitenDonnerstag",
                table: "Geschaeft",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OeffnungsZeitenFreitag",
                table: "Geschaeft",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OeffnungsZeitenMittwoch",
                table: "Geschaeft",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OeffnungsZeitenMontag",
                table: "Geschaeft",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OeffnungsZeitenSamstag",
                table: "Geschaeft",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OeffnungsZeitenSonntag",
                table: "Geschaeft",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IstBio",
                table: "Produkt");

            migrationBuilder.DropColumn(
                name: "ProduktTyp",
                table: "Produkt");

            migrationBuilder.DropColumn(
                name: "OeffnungsZeitenDienstag",
                table: "Geschaeft");

            migrationBuilder.DropColumn(
                name: "OeffnungsZeitenDonnerstag",
                table: "Geschaeft");

            migrationBuilder.DropColumn(
                name: "OeffnungsZeitenFreitag",
                table: "Geschaeft");

            migrationBuilder.DropColumn(
                name: "OeffnungsZeitenMittwoch",
                table: "Geschaeft");

            migrationBuilder.DropColumn(
                name: "OeffnungsZeitenMontag",
                table: "Geschaeft");

            migrationBuilder.DropColumn(
                name: "OeffnungsZeitenSamstag",
                table: "Geschaeft");

            migrationBuilder.DropColumn(
                name: "OeffnungsZeitenSonntag",
                table: "Geschaeft");

            migrationBuilder.RenameColumn(
                name: "ProduktName",
                table: "Produkt",
                newName: "Produktname");
        }
    }
}
