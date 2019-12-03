using System;
using System.Collections.Generic;
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
            return View(context.categorias.Where(x => x.CategoriaId == id).First());
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
        {
            return View(context.categorias.Where(x => x.CategoriaId == id).First());
        }

        public ActionResult Delete(long id)
        {
            return View(context.categorias.Where(x => x.CategoriaId == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Categoria categoria)
        {

            context.categorias.Remove(context.categorias.Where(x => x.CategoriaId == categoria.CategoriaId).First());
            context.SaveChanges();
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