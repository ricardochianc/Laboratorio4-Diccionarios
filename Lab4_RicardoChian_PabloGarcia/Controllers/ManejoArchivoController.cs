﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Lab4_RicardoChian_PabloGarcia.Declaradores;
using Lab4_RicardoChian_PabloGarcia.Models;

namespace Lab4_RicardoChian_PabloGarcia.Controllers
{
    public class ManejoArchivoController : Controller
    {
        public ActionResult CargarArchivo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CargarArchivo(HttpPostedFileBase postedFile)
        {
            var FilePath = string.Empty;

            if (postedFile != null)
            {
                var path = Server.MapPath("~/CargaCSV/");

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                FilePath = path + Path.GetFileName(postedFile.FileName);

                postedFile.SaveAs(FilePath);

                var CsvData = System.IO.File.ReadAllText(FilePath);

                foreach (var fila in CsvData.Split('\n'))
                {
                    fila.Trim();

                    if (!string.IsNullOrEmpty(fila))
                    {
                        var linea = fila.Split(',');
                        var listaJugadores = new List<string>();

                        foreach (var num in linea)
                        {
                            int No;

                            if (int.TryParse(num, out No))
                            {
                                listaJugadores.Add(num);
                            }
                        }
                        var equipo = new Equipo(linea[0],linea[1],listaJugadores);
                        equipo.Calcular();
                        Data.Instance.AlbumUCL.Equipos.Add(equipo.NombreEquipo,equipo);
                    }
                }
                
                System.IO.File.Delete(FilePath);
                Directory.Delete(path);
            }
            
            return RedirectToAction("Index","Album");
        }
    }
}
