﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4_RicardoChian_PabloGarcia.Models
{
    public class Jugador
    {
        public string Nombre {get; set;}
        public bool Obtenida {get; set;}
        public int Repetida {get; set;}

        public Jugador(string nombre)
        {
            Nombre = nombre;
            Obtenida = false;
            Repetida = 0;
        }
    }
}