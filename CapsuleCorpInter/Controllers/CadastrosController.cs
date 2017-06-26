using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using Modelo.Cadastros;
using Servico.Cadastros;
using Servico.Tabelas;

namespace CapsuleCorpInter.Controllers
{
    public class CadastrosController : Controller
    {
        private CadastroServico cadastroServico =
                                            new CadastroServico();
        private CoberturaServico coberturaServico =
                        new CoberturaServico();
        private ClienteServico clienteServico =
                        new ClienteServico();


        // GET: Cadastros
        public ActionResult Index()
        {
            return View(cadastroServico.ObterProdutosClassificadosPorNome());
        }


        private ActionResult ObterVisaoProdutoPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                                HttpStatusCode.BadRequest);
            }
            Cadastro cadastro = cadastroServico.ObterProdutoPorId((long)id);
            if (cadastro == null)
            {
                return HttpNotFound();
            }
            return View(cadastro);
        }

        private void PopularViewBag(Cadastro cadastro = null)
        {
            if (cadastro == null)
            {
                ViewBag.CoberturaId = new SelectList(coberturaServico.
                                ObterCategoriasClassificadasPorNome(),
                                "CoberturaId", "Nome");
                ViewBag.ClienteId = new SelectList(clienteServico.
                                ObterFabricantesClassificadosPorNome(),
                                "ClienteId", "Nome");
            }
            else
            {
                ViewBag.CoberturaId = new SelectList(coberturaServico.
                                ObterCategoriasClassificadasPorNome(),
                                "CoberturaId", "Nome", cadastro.CoberturaId);
                ViewBag.ClienteId = new SelectList(clienteServico.
                                ObterFabricantesClassificadosPorNome(),
                                "ClienteId", "Nome", cadastro.ClienteId);
            }
        }        // Metodo para responder as requisiçoes POST        private ActionResult GravarProduto(Cadastro cadastro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    cadastroServico.GravarProduto(cadastro);
                    return RedirectToAction("Index");
                }
                return View(cadastro);
            }
            catch
            {
                return View(cadastro);
            }
        }

        // GET: Cadastros/Details/5
        public ActionResult Details(long? id)
        {
            return ObterVisaoProdutoPorId(id);
        }

        // GET: Cadastros/Create
        public ActionResult Create()
        {
            PopularViewBag();
            return View();
        }

        // POST: Cadastros/Create
        [HttpPost]
        public ActionResult Create(Cadastro cadastro)
        {
            return GravarProduto(cadastro);
        }

        // GET: Cadastros/Edit/5
        public ActionResult Edit(int? id)
        {
            PopularViewBag(cadastroServico.ObterProdutoPorId((long)id));
            return ObterVisaoProdutoPorId(id);
        }

        // POST: Cadastros/Edit/5
        [HttpPost]
        public ActionResult Edit(Cadastro cadastro)
        {
            return GravarProduto(cadastro);
        }

        // GET: Cadastros/Delete/5
        public ActionResult Delete(long? id)
        {
            return ObterVisaoProdutoPorId(id);
        }

        // POST: Cadastros/Delete/5
        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                Cadastro cadastro = cadastroServico.EliminarProdutoPorId(id);
                TempData["Message"] = "Cadastro	" + cadastro.Nome.ToUpper()
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
