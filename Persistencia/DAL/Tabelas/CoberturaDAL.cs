using Modelo.Tabelas;
using Persistencia.Contexts;
using System.Data.Entity;
using System.Linq;

namespace Persistencia.DAL.Tabelas
{
    public class CoberturaDAL
    {
        private EFContext context = new EFContext();

        public IQueryable<Cobertura>ObterCoberturasClassificadasPorNome()
        {
            return context.Coberturas.OrderBy(b => b.Nome);
        }

        public Cobertura ObterCoberturaPorId(long id)
        {
            return context.Coberturas.Where(p => p.CoberturaId == id).
                           First();
        }


        public void GravarCobertura(Cobertura cobertura)
        {
            if (cobertura.CoberturaId == 0)
            {
                context.Coberturas.Add(cobertura);
            }
            else
            {
                context.Entry(cobertura).State =
                                EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Cobertura EliminarCoberturaPorId(long id)
        {
            Cobertura cobertura = ObterCoberturaPorId(id);
            context.Coberturas.Remove(cobertura);
            context.SaveChanges();
            return cobertura;
        }
    }
}
