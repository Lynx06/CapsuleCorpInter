using CapsuleCorpInter.Models;
using System.Data.Entity;

namespace CapsuleCorpInter.Contexts
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Asp_Net_MVC_CS") {
            Database.SetInitializer<EFContext>(new DropCreateDatabaseIfModelChanges<EFContext>());
        }

        public DbSet<Cobertura> Coberturas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cadastro> Cadastros { get; set; }
    }
}