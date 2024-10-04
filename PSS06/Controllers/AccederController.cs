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
                // Usa FirstOrDefault para obtener el primer resultado coincidente o null si no existe
                var user = db.USERS.FirstOrDefault(d => d.Email == usuario
                                                        && d.Password == password
                                                        && d.idEstatus == 1);
                if (user != null)
                {
                    // Creamos la sesión con el usuario logueado
                    Session["Usuario"] = user;
                    return Content("1");  // Retornamos el valor a la vista
                }
                else
                {
                    return Content("Usuario no existe :(");
                }
            }
        }

    }
}