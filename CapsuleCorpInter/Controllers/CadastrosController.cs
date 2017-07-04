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
            return View(cadastroServico.ObterCadastrosClassificadosPorNome());
        }


        private ActionResult ObterVisaoCadastroPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                                HttpStatusCode.BadRequest);
            }
            Cadastro cadastro = cadastroServico.ObterCadastroPorId((long)id);
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
                                ObterCoberturasClassificadosPorNome(),
                                "CoberturaId", "Nome");
                ViewBag.ClienteId = new SelectList(clienteServico.
                                ObterClientesClassificadosPorNome(),
                                "ClienteId", "Nome");
            }
            else
            {
                ViewBag.CoberturaId = new SelectList(coberturaServico.
                                ObterCoberturasClassificadosPorNome(),
                                "CoberturaId", "Nome", cadastro.CoberturaId);
                ViewBag.ClienteId = new SelectList(clienteServico.
                                ObterClientesClassificadosPorNome(),
                                "ClienteId", "Nome", cadastro.ClienteId);
            }
        }        // Metodo para responder as requisiçoes POST        private ActionResult GravarCadastro(Cadastro cadastro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    cadastroServico.GravarCadastro(cadastro);
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
            return ObterVisaoCadastroPorId(id);
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
            return GravarCadastro(cadastro);
        }

        // GET: Cadastros/Edit/5
        public ActionResult Edit(int? id)
        {
            PopularViewBag(cadastroServico.ObterCadastroPorId((long)id));
            return ObterVisaoCadastroPorId(id);
        }

        // POST: Cadastros/Edit/5
        [HttpPost]
        public ActionResult Edit(Cadastro cadastro)
        {
            return GravarCadastro(cadastro);
        }

        // GET: Cadastros/Delete/5
        public ActionResult Delete(long? id)
        {
            return ObterVisaoCadastroPorId(id);
        }

        // POST: Cadastros/Delete/5
        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                Cadastro cadastro = cadastroServico.EliminarCadastroPorId(id);
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
