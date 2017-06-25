using Modelo.Tabelas;
using Persistencia.Contexts;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace CapsuleCorpInter.Controllers
{
    public class CoberturasController : Controller
    {

        private EFContext context = new EFContext();

        //	GET:	Coberturas
        public ActionResult Index()
        {
            return View(context.Coberturas.OrderBy(
                            c => c.Nome));
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cobertura cobertura)
        {
            context.Coberturas.Add(cobertura);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        //	GET:	Coberturas/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new
                                HttpStatusCodeResult(
                                HttpStatusCode.BadRequest);
            }
            Cobertura cobertura = context.Coberturas.Find(id);
            if (cobertura == null)
            {
                return HttpNotFound();
            }
            return View(cobertura);
        }

        //	POST:	Coberturas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cobertura cobertura)
        {
            if (ModelState.IsValid)
            {
                context.Entry(cobertura).State =
                                                   EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cobertura);
        }

        //	GET:	Coberturas/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                                HttpStatusCode.BadRequest);
            }
            Cobertura cobertura = context.Coberturas.
                            Find(id);
            if (cobertura == null)
            {
                return HttpNotFound();
            }
            return View(cobertura);
        }

        //	GET:	Fabricantes/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                                HttpStatusCode.BadRequest);
            }
            Cobertura cobertura = context.Coberturas.Find(id);
            if (cobertura == null)
            {
                return HttpNotFound();
            }
            return View(cobertura);
            }

        //	POST:	Fabricantes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Cobertura cobertura = context.Coberturas.
                            Find(id);
            context.Coberturas.Remove(cobertura);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}