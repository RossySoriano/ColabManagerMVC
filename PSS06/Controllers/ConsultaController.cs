using PSS06.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PSS06.Controllers
{
    public class ConsultaController : Controller
    {
        private DBMVCSCEntities db = new DBMVCSCEntities(); // Asegúrate de que DBMVCSCEntities esté bien configurado

        // GET: Consulta
        public ActionResult Index()
        {
            var colaboradores = db.LabColaboradors.ToList();
            return View(colaboradores);
        }
    }
}