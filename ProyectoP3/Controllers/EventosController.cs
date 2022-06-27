using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using ProyectoP3.Servicio;
using ProyectoP3.Models;
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace ProyectoP3.Controllers
{
    public class EventoController : Controller
    {
        IConfiguration config;
        private EventoServicio evento;

        public EventoController(IConfiguration config)
        {
            this.config = config;
            string ConnectionString = config.GetConnectionString("Reality First");
            evento = new EventoServicio(ConnectionString);

        }

        public IActionResult Eventos(int id)
        {
            IList<EventosModels> lista = evento.GetAll(id);
            return View("Eventos", lista);
        }
    }
}