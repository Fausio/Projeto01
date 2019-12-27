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
        public ActionResult Index()
        {
            return View();
        }
    }
}