using Modelo.Carrinho;
using Servicos.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projeto01.Areas.Carrinho.Controllers
{
    
    public class CarrinhosController : Controller
    {

        private ProdutoServico produtoServico = new ProdutoServico();
        // GET: Carrinho/Carrinhos
        public ActionResult Create()
        {

            //inicia recuperando uma variável chamada carrinho da sessão existente no contexto da requisição HTTP.
            IEnumerable<ItemCarrinho> carrinho = HttpContext.Session["carrinho"] as IEnumerable<ItemCarrinho>;


            //Caso a variável seja nula, significa que está ocorrendo a primeira requisição do
            //cliente para esta action / visão, o que leva, então, a criação da variável na sessão,  antes de retorná-la.
            if (carrinho == null)
            {
                carrinho = new List<ItemCarrinho>();
                HttpContext.Session["carrinho"] = carrinho;
            }
            return View(carrinho);
        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult AddProduto(FormCollection collection)
        {
            List<ItemCarrinho> carrinho = HttpContext.Session["carrinho"] as List<ItemCarrinho>;

            var produto = produtoServico.ObterProdutoPorId(Convert.ToInt32(collection.Get("idproduto")));
            var itemCarrinho = new ItemCarrinho()
            {
                Produto = produto,
                Quantidade = 1,
                ValorUnitario = produto.ValorUnitario
            };
            carrinho.Add(itemCarrinho);
            HttpContext.Session["carrinho"] = carrinho;
            return PartialView("_ItensCarrinho", carrinho);
        }
    }
}