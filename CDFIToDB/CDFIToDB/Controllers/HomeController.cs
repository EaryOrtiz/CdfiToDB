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
using CDFIToDB.Models.ViewModel;

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
            CFDIViewModel viewModel = new CFDIViewModel()
            {
                CDFIs = repository.CDFIs.ToList(),
                Percepciones = repository.Percepciones.ToList()
            };
            return View(viewModel);
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

            
            XmlDocument doc = new XmlDocument();
            XmlNamespaceManager nameSpace = new XmlNamespaceManager(doc.NameTable);
            nameSpace.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3");
            nameSpace.AddNamespace("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital");
            nameSpace.AddNamespace("nomina", "http://www.sat.gob.mx/nomina");
            int count = 1;
            for (int j = 0; j < 3; j++)
            {
                try
                {
                    doc.Load(@"C:\Users\eary.ortiz\Documents\GitHub\CdfiToDB\CDFIToDB\CDFIToDB\wwwroot\AppData\CFDIV33_" + j.ToString() + ".xml");
                }
                catch(Exception e)
                {
                    break;
                }
                
                //CDFI:Comprobante
                var lugarexpedicioncomprobante = doc.SelectSingleNode("/cfdi:Comprobante/@LugarExpedicion", nameSpace).InnerText;
                var metododepagocomprobante = doc.SelectSingleNode("/cfdi:Comprobante/@metodoDePago", nameSpace).InnerText;
                var tipodecomprobante = doc.SelectSingleNode("/cfdi:Comprobante/@tipoDeComprobante", nameSpace).InnerText;
                var motivodescuentocomprobante = doc.SelectSingleNode("/cfdi:Comprobante/@motivoDescuento", nameSpace).InnerText;
                var descuentocomprobante = doc.SelectSingleNode("/cfdi:Comprobante/@descuento", nameSpace).InnerText;
                var totalcomprobante = doc.SelectSingleNode("/cfdi:Comprobante/@total", nameSpace).InnerText;
                var subtotalcomprobante = doc.SelectSingleNode("/cfdi:Comprobante/@subTotal", nameSpace).InnerText;
                var certificadocomprobante = doc.SelectSingleNode("/cfdi:Comprobante/@certificado", nameSpace).InnerText;
                var noCertificadocomprobante = doc.SelectSingleNode("/cfdi:Comprobante/@noCertificado", nameSpace).InnerText;
                var sellocomprobante = doc.SelectSingleNode("/cfdi:Comprobante/@sello", nameSpace).InnerText;
                var fechacomprobante = doc.SelectSingleNode("/cfdi:Comprobante/@fecha", nameSpace).InnerText;
                var formadepagocomprobante = doc.SelectSingleNode("/cfdi:Comprobante/@formaDePago", nameSpace).InnerText;
                var foliocomprobante = doc.SelectSingleNode("/cfdi:Comprobante/@folio", nameSpace).InnerText;
                var seriecomprobante = doc.SelectSingleNode("/cfdi:Comprobante/@serie", nameSpace).InnerText;
                var versioncomprobante = doc.SelectSingleNode("/cfdi:Comprobante/@version", nameSpace).InnerText;

                //CDFI:Emisor
                var nombreemisor = doc.SelectSingleNode("/cfdi:Comprobante/cfdi:Emisor/@nombre", nameSpace).InnerText;
                var rfcemisor = doc.SelectSingleNode("/cfdi:Comprobante/cfdi:Emisor/@rfc", nameSpace).InnerText;
                var regimenEmisor = doc.SelectSingleNode("/cfdi:Comprobante/cfdi:Emisor/cfdi:RegimenFiscal/@Regimen", nameSpace).InnerText;

                //CDFI:Receptor
                var nombrereceptor = doc.SelectSingleNode("/cfdi:Comprobante/cfdi:Receptor/@nombre", nameSpace).InnerText;
                var rfcreceptor = doc.SelectSingleNode("/cfdi:Comprobante/cfdi:Receptor/@rfc", nameSpace).InnerText;

                //CDFI:Conceptos
                var importeconceptos = doc.SelectSingleNode("/cfdi:Comprobante/cfdi:Conceptos/cfdi:Concepto/@importe", nameSpace).InnerText;
                var valorunitarioconceptos = doc.SelectSingleNode("/cfdi:Comprobante/cfdi:Conceptos/cfdi:Concepto/@valorUnitario", nameSpace).InnerText;
                var descripcionconceptos = doc.SelectSingleNode("/cfdi:Comprobante/cfdi:Conceptos/cfdi:Concepto/@descripcion", nameSpace).InnerText;
                var unidadconceptos = doc.SelectSingleNode("/cfdi:Comprobante/cfdi:Conceptos/cfdi:Concepto/@unidad", nameSpace).InnerText;
                var cantidadconceptos = doc.SelectSingleNode("/cfdi:Comprobante/cfdi:Conceptos/cfdi:Concepto/@cantidad", nameSpace).InnerText;

                //CDFI:Impuestos
                var totalimpuestostrasladados = doc.SelectSingleNode("/cfdi:Comprobante/cfdi:Impuestos/@totalImpuestosTrasladados", nameSpace).InnerText;
                var totalimpuestosreteneidos = doc.SelectSingleNode("/cfdi:Comprobante/cfdi:Impuestos/@totalImpuestosRetenidos", nameSpace).InnerText;
                var importeretecionesimpuestos = doc.SelectSingleNode("/cfdi:Comprobante/cfdi:Impuestos/cfdi:Retenciones/cfdi:Retencion/@importe", nameSpace).InnerText;
                var impuestoretencionesimpuestos = doc.SelectSingleNode("/cfdi:Comprobante/cfdi:Impuestos/cfdi:Retenciones/cfdi:Retencion//@impuesto", nameSpace).InnerText;

                //CDFI:Complemento
                //Nomina: nomina
                var salariodiariointegradonomina = doc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/nomina:Nomina/@SalarioDiarioIntegrado", nameSpace).InnerText;
                var riesgopuestonomina = doc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/nomina:Nomina/@RiesgoPuesto", nameSpace).InnerText;
                var salariobasecotapornomina = doc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/nomina:Nomina/@SalarioBaseCotApor", nameSpace).InnerText;
                var periodicidadpagonomina = doc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/nomina:Nomina/@PeriodicidadPago", nameSpace).InnerText;
                var tipojornadanomina = doc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/nomina:Nomina/@TipoJornada", nameSpace).InnerText;
                var tipocontratonomina = doc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/nomina:Nomina/@TipoContrato", nameSpace).InnerText;
                var puestonomina = doc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/nomina:Nomina/@Puesto", nameSpace).InnerText;
                var antiguedadnomina = doc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/nomina:Nomina/@Antiguedad", nameSpace).InnerText;
                var fechainicioreallaboralnomina = doc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/nomina:Nomina/@FechaInicioRelLaboral", nameSpace).InnerText;
                var departamentonomina = doc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/nomina:Nomina/@Departamento", nameSpace).InnerText;
                var numdiaspagadosnomina = doc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/nomina:Nomina/@NumDiasPagados", nameSpace).InnerText;
                var fechafinalpagonomina = doc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/nomina:Nomina/@FechaFinalPago", nameSpace).InnerText;
                var fechainicialpagonomina = doc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/nomina:Nomina/@FechaInicialPago", nameSpace).InnerText;
                var fechapagonomina = doc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/nomina:Nomina/@FechaPago", nameSpace).InnerText;
                var numsegurosocialnomina = doc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/nomina:Nomina/@NumSeguridadSocial", nameSpace).InnerText;
                var tiporegimennomina = doc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/nomina:Nomina/@TipoRegimen", nameSpace).InnerText;
                var curpnomina = doc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/nomina:Nomina/@CURP", nameSpace).InnerText;
                var numempleadonomina = doc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/nomina:Nomina/@NumEmpleado", nameSpace).InnerText;
                var registropatronalnomina = doc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/nomina:Nomina/@RegistroPatronal", nameSpace).InnerText;
                var versionnomina = doc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/nomina:Nomina/@Version", nameSpace).InnerText;

                //Nomina:Percepciones
                var totalexentopercepciones = doc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/nomina:Nomina/nomina:Percepciones/@TotalExento", nameSpace).InnerText;
                var totalgravadopercepciones = doc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/nomina:Nomina/nomina:Percepciones/@TotalGravado", nameSpace).InnerText;

                //UUID
                var uuid = doc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@UUID", nameSpace).InnerText;
                context.CDFIs.Add(new CDFI
                {
                    CFDIID = count,
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
                    NumSeguroSocialNomina = numsegurosocialnomina,
                    TipoRegimenNomina = tiporegimennomina,
                    CURPNomina = curpnomina,
                    NumEmpleadoNomina = numempleadonomina,
                    RegistroPatronalNomina = registropatronalnomina,
                    VersionNomina = versionnomina,

                    TotalExentoPercepciones = totalexentopercepciones,
                    TotalGravadoPercepciones = totalgravadopercepciones,

                    UUID = uuid
                });
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
                try
                {
                    for (int i = 1; i < 15; i++)
                    {
                        var importeexentopercepciones = doc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/nomina:Nomina/nomina:Percepciones/nomina:Percepcion[" + i.ToString() + "]/@ImporteExento", nameSpace).InnerText;
                        var importegravadopercepciones = doc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/nomina:Nomina/nomina:Percepciones/nomina:Percepcion[" + i.ToString() + "]/@ImporteGravado", nameSpace).InnerText;
                        var conceptopercepciones = doc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/nomina:Nomina/nomina:Percepciones/nomina:Percepcion[" + i.ToString() + "]/@Concepto", nameSpace).InnerText;
                        var clavepercepciones = doc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/nomina:Nomina/nomina:Percepciones/nomina:Percepcion[" + i.ToString() + "]/@Clave", nameSpace).InnerText;
                        var tipopercepcion = doc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/nomina:Nomina/nomina:Percepciones/nomina:Percepcion[" + i.ToString() + "]/@TipoPercepcion", nameSpace).InnerText;

                        context.Percepciones.Add(new Percepcion
                        {
                            CFDIID = count,
                            ImporteExentoPercepciones = importeexentopercepciones,
                            ImporteGravadoPercepciones = importegravadopercepciones,
                            ConceptoPercepciones = conceptopercepciones,
                            ClavePercepciones = clavepercepciones,
                            TipoPercepcion = tipopercepcion,
                        });
                        context.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    Debug.Print(e.ToString());
                }
                count++;
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
