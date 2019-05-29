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
        public IQueryable<Percepcion> Percepciones => context.Percepciones;

        public void SaveCDFI(CDFI cDFI)
        {
            if (cDFI.CFDIID == 0)
            {
                context.CDFIs.Add(cDFI);
            }
            else
            {
                CDFI dbEntry = context.CDFIs
                .FirstOrDefault(p => p.CFDIID == cDFI.CFDIID);
                if (dbEntry != null)
                {
                    dbEntry.CFDIID = cDFI.CFDIID;
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

                    dbEntry.UUID = cDFI.UUID;
                }
            }
            context.SaveChanges();

        }
        public void SavePercepcion(Percepcion Percepcion)
        {
            if (Percepcion.PercepcionID == 0)
            {
                context.Percepciones.Add(Percepcion);
            }
            else
            {
                Percepcion dbEntry = context.Percepciones
                .FirstOrDefault(p => p.CFDIID == Percepcion.PercepcionID);
                if (dbEntry != null)
                {
                    dbEntry.CFDIID = Percepcion.CFDIID;
                    dbEntry.ImporteExentoPercepciones = Percepcion.ImporteExentoPercepciones;
                    dbEntry.ImporteGravadoPercepciones = Percepcion.ImporteGravadoPercepciones;
                    dbEntry.ConceptoPercepciones = Percepcion.ConceptoPercepciones;
                    dbEntry.ClavePercepciones = Percepcion.ClavePercepciones;
                    dbEntry.TipoPercepcion = Percepcion.TipoPercepcion;
                }
            }
            context.SaveChanges();

        }


        public CDFI DeleteCDFI(int ID)
        {
            CDFI dbEntry = context.CDFIs
                .FirstOrDefault(p => p.CFDIID == ID);
            if (dbEntry != null)
            {
                context.CDFIs.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
        public Percepcion DeletePercepcion(int ID)
        {
            Percepcion dbEntry = context.Percepciones
                .FirstOrDefault(p => p.PercepcionID == ID);
            if (dbEntry != null)
            {
                context.Percepciones.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
