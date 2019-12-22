using Modelo.Cadastros;
using Modelo.Tabelas;
using Persistencia.DAL.Tabelas;
using System.Linq;

namespace Servicos.Tabelas
{
    public class CategoriaServico
    {
        private CategoriaDAL categoriaDAL = new CategoriaDAL();
        public IQueryable<Categoria> ObterCategoriasClassificadasPorNome()
        {
            return categoriaDAL.ObterCategoriasClassificadasPorNome();
        }

        public void GravarCategoria(Categoria categoria)
        {
            categoriaDAL.GravarCategoria(categoria);
        }

        public Categoria FindCategoriaById(long? id)
        {
            return categoriaDAL.FindCategoriaById(id);
        }

        public Categoria RemoveCategoria(long? id)
        {
            return categoriaDAL.RemoveCategoria(id);
        }
    }
}