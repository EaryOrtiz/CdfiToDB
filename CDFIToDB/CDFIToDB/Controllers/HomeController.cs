using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CDFIToDB.Models;
using System.IO;
using System.Xml;
using Microsoft.Extensions.DependencyInjection;
using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore;

namespace CDFIToDB.Controllers
{
    public class HomeController : Controller
    {
        private ICDFIRepository repository;

        public HomeController(ICDFIRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public static void ImportXML(IServiceProvider services)
        {
            ApplicationDbContext context = services.GetRequiredService<ApplicationDbContext>();


            HtmlDocument doc = new HtmlDocument();
            doc.Load(@"C:\Users\eary.ortiz\Documents\GitHub\CdfiToDB\CDFIToDB\CDFIToDB\wwwroot\AppData\CFDIV33_0.xml");

                //CDFI:Comprobante
                var lugarexpedicioncomprobante = doc.DocumentNode.SelectSingleNode("/cfdi:Comprobante/@LugarExpedicion").InnerText;
                var metododepagocomprobante = doc.DocumentNode.SelectSingleNode(".//metododepago").InnerText;
                var tipodecomprobante = doc.DocumentNode.SelectSingleNode(".//tipodecomprobante").InnerText;
                var motivodescuentocomprobante = doc.DocumentNode.SelectSingleNode(".//motivodescuento").InnerText;
                var descuentocomprobante = doc.DocumentNode.SelectSingleNode(".//descuento").InnerText;
                var totalcomprobante = doc.DocumentNode.SelectSingleNode(".//totalcomprobante").InnerText;
                var subtotalcomprobante = doc.DocumentNode.SelectSingleNode(".//subtotal").InnerText;
                var certificadocomprobante = doc.DocumentNode.SelectSingleNode(".//certificado").InnerText;
                var noCertificadocomprobante = doc.DocumentNode.SelectSingleNode(".//nocertificado").InnerText;
                var sellocomprobante = doc.DocumentNode.SelectSingleNode(".//sellocomprobante").InnerText;
                var fechacomprobante = doc.DocumentNode.SelectSingleNode(".//fecha").InnerText;
                var formadepagocomprobante = doc.DocumentNode.SelectSingleNode(".//formadepago").InnerText;
                var foliocomprobante = doc.DocumentNode.SelectSingleNode(".//folio").InnerText;
                var seriecomprobante = doc.DocumentNode.SelectSingleNode(".//serie").InnerText;
                var versioncomprobante = doc.DocumentNode.SelectSingleNode(".//version").InnerText;
            /*
                //CDFI:Emisor
                var nombreemisor = XMLob.SelectSingleNode(".//nombreemisor").InnerText;
                var rfcemisor = XMLob.SelectSingleNode(".//rfcemisor").InnerText;
                var regimenEmisor = XMLob.SelectSingleNode(".//regimenEmisor").InnerText;

                //CDFI:Receptor
                var nombrereceptor = XMLob.SelectSingleNode(".//nombrereceptor").InnerText;
                var rfcreceptor = XMLob.SelectSingleNode(".//rfcreceptor").InnerText;

                //CDFI:Conceptos
                var importeconceptos = XMLob.SelectSingleNode(".//importeconceptos").InnerText;
                var valorunitarioconceptos = XMLob.SelectSingleNode(".//valorunitarioconceptos").InnerText;
                var descripcionconceptos = XMLob.SelectSingleNode(".//descripcionconceptos").InnerText;
                var unidadconceptos = XMLob.SelectSingleNode(".//unidadconceptos").InnerText;
                var cantidadconceptos = XMLob.SelectSingleNode(".//cantidadconceptos").InnerText;

                //CDFI:Impuestos
                var totalimpuestostrasladados = XMLob.SelectSingleNode(".//totalimpuestostrasladados").InnerText;
                var totalimpuestosreteneidos = XMLob.SelectSingleNode(".//totalimpuestosreteneidos").InnerText;
                var importeretecionesimpuestos = XMLob.SelectSingleNode(".//importeretecionesimpuestos").InnerText;
                var impuestoretencionesimpuestos = XMLob.SelectSingleNode(".//impuestoretencionesimpuestos").InnerText;

                //CDFI:Complemento
                //Nomina: nomina
                var salariodiariointegradonomina = XMLob.SelectSingleNode(".//salariodiariointegradonomina").InnerText;
                var riesgopuestonomina = XMLob.SelectSingleNode(".//riesgopuestonomina").InnerText;
                var salariobasecotapornomina = XMLob.SelectSingleNode(".//salariobasecotapornomina").InnerText;
                var periodicidadpagonomina = XMLob.SelectSingleNode(".//periodicidadpagonomina").InnerText;
                var tipojornadanomina = XMLob.SelectSingleNode(".//tipojornadanomina").InnerText;
                var tipocontratonomina = XMLob.SelectSingleNode(".//tipocontratonomina").InnerText;
                var puestonomina = XMLob.SelectSingleNode(".//puestonomina").InnerText;
                var antiguedadnomina = XMLob.SelectSingleNode(".//antiguedadnomina").InnerText;
                var fechainicioreallaboralnomina = XMLob.SelectSingleNode(".//fechainicioreallaboralnomina").InnerText;
                var departamentonomina = XMLob.SelectSingleNode(".//departamentonomina").InnerText;
                var numdiaspagadosnomina = XMLob.SelectSingleNode(".//numdiaspagadosnomina").InnerText;
                var fechafinalpagonomina = XMLob.SelectSingleNode(".//fechafinalpagonomina").InnerText;
                var fechainicialpagonomina = XMLob.SelectSingleNode(".//fechainicialpagonomina").InnerText;
                var fechapagonomina = XMLob.SelectSingleNode(".//fechapagonomina").InnerText;
                var numsegurosocialnomina = XMLob.SelectSingleNode(".//numsegurosocialnomina").InnerText;
                var tiporegimennomina = XMLob.SelectSingleNode(".//tiporegimennomina").InnerText;
                var curpnomina = XMLob.SelectSingleNode(".//curpnomina").InnerText;
                var numempleadonomina = XMLob.SelectSingleNode(".//numempleadonomina").InnerText;
                var registropatronalnomina = XMLob.SelectSingleNode(".//registropatronalnomina").InnerText;
                var versionnomina = XMLob.SelectSingleNode(".//versionnomina").InnerText;

                //Nomina:Percepciones
                var totalexentopercepciones = XMLob.SelectSingleNode(".//totalexentopercepciones").InnerText;
                var totalgravadopercepciones = XMLob.SelectSingleNode(".//totalgravadopercepciones").InnerText;
                var importeexentopercepciones = XMLob.SelectSingleNode(".//importeexentopercepciones").InnerText;
                var importegravadopercepciones = XMLob.SelectSingleNode(".//importegravadopercepciones").InnerText;
                var conceptopercepciones = XMLob.SelectSingleNode(".//conceptopercepciones").InnerText;
                var clavepercepciones = XMLob.SelectSingleNode(".//clavepercepciones").InnerText;
                var tipopercepcion = XMLob.SelectSingleNode(".//tipopercepcion").InnerText;

                //UUID
                var uuid = XMLob.SelectSingleNode(".//uuid").InnerText;
                context.CDFIs.Add(new CDFI
                {
                    LugarExpedicionComprobante = lugarexpedicioncomprobante,
                    MetodoDePagoComprobante = metododepagocomprobante,
                    TipoDeComprobante = tipodecomprobante,
                    MotivoDescuentoComprobante = motivodescuentocomprobante,
                    DescuentoComprobante = descuentocomprobante,
                    TotalComprobante = totalcomprobante,
                    SubtotalComprobante = subtotalcomprobante,
                    CertificadoComprobante = certificadocomprobante,
                    NoCertificadoComprobante = noCertificadocomprobante,
                    SelloComprobante = sellocomprobante,
                    FechaComprobante = fechacomprobante,
                    FormaDePagoComprobante = formadepagocomprobante,
                    FolioComprobante = foliocomprobante,
                    SerieComprobante = seriecomprobante,
                    VersionComprobante = versioncomprobante,

                    NombreEmisor = nombreemisor,
                    RFCEmisor = rfcemisor,
                    RegimenEmisor = regimenEmisor,

                    NombreReceptor = nombrereceptor,
                    RFCReceptor = rfcreceptor,

                    ImporteConceptos = importeconceptos,
                    ValorUnitarioConceptos = valorunitarioconceptos,
                    DescripcionConceptos = descripcionconceptos,
                    UnidadConceptos = unidadconceptos,
                    CantidadConceptos = cantidadconceptos,

                    TotalImpuestosTrasladados = totalimpuestostrasladados,
                    TotalImpuestosReteneidos = totalimpuestosreteneidos,
                    ImporteRetecionesImpuestos = importeretecionesimpuestos,
                    ImpuestoRetencionesImpuestos = importeretecionesimpuestos,

                    SalarioDiarioIntegradoNomina = salariodiariointegradonomina,
                    RiesgoPuestoNomina = riesgopuestonomina,
                    SalarioBaseCotAporNomina = salariobasecotapornomina,
                    PeriodicidadPagoNomina = periodicidadpagonomina,
                    TipoJornadaNomina = tipojornadanomina,
                    TipoContratoNomina = tipocontratonomina,
                    PuestoNomina = puestonomina,
                    AntiguedadNomina = antiguedadnomina,
                    FechaInicioRealLaboralNomina = fechainicioreallaboralnomina,
                    DepartamentoNomina = departamentonomina,
                    NumDiasPagadosNomina = numdiaspagadosnomina,
                    FechaInicialPagoNomina = fechainicialpagonomina,
                    FechaFinalPagoNomina = fechafinalpagonomina,
                    FechaPagoNomina = fechapagonomina,
                    NumSeguroSocialNomina= numsegurosocialnomina,
                    TipoRegimenNomina = tiporegimennomina,
                    CURPNomina = curpnomina,
                    NumEmpleadoNomina = numempleadonomina,
                    RegistroPatronalNomina = registropatronalnomina,
                    VersionNomina = versionnomina,

                    TotalExentoPercepciones = totalexentopercepciones,
                    TotalGravadoPercepciones = totalgravadopercepciones,
                    ImporteExentoPercepciones = importeexentopercepciones,
                    ImporteGravadoPercepciones = importegravadopercepciones,
                    ConceptoPercepciones = conceptopercepciones,
                    ClavePercepciones = clavepercepciones,
                    TipoPercepcion = tipopercepcion,

                    UUID = uuid
                });
                */
                context.Database.OpenConnection();
                try
                {
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.CDFIs ON");
                    context.SaveChanges();
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.CDFIs OFF");
                }
                finally
                {
                    context.Database.CloseConnection();
                }
                

        }

        [HttpPost]
        public IActionResult SeedXML()
        {
            HomeController.ImportXML(HttpContext.RequestServices);
            return RedirectToAction(nameof(Index));
        }
    }
}
