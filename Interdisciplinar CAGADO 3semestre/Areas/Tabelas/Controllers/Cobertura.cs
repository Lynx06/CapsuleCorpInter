using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapsuleCorpInter.Areas.Tabelas.Controllers
{
    public class Cobertura
    {
        public long CoberturaId { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Cadastro> Cadastros { get; set; }
    }
}