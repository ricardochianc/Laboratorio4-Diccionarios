using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4_RicardoChian_PabloGarcia.Models
{
    public class Album
    {
        public Dictionary<string, Equipo> Equipos = new Dictionary<string, Equipo>();
        public Dictionary<string, Jugador> General = new Dictionary<string, Jugador>();

        public Album()
        {

        }
    }
}