using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab4_RicardoChian_PabloGarcia.Declaradores;
using Lab4_RicardoChian_PabloGarcia.Models;

namespace Lab4_RicardoChian_PabloGarcia.Controllers
{
    public class AlbumController : Controller
    {
        // GET: Album
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VerEquipos()
        {
            return View(Data.Instance.AlbumUCL.Equipos.Values);
        }

        public ActionResult DetailsEquipo(string id)
        {

            return View(Data.Instance.AlbumUCL.Equipos[id].Jugadores);
        }

        public ActionResult EditarJugador(string id)
        {
            return View(Data.Instance.AlbumUCL.General[id]);
        }

        [HttpPost]
        public ActionResult EditarJugador(string id,FormCollection collection)
        {
            bool obtenida = false;

            var aux = collection["check"];
            
            if (aux == "si" || aux == "Si" || aux == "SI")
            {
                obtenida = true;
            }
            else
            {
                obtenida = false;
            }

            
            var repetida = int.Parse(collection["Repetida"]);

            Data.Instance.AlbumUCL.General[id].Obtenida = obtenida;
            Data.Instance.AlbumUCL.General[id].Repetida = repetida;

            Predicate<Jugador> BuscadorJugador = (Jugador jugador) => { return jugador.Nombre == id; };

            foreach (var item in Data.Instance.AlbumUCL.Equipos)
            {
                try
                {
                    item.Value.Jugadores.Find(BuscadorJugador).Obtenida = obtenida;
                    item.Value.Jugadores.Find(BuscadorJugador).Repetida = repetida;

                    var name = item.Key;

                    Data.Instance.AlbumUCL.Equipos[name].Calcular();
                }
                catch (Exception e)
                {
                    
                }
            }


            return RedirectToAction("VerEquipos");
        }


        public ActionResult VerGeneral()
        {
            return View(Data.Instance.AlbumUCL.General.Values);
        }

        public ActionResult DetallesGeneral(string id)
        {
            var ID = id;
            return RedirectToAction("EditarJugador","Album",new {id = ID});
        }
    }
}
