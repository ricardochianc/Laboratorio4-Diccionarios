using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4_RicardoChian_PabloGarcia.Models
{
    public class Equipo
    {
        public string NombreEquipo {get;set;}
        public List<Jugador> Jugadores {get; set;}

        public Equipo(string nombreEquipo, List<string> players)
        {
            NombreEquipo = nombreEquipo;
            Jugadores = new List<Jugador>(25);

            for(int i = 0; i < 25; i++)
            {
                var j = new Jugador(NombreEquipo + (i+1));
                Jugadores.Add(j);
            }

            foreach(var item in players)
            {
                var nombre = NombreEquipo+item;

                for(int i = 0; i<Jugadores.Count; i++)
                {
                    if(Jugadores[i].Nombre == nombre)
                    {
                        if(Jugadores[i].Obtenida == true)
                        {
                            Jugadores[i].Repetida++;
                        }
                        else
                        {
                            Jugadores[i].Obtenida = true;
                        }

                    }
                }
            }
        }
    }
}