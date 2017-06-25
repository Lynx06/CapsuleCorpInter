using Modelo.Cadastros;
using Persistencia.DAL.Cadastros;
using System.Linq;

namespace Servico.Cadastros
{
    public class ClienteServico
    {
        private ClienteDAL clienteDAL = new ClienteDAL();
        public IQueryable<Cliente>
                                        ObterFabricantesClassificadosPorNome()
        {
            return clienteDAL.
                            ObterFabricantesClassificadosPorNome();
        }
    }
}
