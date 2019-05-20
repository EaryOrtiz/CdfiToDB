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
            doc.Load(@"C:\Users\eary.ortiz\Documents\GitHub\ProodFloorCSharpp\ProdFloor\wwwroot\AppData\Steps.xml");

            var XMLobs = doc.DocumentNode.SelectNodes("//step");

            foreach (var XMLob in XMLobs)
            {
                var stepid = XMLob.SelectSingleNode(".//stepid").InnerText;
                var jobtypeid = XMLob.SelectSingleNode(".//jobtypeid").InnerText;
                var stage = XMLob.SelectSingleNode(".//stage").InnerText;
                var expectedtime = XMLob.SelectSingleNode(".//expectedtime").InnerText;
                var description = XMLob.SelectSingleNode(".//description").InnerText;
                var order = XMLob.SelectSingleNode(".//order").InnerText;

                context.CDFIs.Add(new CDFI
                {
                    
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
