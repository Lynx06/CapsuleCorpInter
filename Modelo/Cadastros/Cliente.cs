﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Modelo.Cadastros
{
    public class Cliente
    {
        public long ClienteId { get; set; } 
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public int DddTelefone { get; set; }
        public int Telefone { get; set; }
        public int DddCelular { get; set; }
        public int Celular { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        public virtual ICollection<Cadastro> Cadastros { get; set; }
    }
}