using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CDFIToDB.Migrations
{
    public partial class PercepcionAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClavePercepciones",
                table: "CDFIs");

            migrationBuilder.DropColumn(
                name: "ConceptoPercepciones",
                table: "CDFIs");

            migrationBuilder.DropColumn(
                name: "ImporteExentoPercepciones",
                table: "CDFIs");

            migrationBuilder.DropColumn(
                name: "ImporteGravadoPercepciones",
                table: "CDFIs");

            migrationBuilder.DropColumn(
                name: "TipoPercepcion",
                table: "CDFIs");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "CDFIs",
                newName: "CFDIID");

            migrationBuilder.CreateTable(
                name: "Percepciones",
                columns: table => new
                {
                    PercepcionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CFDIID = table.Column<int>(nullable: false),
                    ClavePercepciones = table.Column<string>(nullable: true),
                    ConceptoPercepciones = table.Column<string>(nullable: true),
                    ImporteExentoPercepciones = table.Column<string>(nullable: true),
                    ImporteGravadoPercepciones = table.Column<string>(nullable: true),
                    TipoPercepcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Percepciones", x => x.PercepcionID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Percepciones");

            migrationBuilder.RenameColumn(
                name: "CFDIID",
                table: "CDFIs",
                newName: "ID");

            migrationBuilder.AddColumn<string>(
                name: "ClavePercepciones",
                table: "CDFIs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConceptoPercepciones",
                table: "CDFIs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImporteExentoPercepciones",
                table: "CDFIs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImporteGravadoPercepciones",
                table: "CDFIs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoPercepcion",
                table: "CDFIs",
                nullable: true);
        }
    }
}
