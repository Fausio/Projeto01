using Projeto01.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projeto01.Models;
using System.Data.Entity;
using System.Net;

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
            var Produto_ = context.Produtos.Find(id);
            ViewBag.CategoriaId = new SelectList(context.categorias.OrderBy(b => b.Nome), "CategoriaId", "Nome", Produto_.CategoriaId);
            ViewBag.FabricanteId = new SelectList(context.fabricantes.OrderBy(b => b.Nome), "FabricanteId", "Nome", Produto_.FabricanteId);
            return View(Produto_);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Produto produto)
        {
            context.Produtos.Add(produto);
            context.SaveChanges();
            return RedirectToAction("index");
        }


        public ActionResult Details(long id)
        {
            Produto produto = context.Produtos.Where(p => p.ProdutoId == id).Include(c => c.Categoria).Include(f => f.Fabricante).First();
            return View(produto);
        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = context.Produtos.Where(p => p.ProdutoId == id).Include(c => c.Categoria).Include(f => f.Fabricante).First();
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }
    }
}