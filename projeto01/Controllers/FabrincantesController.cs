using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Persistencia.Contexts;
using Servicos.Cadastros;
using Modelo.Cadastros;

namespace Projeto01.Controllers
{
    public class FabrincatesController : Controller
    {
        FabricanteServico FabricanteServico = new FabricanteServico();

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

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var fabricante = context.fabricantes.Where(f => f.FabricanteID == id).Include("Produtos.Categoria").First();
            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
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
            var fabricante = context.fabricantes.Where(f => f.FabricanteID == id).Include("Produtos.Categoria").First();
            if (fabricante == null)
            {
                return HttpNotFound();
            }

            return View(fabricante);

        }

        public ActionResult Delete(long? id)
        {


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            var fabricante = context.fabricantes.Where(f => f.FabricanteID == id).Include("Produtos.Categoria").First();
            if (fabricante == null)
            {
                return HttpNotFound();
            }

            return View(fabricante);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Fabricante fabricante)
        {
            var fabricante_ = context.fabricantes.Find(fabricante.FabricanteID);

            context.fabricantes.Remove(fabricante_);
            context.SaveChanges();

            // mensagem para levar a view dele apos ser deletado um  fabricante da base de dados 
            TempData["Message"] = "Fabricante " + fabricante_.Nome.ToUpper() + " foi removido com sucesso.";
            return RedirectToAction("Index");

        }

        public void GravarFabricante(Fabricante fabricante)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    
                }
            }
            catch (Exception)
            {

                throw;
            }
           
        } 

    }

}