using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using System.Diagnostics;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //a estos metodos se le llaman acciones - quiere decir que un controlador tiene una o varias acciones
        public IActionResult Index()
        {
            //ViewBag no es un modelo fuertemente tipado
            //ViewBag.Nombre = "Jorge Carlos Diestra Diestra";


            //Creamos un modelo fuertemente tipado utilizando @model en la descripcion de la vista y recibimos el @Model esto servira para acceder al valor 
            //var persona = new Persona
            //{
            //    Nombre = "Jorge Diestra (didijoca)",
            //    Edad = 15
            //};
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}