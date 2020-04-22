using DiarioPolitico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiarioPolitico.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            if (Session["user"] == null)
                return RedirectToAction("Login", "Usuarios");

            Usuario a = (Usuario)Session["user"];
            ViewBag.saludo = a.nombre;
            return View();
        }

        public ActionResult About()
        {

            if (Session["user"] == null)
                return RedirectToAction("Login", "Usuarios");

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {

            if (Session["user"] == null)
                return RedirectToAction("Login", "Usuarios");

            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}