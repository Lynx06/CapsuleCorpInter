using CapsuleCorpInter.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapsuleCorpInter.Controllers
{
    public class ClientesController : Controller
    {
        private EFContext context = new EFContext();

        // GET: Clientes
        public ActionResult Index()
        {
            return View(context.Clientes.OrderBy(c => c.Nome));
        }
    }
}