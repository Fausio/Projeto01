using Modelo.Carrinho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projeto01.Areas.Carrinho.Controllers
{
    public class CarrinhosController : Controller
    {
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
    }
}