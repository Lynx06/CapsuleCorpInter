using CapsuleCorpInter.Models;
using CapsuleCorpInter.Views;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CapsuleCorpInter.Contexts
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Asp_Net_MVC_CS") { }

        public DbSet<Cobertura> coberturas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
    }
}