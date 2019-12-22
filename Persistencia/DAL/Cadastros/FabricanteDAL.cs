using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Cadastros;
using Persistencia.Contexts;

namespace Persistencia.DAL.Cadastros
{
    public class FabricanteDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Fabricante> ObterFabricantesClassificadosPorNome()
        {
            return context.fabricantes.OrderBy(b => b.Nome);
        }

        public void GravarFabricantes(Fabricante fabricante)
        {
            if (fabricante.FabricanteID == null)
            {
                context.fabricantes.Add(fabricante);
            }
            else
            {
                context.Entry(fabricante).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Fabricante ObterFabricanteID(long? id)
        {
            return context.fabricantes.Where(f => f.FabricanteID==id).Include("Produtos.Categoria").First();
        }


        public Fabricante deletarFabricante(Fabricante fabricante)
        {
            var f = context.fabricantes.Find(fabricante.FabricanteID);
            context.fabricantes.Remove(f);
            context.SaveChanges();

            return f;
        }
    }
}
