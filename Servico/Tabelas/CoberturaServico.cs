using Modelo.Tabelas;
using Persistencia.DAL.Tabelas;
using System.Linq;
namespace Servico.Tabelas
{
    public class CoberturaServico
    {
        private CoberturaDAL coberturaDAL = new CoberturaDAL();

        public IQueryable<Cobertura>ObterCoberturasClassificadosPorNome()
        {
            return coberturaDAL.ObterCoberturasClassificadasPorNome();
        }

        public Cobertura ObterCoberturaPorId(long id)
        {
            return coberturaDAL.ObterCoberturaPorId(id);
        }

        public void GravarCobertura(Cobertura cobertura)
        {
            coberturaDAL.GravarCobertura(cobertura);
        }

        public Cobertura EliminarCoberturaPorId(long id)
        {
            return coberturaDAL.EliminarCoberturaPorId(id);
        }
    }
}
