
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
        [DisplayName("Nome do Plano")]
        public string Nome { get; set; }

        public long? CoberturaId { get; set; }
        public long? ClienteId { get; set; }

        [DisplayName("Cobertura")]
        public Cobertura Cobertura { get; set; }
        [DisplayName("Nome do Cliente")]
        public Cliente Cliente { get; set; }

    }
}