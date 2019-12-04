using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projeto01.Models
{
    public class Produto
    {
        public long? ProdutoId { get; set; }
        public string Nome { get; set; }

        public long? CategoriaId { get; set; }
        public long? FabricanteId { get; set; }

        public Projeto01.Models.Categoria Categoria { get; set; }
        public Projeto01.Models.Fabricante Fabricante { get; set; }
    }
}