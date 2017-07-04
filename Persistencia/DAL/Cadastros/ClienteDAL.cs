using Persistencia.Contexts;
using Modelo.Cadastros;
using System.Linq;
using System.Data.Entity;

namespace Persistencia.DAL.Cadastros
{
    public class ClienteDAL
    {
        private EFContext context = new EFContext();

        public IQueryable<Cliente>ObterClientesClassificadosPorNome()
        {
            return context.Clientes.OrderBy(b => b.Nome);
        }

        public Cliente ObterClientePorId(long id)
        {
            return context.Clientes.Where(p => p.ClienteId == id).
                           First();
        }


        public void GravarCliente(Cliente cliente)
        {
            if (cliente.ClienteId == 0)
            {
                context.Clientes.Add(cliente);
            }
            else
            {
                context.Entry(cliente).State =
                                EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Cliente EliminarClientePorId(long id)
        {
            Cliente cliente = ObterClientePorId(id);
            context.Clientes.Remove(cliente);
            context.SaveChanges();
            return cliente;
        }
    }
}
