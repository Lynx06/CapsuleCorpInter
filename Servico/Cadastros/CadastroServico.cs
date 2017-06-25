using Persistencia.DAL.Cadastros;
using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico.Cadastros
{
    public class CadastroServico
    {
        private CadastroDAL cadastroDAL = new CadastroDAL();
        public IQueryable ObterProdutosClassificadosPorNome()
        {
            return cadastroDAL.ObterProdutosClassificadosPorNome();
        }
        public Cadastro ObterProdutoPorId(long id)
        {
            return cadastroDAL.ObterProdutoPorId(id);
        }
        public void GravarProduto(Cadastro produto)
        {
            cadastroDAL.GravarProduto(produto);
        }
        public Cadastro EliminarProdutoPorId(long id)
        {
            return cadastroDAL.EliminarProdutoPorId(id);
        }
    }
}
