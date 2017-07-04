using Persistencia.DAL.Cadastros;
using Modelo.Cadastros;
using System.Linq;

namespace Servico.Cadastros
{
    public class CadastroServico
    {
        private CadastroDAL cadastroDAL = new CadastroDAL();

        public IQueryable ObterCadastrosClassificadosPorNome()
        {
            return cadastroDAL.ObterCadastrosClassificadosPorNome();
        }

        public Cadastro ObterCadastroPorId(long id)
        {
            return cadastroDAL.ObterCadastroPorId(id);
        }

        public void GravarCadastro(Cadastro cadastro)
        {
            cadastroDAL.GravarCadastro(cadastro);
        }

        public Cadastro EliminarCadastroPorId(long id)
        {
            return cadastroDAL.EliminarCadastroPorId(id);
        }
    }
}
