using Modelo.Cadastros;
using Persistencia.DAL.Cadastros;
using System.Linq;


namespace Servicos.Cadastros
{
    public class FabricanteServico
    {
        private FabricanteDAL fabricanteDAL = new FabricanteDAL();

        public IQueryable<Fabricante> ObterFabricantesClassificadosPorNome()
        {
            return fabricanteDAL.ObterFabricantesClassificadosPorNome();
        }

        public void GravarFabricante(Fabricante fabricante)
        {
            fabricanteDAL.GravarFabricantes(fabricante);
        }

        public Fabricante ObterFabricanteID(long? id)
        {
            return fabricanteDAL.ObterFabricanteID(id);
        }

        public Fabricante deletarFabricante(Fabricante fabricante  )
        {
          return  fabricanteDAL.deletarFabricante(fabricante);
        }
    }
}