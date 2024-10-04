using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PSS06.Models;

namespace PSS06.Controllers
{
    public class AccederController : Controller
    {
        // GET: Acceder
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Enter(string usuario, string password)
        {
            using (DBMVCSCEntities db = new DBMVCSCEntities())
            {
                var read = from d in db.USERS
                           where d.Email == usuario
                           && d.Password == password
                           && d.idEstatus == 1
                           select d;
                if (read.Count() > 0)
                {
                    Session["Usuario"] = read.First();  // creamos la sesion con el usuario logueado
                    return Content("1");  // retornamos el valor a las vista
                }
                else
                {
                    return Content("Usuario no existe :(");
                }
            }
        }
    }
}