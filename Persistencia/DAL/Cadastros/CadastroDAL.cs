using Persistencia.Contexts;
using System.Linq;
using System.Data.Entity;
using Modelo.Cadastros;

namespace Persistencia.DAL.Cadastros
{
    public class CadastroDAL
    {
        private EFContext context = new EFContext();

        public IQueryable ObterProdutosClassificadosPorNome()
        {
            return context.Cadastros.Include(c => c.Cobertura).
                            Include(f => f.Cliente).OrderBy(n => n.Nome);
        }
        public Cadastro ObterProdutoPorId(long id)
        {
            return context.Cadastros.Where(p => p.CadastroId == id).
                            Include(c => c.Cobertura).Include(f =>
                         f.Cliente).First();
        }
        public void GravarProduto(Cadastro cadastro)
        {
            if (cadastro.CadastroId == null)
            {
                context.Cadastros.Add(cadastro);
            }
            else
            {
                context.Entry(cadastro).State =
                                EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Cadastro EliminarProdutoPorId(long id)
        {
            Cadastro cadastro = ObterProdutoPorId(id);
            context.Cadastros.Remove(cadastro);
            context.SaveChanges();
            return cadastro;
        }
    }
}
