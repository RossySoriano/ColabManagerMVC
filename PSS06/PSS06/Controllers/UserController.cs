using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PSS06.Models;
using PSS06.Models.ViewModels;

namespace PSS06.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult Query()
        {
            List<QueryViewModels> lst = null;

            using (DBMVCSCEntities db = new DBMVCSCEntities())
            {
                // SELECT * FROM USERS WHERE IDESTATUS = 1 ORDER BY EMAIL

                lst = (from d in db.USERS
                       where d.idEstatus == 1
                       orderby d.Email

                       select new QueryViewModels
                       {
                           _Email = d.Email,
                           _Edad = d.Edad,
                           _Id = d.ID
                       }).ToList();
            }

            return View(lst);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(AddViewModel model)
        {
            // valida que la digitada este correcta
            if (!ModelState.IsValid)
            {
                return View(model);  // retorna a la vista si la condicion es false
            }

            using (var db =new DBMVCSCEntities())
            {
                USER oUser = new USER();  // abrimos la tabla en modo de insertar

                // le pasamos la data del modelo a las columnas de tabla y es recibida en el contenedor oUser
                oUser.idEstatus = 1;
                oUser.Email = model.Email;
                oUser.Nombre = model.Nombre;
                oUser.Edad = model.Edad;
                oUser.Password = model.Password;

                db.USERS.Add(oUser);   // esta data solo esta en memoria aun no esta guardada en el disco
                db.SaveChanges();  // guarda la data en la tabla
            }

            return Redirect(Url.Content("~/User/Query"));  // redirecciona hacia la consulta
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            EditViewModel model = new EditViewModel();

            using (var db = new DBMVCSCEntities())
            {
                var oUser = db.USERS.Find(Id);

                model.Edad = oUser.Edad;
                model.Email = oUser.Email;
                model.Password = oUser.Password;
                model.Id = oUser.ID;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditViewModel model)
        {
            using (var db = new DBMVCSCEntities())
            {
                var oUser = db.USERS.Find(model.Id);

                oUser.Edad = model.Edad;
                oUser.Email = model.Email;

                if (model.Password !=null || model.Password != "")
                {
                    oUser.Password = model.Password;
                }

                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/User/Query"));
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            using (var db = new DBMVCSCEntities())
            {
                var oUser = db.USERS.Find(Id);

                oUser.idEstatus = 3;

                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Content("1");
        }
    }
}