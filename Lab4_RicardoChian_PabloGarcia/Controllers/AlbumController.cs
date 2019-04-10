using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab4_RicardoChian_PabloGarcia.Declaradores;

namespace Lab4_RicardoChian_PabloGarcia.Controllers
{
    public class AlbumController : Controller
    {
        // GET: Album
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MostrarDatosEquipo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MostrarDatosEquipo(int i)
        {
            return View();
        }

    }
}
