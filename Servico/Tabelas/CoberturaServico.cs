using Modelo.Cadastros;
using Modelo.Tabelas;
using Persistencia.DAL.Tabelas;
using System.Linq;
namespace Servico.Tabelas
{
    public class CoberturaServico
    {
        private CoberturaDAL categoriaDAL = new CoberturaDAL();
        public IQueryable<Cobertura>
                                        ObterCategoriasClassificadasPorNome()
        {
            return categoriaDAL.ObterCategoriasClassificadasPorNome();
        }
    }
}
