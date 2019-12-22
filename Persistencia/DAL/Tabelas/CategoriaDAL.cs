using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Tabelas;
using Persistencia.Contexts;

namespace Persistencia.DAL.Tabelas
{
    public class CategoriaDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Categoria> ObterCategoriasClassificadasPorNome()
        {
            return context.categorias.OrderBy(b => b.Nome);
        }

        public void GravarCategoria(Categoria categoria)
        {
            if (categoria.CategoriaId == null)
            {
                context.categorias.Add(categoria);
                 
            }
            else
            {
                context.Entry(categoria).State = EntityState.Modified;
               
            }
            context.SaveChanges();

        }

        public Categoria FindCategoriaById(long? id)
        {
            return context.categorias.Where(x => x.CategoriaId == id).Include("Produtos.Fabricante").First();
        }

        public Categoria RemoveCategoria(long? id)
        {
            var c = this.FindCategoriaById(id);
            context.categorias.Remove(c);
            context.SaveChanges();
            return c;
        }
    }
}
