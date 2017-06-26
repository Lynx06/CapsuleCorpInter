using Modelo.Tabelas;
using Persistencia.Contexts;
using System.Linq;

namespace Persistencia.DAL.Tabelas
{
    public class CoberturaDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Cobertura>
                                        ObterCategoriasClassificadasPorNome()
        {
            return context.Coberturas.OrderBy(b => b.Nome);
        }
    }
}
