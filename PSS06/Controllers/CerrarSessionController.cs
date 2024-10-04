using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PSS06.Controllers
{
    public class CerrarSessionController : Controller
    {
        // GET: CerrarSession
        public ActionResult Logoff()
        {
            Session["Usuario"] = null;  // cerramos la sesion 
            return RedirectToAction("Login", "Acceder");  // redireccionamos hacia la vista login
        }
    }
}