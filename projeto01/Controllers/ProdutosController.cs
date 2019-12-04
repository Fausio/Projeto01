using Projeto01.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projeto01.Models;

namespace projeto01.Controllers
{
    public class ProdutosController : Controller
    {
        // GET: Produtos

        EFContext context = new EFContext();
        public ActionResult Index()
        {
            return View(context.Produtos.Include("Categoria").Include("Fabricante").ToList());
        }

        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(context.categorias.OrderBy(b => b.Nome), "CategoriaId", "Nome");
            ViewBag.FabricanteId = new SelectList(context.fabricantes.OrderBy(b => b.Nome), "FabricanteId", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Produto produto)
        {
            if (ModelState.IsValid)
            {
                context.Produtos.Add(produto);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(produto);
            }
        }

        public ActionResult Edit(long id)
        {
            return View(context.Produtos.Include("Categoria").Include("Fabricante").Where(p => p.ProdutoId==id));
        }
    }
}