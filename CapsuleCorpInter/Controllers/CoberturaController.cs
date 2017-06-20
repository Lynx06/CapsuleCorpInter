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

        public ActionResult Edit(long id)
        {
            return View(coberturas.Where(m => m.CoberturaId == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cobertura cobertura)
        {
            coberturas.Remove(coberturas.Where(
                            c => c.CoberturaId == cobertura.CoberturaId)
                            .First());
            coberturas.Add(cobertura);
            return RedirectToAction("Index");
        }        public ActionResult Details(long id)
        {
            return View(coberturas.Where(
                            m => m.CoberturaId == id).First());
        }        public ActionResult Delete(long id)
        {
            return View(coberturas.Where(
                            m => m.CoberturaId == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Cobertura cobertura)
        {
            coberturas.Remove(coberturas.Where(
                            c => c.CoberturaId == cobertura.CoberturaId)
                            .First());
            return RedirectToAction("Index");
        }
    }
}