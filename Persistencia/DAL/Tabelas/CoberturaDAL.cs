using Modelo.Tabelas;
using Persistencia.Contexts;
using System.Linq;

namespace Persistencia.DAL.Tabelas
{
    class CoberturaDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Cobertura>
                                        ObterCategoriasClassificadasPorNome()
        {
            return context.Coberturas.OrderBy(b => b.Nome);
        }
    }
}
