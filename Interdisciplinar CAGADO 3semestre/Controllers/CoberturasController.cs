using Modelo.Tabelas;
using Servico.Tabelas;
using System.Net;
using System.Web.Mvc;

namespace CapsuleCorpInter.Controllers
{
    public class CoberturasController : Controller
    {

        private CoberturaServico coberturaServico =
                        new CoberturaServico();


        // GET: Cadastros
        public ActionResult Index()
        {
            return View(coberturaServico.ObterCoberturasClassificadosPorNome());
        }


        private ActionResult ObterVisaoCoberturaPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                                HttpStatusCode.BadRequest);
            }
            Cobertura cobertura = coberturaServico.ObterCoberturaPorId((long)id);
            if (cobertura == null)
            {
                return HttpNotFound();
            }
            return View(cobertura);
        }

        private void PopularViewBag(Cobertura cobertura = null)
        {
            if (cobertura == null)
            {
                ViewBag.CoberturaId = new SelectList(coberturaServico.
                                ObterCoberturasClassificadosPorNome(),
                                "CoberturaId", "Nome");
            }
            else
            {
                ViewBag.CoberturaId = new SelectList(coberturaServico.
                                ObterCoberturasClassificadosPorNome(),
                                "CoberturaId", "Nome", cobertura.CoberturaId);
            }
        }

        // Metodo para responder as requisiçoes POST
        private ActionResult GravarCobertura(Cobertura cobertura)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    coberturaServico.GravarCobertura(cobertura);
                    return RedirectToAction("Index");
                }
                return View(cobertura);
            }
            catch
            {
                return View(cobertura);
            }
        }

        // GET: Cadastros/Details/5
        public ActionResult Details(long? id)
        {
            return ObterVisaoCoberturaPorId(id);
        }

        // GET: Cadastros/Create
        public ActionResult Create()
        {
            PopularViewBag();
            return View();
        }

        // POST: Cadastros/Create
        [HttpPost]
        public ActionResult Create(Cobertura cobertura)
        {
            return GravarCobertura(cobertura);
        }

        // GET: Cadastros/Edit/5
        public ActionResult Edit(int? id)
        {
            PopularViewBag(coberturaServico.ObterCoberturaPorId((long)id));
            return ObterVisaoCoberturaPorId(id);
        }

        // POST: Cadastros/Edit/5
        [HttpPost]
        public ActionResult Edit(Cobertura cobertura)
        {
            return GravarCobertura(cobertura);
        }

        // GET: Cadastros/Delete/5
        public ActionResult Delete(long? id)
        {
            return ObterVisaoCoberturaPorId(id);
        }

        // POST: Cadastros/Delete/5
        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                Cobertura cobertura = coberturaServico.EliminarCoberturaPorId(id);
                TempData["Message"] = "Cobertura" + cobertura.Nome.ToUpper()
                                + "	foi	removido";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}