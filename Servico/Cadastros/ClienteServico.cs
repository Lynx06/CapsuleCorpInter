using Modelo.Cadastros;
using Persistencia.DAL.Cadastros;
using System.Linq;

namespace Servico.Cadastros
{
    public class ClienteServico
    {
        private ClienteDAL clienteDAL = new ClienteDAL();

        public IQueryable<Cliente>ObterClientesClassificadosPorNome()
        {
            return clienteDAL.ObterClientesClassificadosPorNome();
        }
        public Cliente ObterClientePorId(long id)
        {
            return clienteDAL.ObterClientePorId(id);
        }

        public void GravarCliente(Cliente cliente)
        {
            clienteDAL.GravarCliente(cliente);
        }

        public Cliente EliminarClientePorId(long id)
        {
            return clienteDAL.EliminarClientePorId(id);
        }
    }
}
