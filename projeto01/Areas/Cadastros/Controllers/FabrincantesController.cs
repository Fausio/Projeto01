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

namespace Projeto01.Areas.Cadastros.Controllers
{
    public class FabrincatesController : Controller
    {
        FabricanteServico FabricanteServico = new FabricanteServico();

        // GET: Fabrincates
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(FabricanteServico.ObterFabricantesClassificadosPorNome());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fabricante fabricante)
        {
            return GravarFabricante(fabricante);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(long id)
        {
            return retornaproduto(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fabricante fabricante)
        {
            return GravarFabricante(fabricante);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Details(long  id)
        {
            return retornaproduto(id);

        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(long? id)
        {
           return retornaproduto(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Fabricante fabricante)
        {
           var f = FabricanteServico.deletarFabricante(fabricante);

            // mensagem para levar a view dele apos ser deletado um  fabricante da base de dados 
            TempData["Message"] = "Fabricante " + f.Nome.ToUpper() + " foi removido com sucesso.";
            return RedirectToAction("Index");

        }

        private ActionResult GravarFabricante(Fabricante fabricante)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    FabricanteServico.GravarFabricante(fabricante);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(fabricante);
                }
            }
            catch (Exception)
            {

                return View(fabricante);
            }

        }

        public ActionResult retornaproduto(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var fabricante = FabricanteServico.ObterFabricanteID(id);
            if (fabricante == null)
            {
                return HttpNotFound();
            }

            return View(fabricante);

        }

    }

}