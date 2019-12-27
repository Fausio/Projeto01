using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Cadastros;

namespace Modelo.Carrinho
{
   public class ItemCarrinho
    {
        public long? ItemCarrinhoId { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public double ValorUnitario { get; set; }

        public double SubTotal
        {
            get
            {
                return Quantidade * ValorUnitario;
            }
        }
    }
}
