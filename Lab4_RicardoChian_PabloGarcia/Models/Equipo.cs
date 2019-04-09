using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4_RicardoChian_PabloGarcia.Models
{
    public class Equipo
    {
        public string NombreEquipo {get;set;}
        public List<Jugador> jugadores {get; set;}
    }
}