using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDFIToDB.Models
{
    public class EFCDFIrepository : ICDFIRepository
    {
        private ApplicationDbContext context;

        public EFCDFIrepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<CDFI> CDFIs => context.CDFIs;

        public void SaveCDFI(CDFI cDFI)
        {
            if (cDFI.ID == 0)
            {
                context.CDFIs.Add(cDFI);
            }
            else
            {
                CDFI dbEntry = context.CDFIs
                .FirstOrDefault(p => p.ID == cDFI.ID);
                if (dbEntry != null)
                {
                    dbEntry.ID = cDFI.ID;
                    dbEntry.LugarExpedicionComprobante = cDFI.LugarExpedicionComprobante;
                    dbEntry.MetodoDePagoComprobante = cDFI.MetodoDePagoComprobante;
                    dbEntry.TipoDeComprobante = cDFI.TipoDeComprobante;
                    dbEntry.MotivoDescuentoComprobante = cDFI.MotivoDescuentoComprobante;
                    dbEntry.DescuentoComprobante = cDFI.DescuentoComprobante;
                    dbEntry.TotalComprobante = cDFI.TotalComprobante;
                    dbEntry.SubtotalComprobante = cDFI.SubtotalComprobante;
                    dbEntry.CertificadoComprobante = cDFI.CertificadoComprobante;
                    dbEntry.NoCertificadoComprobante = cDFI.NoCertificadoComprobante;
                    dbEntry.SelloComprobante = cDFI.SelloComprobante;
                    dbEntry.FechaComprobante = cDFI.FechaComprobante;
                    dbEntry.FormaDePagoComprobante = cDFI.FormaDePagoComprobante;
                    dbEntry.FolioComprobante = cDFI.FolioComprobante;
                    dbEntry.SerieComprobante = cDFI.SerieComprobante;
                    dbEntry.VersionComprobante = cDFI.VersionComprobante;

                    dbEntry.NombreEmisor = cDFI.NombreEmisor;
                    dbEntry.RFCEmisor = cDFI.RFCEmisor;
                    dbEntry.RegimenEmisor = cDFI.RegimenEmisor;
                    dbEntry.NombreReceptor = cDFI.NombreReceptor;
                    dbEntry.RFCReceptor = cDFI.RFCReceptor;

                    dbEntry.ImporteConceptos = cDFI.ImporteConceptos;
                    dbEntry.ValorUnitarioConceptos = cDFI.ValorUnitarioConceptos;
                    dbEntry.DescripcionConceptos = cDFI.DescripcionConceptos;
                    dbEntry.UnidadConceptos = cDFI.UnidadConceptos;
                    dbEntry.CantidadConceptos = cDFI.CantidadConceptos;

                    dbEntry.TotalImpuestosReteneidos = cDFI.TotalImpuestosReteneidos;
                    dbEntry.TotalImpuestosTrasladados = cDFI.TotalImpuestosTrasladados;
                    dbEntry.ImporteRetecionesImpuestos = cDFI.ImporteRetecionesImpuestos;
                    dbEntry.ImporteRetecionesImpuestos = cDFI.ImporteRetecionesImpuestos;

                    dbEntry.SalarioDiarioIntegradoNomina = cDFI.SalarioDiarioIntegradoNomina;
                    dbEntry.RiesgoPuestoNomina = cDFI.RiesgoPuestoNomina;
                    dbEntry.SalarioBaseCotAporNomina = cDFI.SalarioBaseCotAporNomina;
                    dbEntry.PeriodicidadPagoNomina = cDFI.PeriodicidadPagoNomina;
                    dbEntry.TipoJornadaNomina = cDFI.TipoJornadaNomina;
                    dbEntry.TipoContratoNomina = cDFI.TipoContratoNomina;
                    dbEntry.PuestoNomina = cDFI.PuestoNomina;
                    dbEntry.AntiguedadNomina = cDFI.AntiguedadNomina;
                    dbEntry.FechaInicioRealLaboralNomina = cDFI.FechaInicioRealLaboralNomina;
                    dbEntry.DepartamentoNomina = cDFI.DepartamentoNomina;
                    dbEntry.NumDiasPagadosNomina = cDFI.NumDiasPagadosNomina;
                    dbEntry.FechaFinalPagoNomina = cDFI.FechaFinalPagoNomina;
                    dbEntry.FechaInicialPagoNomina = cDFI.FechaInicialPagoNomina;
                    dbEntry.FechaPagoNomina = cDFI.FechaPagoNomina;
                    dbEntry.NumSeguroSocialNomina = cDFI.NumSeguroSocialNomina;
                    dbEntry.TipoRegimenNomina = cDFI.TipoRegimenNomina;
                    dbEntry.CURPNomina = cDFI.CURPNomina;
                    dbEntry.NumEmpleadoNomina = cDFI.NumEmpleadoNomina;
                    dbEntry.RegistroPatronalNomina = cDFI.RegistroPatronalNomina;
                    dbEntry.VersionNomina = cDFI.VersionNomina;

                    dbEntry.TotalGravadoPercepciones = cDFI.TotalGravadoPercepciones;
                    dbEntry.TotalExentoPercepciones = cDFI.TotalExentoPercepciones;
                    dbEntry.ImporteExentoPercepciones = cDFI.ImporteExentoPercepciones;
                    dbEntry.ImporteGravadoPercepciones = cDFI.ImporteGravadoPercepciones;
                    dbEntry.ConceptoPercepciones = cDFI.ConceptoPercepciones;
                    dbEntry.ClavePercepciones = cDFI.ClavePercepciones;
                    dbEntry.TipoPercepcion = cDFI.TipoPercepcion;

                    dbEntry.UUID = cDFI.UUID;
                }
            }
            context.SaveChanges();

        }
        public CDFI DeleteCDFI(int ID)
        {
            CDFI dbEntry = context.CDFIs
                .FirstOrDefault(p => p.ID == ID);
            if (dbEntry != null)
            {
                context.CDFIs.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
