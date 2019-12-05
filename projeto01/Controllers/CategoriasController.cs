using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto01.Context;
using Projeto01.Models;

namespace Projeto01.Controllers
{
    public class CategoriasController : Controller
    {
        EFContext context = new EFContext();
        // GET: Fabricantes
        public ActionResult Index()
        {

            return View(context.categorias.ToList());
        }

        public ActionResult Edit(long id)
        {
            return View(context.categorias.Where(x => x.CategoriaId == id).Include("Produtos.Fabricante").First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {

            if (ModelState.IsValid)
            {
                context.Entry(categoria).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("categoria");
            }
        }

        public ActionResult Details(long id)
        {                                                                          /* aqui no include escrevemos o nome do produto do context nao do modelo*/
            return View(context.categorias.Where(x => x.CategoriaId == id).Include("Produtos.Fabricante").First());
        }

        public ActionResult Delete(long id)
        {
            return View(context.categorias.Where(x => x.CategoriaId == id).Include("Produtos.Fabricante").First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Categoria categoria)
        {
            var categoria_ = context.categorias.Where(x => x.CategoriaId == categoria.CategoriaId).First();
            context.categorias.Remove(categoria_);
            context.SaveChanges();

            TempData["Message"] = "Categoria " + categoria_.Nome + " removida com sucesso";
            return RedirectToAction("Index");

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                context.categorias.Add(categoria);
                context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(categoria);
        }

    }
}