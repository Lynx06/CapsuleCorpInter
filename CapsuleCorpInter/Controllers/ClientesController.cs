using Modelo.Cadastros;
using Servico.Cadastros;
using System.Net;
using System.Web.Mvc;

namespace CapsuleCorpInter.Controllers
{
    public class ClientesController : Controller
    {
        private ClienteServico clienteServico =
                        new ClienteServico();


        // GET: Cadastros
        public ActionResult Index()
        {
            return View(clienteServico.ObterClientesClassificadosPorNome());
        }


        private ActionResult ObterVisaoClientePorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                                HttpStatusCode.BadRequest);
            }
            Cliente cliente = clienteServico.ObterClientePorId((long)id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        private void PopularViewBag(Cliente cliente = null)
        {
            if (cliente == null)
            {
                ViewBag.ClienteId = new SelectList(clienteServico.
                                ObterClientesClassificadosPorNome(),
                                "ClienteId", "Nome");
            }
            else
            {
                ViewBag.ClienteId = new SelectList(clienteServico.
                                ObterClientesClassificadosPorNome(),
                                "ClienteId", "Nome", cliente.ClienteId);
            }
        }

        // Metodo para responder as requisiçoes POST
        private ActionResult GravarCliente(Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    clienteServico.GravarCliente(cliente);
                    return RedirectToAction("Index");
                }
                return View(cliente);
            }
            catch
            {
                return View(cliente);
            }
        }

        // GET: Cadastros/Details/5
        public ActionResult Details(long? id)
        {
            return ObterVisaoClientePorId(id);
        }

        // GET: Cadastros/Create
        public ActionResult Create()
        {
            PopularViewBag();
            return View();
        }

        // POST: Cadastros/Create
        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            return GravarCliente(cliente);
        }

        // GET: Cadastros/Edit/5
        public ActionResult Edit(int? id)
        {
            PopularViewBag(clienteServico.ObterClientePorId((long)id));
            return ObterVisaoClientePorId(id);
        }

        // POST: Cadastros/Edit/5
        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {
            return GravarCliente(cliente);
        }

        // GET: Cadastros/Delete/5
        public ActionResult Delete(long? id)
        {
            return ObterVisaoClientePorId(id);
        }

        // POST: Cadastros/Delete/5
        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                Cliente cliente = clienteServico.EliminarClientePorId(id);
                TempData["Message"] = "Cliente	" + cliente.Nome.ToUpper()
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