
using Modelo.Tabelas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Modelo.Cadastros
{
    public class Cadastro
    {
        public long? CadastroId { get; set; }
        [DisplayName("1234566")]
        public string Nome { get; set; }

        public long? CoberturaId { get; set; }
        public long? ClienteId { get; set; }

        public Cobertura Cobertura { get; set; }
        public Cliente Cliente { get; set; }

    }
}