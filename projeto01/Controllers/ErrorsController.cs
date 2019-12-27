using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projeto01.Controllers
{
    public class ErrorsController : Controller
    {
        // GET: Errors
        public ActionResult General()
        {
            return View();
        }
        public ActionResult Http400()
        {
            return View();
        }
        public ActionResult Http404()
        {
            return View();
        }
    }
}