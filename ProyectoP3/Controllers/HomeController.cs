using Microsoft.AspNetCore.Mvc;
using ProyectoP3.Models;
using ProyectoP3.Servicio;
using System.Diagnostics;

namespace ProyectoP3.Controllers
{
    public class HomeController : Controller
    {
        IConfiguration config;
        ArtistaServicio artista;

        public HomeController(IConfiguration configuration)
        {
            this.config = configuration;
            string ConnectionString = config.GetConnectionString("Reality First");
            artista = new ArtistaServicio(ConnectionString);
        }

        public IActionResult Index()
        {
            IList<ArtistasModels> lista = artista.GetAll();
            return View("index", lista);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contacto()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModels { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}