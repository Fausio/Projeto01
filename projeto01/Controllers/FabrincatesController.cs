using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projeto01.Context;
using Projeto01.Models;

namespace Projeto01.Controllers
{
    public class FabrincatesController : Controller
    {
        EFContext context = new EFContext();

        // GET: Fabrincates
        public ActionResult Index()
        {
            return View(context.fabricantes.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fabricante fabricante)
        {
            if (ModelState.IsValid)
            {
                context.fabricantes.Add(fabricante);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(fabricante);
            }

        }

        public ActionResult Edit(long? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (context.fabricantes.Find(Id) == null)
            {
                return HttpNotFound();
            }
            return View(context.fabricantes.Find(Id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fabricante fabricante)
        {
            if (ModelState.IsValid)
            {
                context.Entry(fabricante).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(fabricante);
            }

        }

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (context.fabricantes.Find(id) == null)
            {
                return HttpNotFound();
            }

            return View(context.fabricantes.Find(id));

        }

        public ActionResult Delete(long? id)
        {


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            if (context.fabricantes.Find(id) == null)
            {
                return HttpNotFound();
            }

            return View(context.fabricantes.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Fabricante fabricante)
        {


            context.fabricantes.Remove(context.fabricantes.Find(fabricante.FabricanteID));
            context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}