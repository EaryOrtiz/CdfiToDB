using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDFIToDB.Models
{
    public class CDFI
    {
        public int ID { get; set; }

        //CDFI:Comprobante
        public string LugarExpedicionComprobante { get; set; }
        public string MetodoDePagoComprobante { get; set; }
        public string TipoDeComprobante { get; set; }
        public string MotivoDescuentoComprobante { get; set; }
        public string DescuentoComprobante { get; set; }
        public string TotalComprobante { get; set; }
        public string SubtotalComprobante { get; set; }
        public string CertificadoComprobante { get; set; }
        public string NoCertificadoComprobante { get; set; }
        public string SelloComprobante { get; set; }
        public string FechaComprobante { get; set; }
        public string FormaDePagoComprobante { get; set; }
        public string FolioComprobante { get; set; }
        public string SerieComprobante { get; set; }
        public string VersionComprobante { get; set; }

        //CDFI:Emisor
        public string NombreEmisor { get; set; }
        public string RFCEmisor { get; set; }
        public string RegimenEmisor { get; set; }

        //CDFI:Receptor
        public string NombreReceptor { get; set; }
        public string RFCReceptor { get; set; }

        //CDFI:Conceptos
        public string ImporteConceptos { get; set; }
        public string ValorUnitarioConceptos { get; set; }
        public string DescripcionConceptos { get; set; }
        public string UnidadConceptos { get; set; }
        public string CantidadConceptos { get; set; }

        //CDFI:Impuestos
        public string TotalImpuestosTrasladados { get; set; }
        public string TotalImpuestosReteneidos { get; set; }
        public string ImporteRetecionesImpuestos { get; set; }
        public string ImpuestoRetencionesImpuestos { get; set; }

        //CDFI:Complemento
        //Nomina: nomina
        public string SalarioDiarioIntegradoNomina { get; set; }
        public string RiesgoPuestoNomina { get; set; }
        public string SalarioBaseCotAporNomina { get; set; }
        public string PeriodicidadPagoNomina { get; set; }
        public string TipoJornadaNomina { get; set; }
        public string TipoContratoNomina { get; set; }
        public string PuestoNomina { get; set; }
        public string AntiguedadNomina { get; set; }
        public string FechaInicioRealLaboralNomina { get; set; }
        public string DepartamentoNomina { get; set; }
        public string NumDiasPagadosNomina { get; set; }
        public string FechaFinalPagoNomina { get; set; }
        public string FechaInicialPagoNomina { get; set; }
        public string FechaPagoNomina { get; set; }
        public string NumSeguroSocialNomina { get; set; }
        public string TipoRegimenNomina { get; set; }
        public string CURPNomina { get; set; }
        public string NumEmpleadoNomina { get; set; }
        public string RegistroPatronalNomina { get; set; }
        public string VersionNomina { get; set; }

        //Nomina:Percepciones
        public string TotalExentoPercepciones { get; set; }
        public string TotalGravadoPercepciones { get; set; }
        public string ImporteExentoPercepciones { get; set; }
        public string ImporteGravadoPercepciones { get; set; }
        public string ConceptoPercepciones { get; set; }
        public string ClavePercepciones { get; set; }
        public string TipoPercepcion { get; set; }

        //UUID
        public string UUID { get; set; }
    }
}
