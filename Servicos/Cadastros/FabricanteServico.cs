using Modelo.Cadastros;
using Persistencia.DAL.Cadastros;
using System.Linq;


namespace Servicos.Cadastros
{
    public class FabricanteServico
    {
        private FabricanteDAL fabricanteDAL = new FabricanteDAL();
        private 
        public IQueryable<Fabricante> ObterFabricantesClassificadosPorNome()
        {
            return fabricanteDAL.ObterFabricantesClassificadosPorNome();
        }



        public void GravarFabricante(Fabricante fabricante)
        {
            fabricanteDAL.GravarFabricantes(fabricante);
        }
    }
}