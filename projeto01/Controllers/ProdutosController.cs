
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelo.Cadastros;
using Modelo.Tabelas;
using System.Data.Entity;
using System.Net;
using Servicos.Cadastros;
using Servicos.Tabelas;

namespace projeto01.Controllers
{
    public class ProdutosController : Controller
    {
        // GET: Produtos

        private ProdutoServico produtoServico = new ProdutoServico();
        private FabricanteServico fabricanteServico = new FabricanteServico();
        private CategoriaServico categoriaServico = new CategoriaServico();

        public ActionResult Index()
        {
            return View(produtoServico.ObterProdutosClassificadosPorNome());
        }

        public ActionResult Create()
        {
            PopularViewBag();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Produto produto)
        {
            return GravarProduto(produto);
        }

        public ActionResult Edit(long id)
        {
            PopularViewBag(produtoServico.ObterProdutoPorId(id));
            return ObterVisaoProdutoPorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Produto produto)
        {
            return GravarProduto(produto);
        }


        public ActionResult Details(long id)
        {
            return ObterVisaoProdutoPorId(id);
        }

        public ActionResult Delete(long? id)
        {
            return ObterVisaoProdutoPorId(id);
        }

        // POST: Produtos/Delete/5
        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                Produto produto = produtoServico.EliminarProdutoPorId(id);
                TempData["Message"] = "Produto " + produto.Nome.ToUpper() + " foi removido";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        private ActionResult ObterVisaoProdutoPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Produto produto = produtoServico.ObterProdutoPorId((long)id);

            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }




        //Veja que, na assinatura do método, o parâmetro produto é
        //opcional.E quando ele não existir, é atribuído null a ele.Isso foi
        //adotado para podermos diferenciar quando o quarto parâmetro do
        //SelectList() será informado.
        private void PopularViewBag(Produto produto = null)
        {
            if (produto == null)
            {
                ViewBag.CategoriaId = new SelectList(categoriaServico.ObterCategoriasClassificadasPorNome(), "CategoriaId", "Nome");
                ViewBag.FabricanteId = new SelectList(fabricanteServico.ObterFabricantesClassificadosPorNome(), "FabricanteId", "Nome");
            }
            else
            {
                ViewBag.CategoriaId = new SelectList(categoriaServico.ObterCategoriasClassificadasPorNome(), "CategoriaId", "Nome", produto.CategoriaId);
                ViewBag.FabricanteId = new SelectList(fabricanteServico.ObterFabricantesClassificadosPorNome(), "FabricanteId", "Nome", produto.FabricanteId);
            }
        }


        private ActionResult GravarProduto(Produto produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    produtoServico.GravarProduto(produto);
                    return RedirectToAction("Index");
                }
                return View(produto);
            }
            catch
            {
                return View(produto);
            }
        }
    }
}