using Persistencia.Contexts;
using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Cadastros
{
    class ClienteDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Cliente>
                                        ObterFabricantesClassificadosPorNome()
        {
            return context.Clientes.OrderBy(b => b.Nome);
        }
    }
}
