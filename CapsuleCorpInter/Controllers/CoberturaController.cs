using CapsuleCorpInter.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapsuleCorpInter.Controllers
{
    public class CoberturaController : Controller
    {
        public static IList<Cobertura> coberturas = new List<Cobertura>()
        {
            new Cobertura()
            {
                CoberturaId = 1,
                Nome = "Exames"
            },

            new Cobertura()
            {
                CoberturaId = 2,
                Nome = "Consultas Médicas"
            }
        };

        // GET: Cobertura
        public ActionResult Index()
        {
            return View(coberturas);
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cobertura cobertura)
        {
            coberturas.Add(cobertura);
            cobertura.CoberturaId =
                            coberturas.Select(m => m.CoberturaId).Max() + 1;
            return RedirectToAction("Index");
        }
    }
}