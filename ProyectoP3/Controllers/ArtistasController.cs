using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProyectoP3.Models;
using ProyectoP3.Servicio;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ProyectoP3.Controllers
{
    public class ArtistasController : Controller
    {
        IConfiguration config;
        ArtistaServicio artista;

        public ArtistasController(IConfiguration config)
        {
            this.config = config;
            string ConnectionString = config.GetConnectionString("Reality First");
            artista = new ArtistaServicio(ConnectionString);
        }
        public IActionResult Index()
        {
            IList<ArtistasModels> lista = artista.GetAll();
            return View("index", lista);
        }

        public IActionResult Artista()
        {
            IList<ArtistasModels> lista = artista.GetAll();
            return View("Artista", lista);
        }
        
        public IActionResult Ficha_Artista(int id)
        {
            ArtistasModels obj_artista = artista.Get(id);
            return View(obj_artista);
        }

    }
}