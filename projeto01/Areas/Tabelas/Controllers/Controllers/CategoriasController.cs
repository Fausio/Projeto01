using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Servicos.Tabelas;
using Modelo.Cadastros;
using Modelo.Tabelas;

namespace Projeto01.Areas.Tabelas.Controllers
{
    public class CategoriasController : Controller
    {
        CategoriaServico CategoriaServico = new CategoriaServico();
        // GET: Fabricantes

        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {

            return View(CategoriaServico.ObterCategoriasClassificadasPorNome());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(long id)
        {
            return View(CategoriaServico.FindCategoriaById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {

            return this.GravarCategoria(categoria);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Details(long id)
        {
            #region   /* aqui no include escrevemos o nome do produto do context nao do modelo*/
            //return View(context.categorias.Where(x => x.CategoriaId == id).Include("Produtos.Fabricante").First());
            #endregion

            return View(CategoriaServico.FindCategoriaById(id));
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(long id)
        {
            return View(CategoriaServico.FindCategoriaById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Categoria categoria)
        {
            var c = CategoriaServico.FindCategoriaById(categoria.CategoriaId);
            CategoriaServico.RemoveCategoria(c.CategoriaId);
            
            TempData["Message"] = "Categoria " + c.Nome + " removida com sucesso";
            return RedirectToAction("Index");

        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            return this.GravarCategoria(categoria);
        }

        public ActionResult GravarCategoria(Categoria categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CategoriaServico.GravarCategoria(categoria);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(categoria);
                }
            }
            catch (Exception)
            {

                return View(categoria);
            }
        }

    }
}