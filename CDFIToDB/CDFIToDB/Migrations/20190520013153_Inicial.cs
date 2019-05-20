using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CDFIToDB.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CDFIs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AntiguedadNomina = table.Column<string>(nullable: true),
                    CURPNomina = table.Column<string>(nullable: true),
                    CantidadConceptos = table.Column<string>(nullable: true),
                    CertificadoComprobante = table.Column<string>(nullable: true),
                    ClavePercepciones = table.Column<string>(nullable: true),
                    ConceptoPercepciones = table.Column<string>(nullable: true),
                    DepartamentoNomina = table.Column<string>(nullable: true),
                    DescripcionConceptos = table.Column<string>(nullable: true),
                    DescuentoComprobante = table.Column<string>(nullable: true),
                    FechaComprobante = table.Column<string>(nullable: true),
                    FechaFinalPagoNomina = table.Column<string>(nullable: true),
                    FechaInicialPagoNomina = table.Column<string>(nullable: true),
                    FechaInicioRealLaboralNomina = table.Column<string>(nullable: true),
                    FechaPagoNomina = table.Column<string>(nullable: true),
                    FolioComprobante = table.Column<string>(nullable: true),
                    FormaDePagoComprobante = table.Column<string>(nullable: true),
                    ImporteConceptos = table.Column<string>(nullable: true),
                    ImporteExentoPercepciones = table.Column<string>(nullable: true),
                    ImporteGravadoPercepciones = table.Column<string>(nullable: true),
                    ImporteRetecionesImpuestos = table.Column<string>(nullable: true),
                    ImpuestoRetencionesImpuestos = table.Column<string>(nullable: true),
                    LugarExpedicionComprobante = table.Column<string>(nullable: true),
                    MetodoDePagoComprobante = table.Column<string>(nullable: true),
                    MotivoDescuentoComprobante = table.Column<string>(nullable: true),
                    NoCertificadoComprobante = table.Column<string>(nullable: true),
                    NombreEmisor = table.Column<string>(nullable: true),
                    NombreReceptor = table.Column<string>(nullable: true),
                    NumDiasPagadosNomina = table.Column<string>(nullable: true),
                    NumEmpleadoNomina = table.Column<string>(nullable: true),
                    NumSeguroSocialNomina = table.Column<string>(nullable: true),
                    PeriodicidadPagoNomina = table.Column<string>(nullable: true),
                    PuestoNomina = table.Column<string>(nullable: true),
                    RFCEmisor = table.Column<string>(nullable: true),
                    RFCReceptor = table.Column<string>(nullable: true),
                    RegimenEmisor = table.Column<string>(nullable: true),
                    RegistroPatronalNomina = table.Column<string>(nullable: true),
                    RiesgoPuestoNomina = table.Column<string>(nullable: true),
                    SalarioBaseCotAporNomina = table.Column<string>(nullable: true),
                    SalarioDiarioIntegradoNomina = table.Column<string>(nullable: true),
                    SelloComprobante = table.Column<string>(nullable: true),
                    SerieComprobante = table.Column<string>(nullable: true),
                    SubtotalComprobante = table.Column<string>(nullable: true),
                    TipoContratoNomina = table.Column<string>(nullable: true),
                    TipoDeComprobante = table.Column<string>(nullable: true),
                    TipoJornadaNomina = table.Column<string>(nullable: true),
                    TipoPercepcion = table.Column<string>(nullable: true),
                    TipoRegimenNomina = table.Column<string>(nullable: true),
                    TotalComprobante = table.Column<string>(nullable: true),
                    TotalExentoPercepciones = table.Column<string>(nullable: true),
                    TotalGravadoPercepciones = table.Column<string>(nullable: true),
                    TotalImpuestosReteneidos = table.Column<string>(nullable: true),
                    TotalImpuestosTrasladados = table.Column<string>(nullable: true),
                    UUID = table.Column<string>(nullable: true),
                    UnidadConceptos = table.Column<string>(nullable: true),
                    ValorUnitarioConceptos = table.Column<string>(nullable: true),
                    VersionComprobante = table.Column<string>(nullable: true),
                    VersionNomina = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CDFIs", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CDFIs");
        }
    }
}
