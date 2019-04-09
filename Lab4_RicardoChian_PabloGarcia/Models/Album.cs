using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4_RicardoChian_PabloGarcia.Models
{
    public class Album
    {
        public Dictionary<string, Equipo> equipos {get; set; }
        public Dictionary<string, Jugador> general {get; set;}
    }
}