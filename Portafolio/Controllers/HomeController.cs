using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using Portafolio.Servicios;
using System.Diagnostics;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioProyectos responsabilidadUnica;
        private readonly ServicioDelimitado servicioDelimitado;
        private readonly ServicioTransitorio servicioTransitorio;
        private readonly ServicioUnico servicioUnico;

        private readonly ServicioDelimitado servicioDelimitado2;
        private readonly ServicioTransitorio servicioTransitorio2;
        private readonly ServicioUnico servicioUnico2;
        private readonly IConfiguration configuration;
        private readonly IServicioEmail servicioEmail;

        public HomeController(ILogger<HomeController> logger, IRepositorioProyectos responsabilidadUnica,
            ServicioDelimitado servicioDelimitado,
            ServicioTransitorio servicioTransitorio,
            ServicioUnico servicioUnico,

            ServicioDelimitado servicioDelimitado2,
            ServicioTransitorio servicioTransitorio2,
            ServicioUnico servicioUnico2,
            IConfiguration configuration,
            IServicioEmail servicioEmail)
        {
            //principios de responsabilidad unica - Inyeccion de dependencia
            _logger = logger;
            this.responsabilidadUnica = responsabilidadUnica;
            this.servicioDelimitado = servicioDelimitado;
            this.servicioTransitorio = servicioTransitorio;
            this.servicioUnico = servicioUnico;
            this.servicioDelimitado2 = servicioDelimitado2;
            this.servicioTransitorio2 = servicioTransitorio2;
            this.servicioUnico2 = servicioUnico2;
            this.configuration = configuration;
            this.servicioEmail = servicioEmail;
        }

        //a estos metodos se le llaman acciones - quiere decir que un controlador tiene una o varias acciones
        public IActionResult Index()
        {
            var apellido = configuration.GetValue<string>("Apellido");
            _logger.LogTrace("Este es un mensaje de Trace");
            _logger.LogDebug("Este es un mensaje de Debug");
            _logger.LogInformation("Este es un mensaje de Information");
            _logger.LogWarning("Este es un mensaje de Warning");
            _logger.LogError("Este es un mensaje de Error");
            _logger.LogCritical("Este es un mensaje de Critical " + apellido);
            //ViewBag no es un modelo fuertemente tipado
            //ViewBag.Nombre = "Jorge Carlos Diestra Diestra";


            //Creamos un modelo fuertemente tipado utilizando @model en la descripcion de la vista y recibimos el @Model esto servira para acceder al valor 
            //var persona = new Persona
            //{
            //    Nombre = "Jorge Diestra (didijoca)",
            //    Edad = 15
            //};

            var proyectos = responsabilidadUnica.ObtenerProyectos().Take(3).ToList();
            var GUIDViewModel = new EjemploGUIDViewModel() {
                Delimitado = servicioDelimitado.ObtenerGuid,
                Transitorio = servicioTransitorio.ObtenerGuid,
                Unico = servicioUnico.ObtenerGuid
            };

            var GUIDViewModel2 = new EjemploGUIDViewModel()
            {
                Delimitado = servicioDelimitado2.ObtenerGuid,
                Transitorio = servicioTransitorio2.ObtenerGuid,
                Unico = servicioUnico2.ObtenerGuid
            };
            var modelo = new HomeIndexViewModel() {
                Proyectos = proyectos,
                EjemploGUID_1 = GUIDViewModel,
                EjemploGUID_2 = GUIDViewModel2,
            };
            return View(modelo);
        }
        public IActionResult Proyectos()
        {
            var proyectos = responsabilidadUnica.ObtenerProyectos();
            return View(proyectos);
        }
        [HttpGet]
        public IActionResult Contacto()
        { 
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Contacto(ContactoViewModel contactoViewModel)
        {
            await servicioEmail.Enviar(contactoViewModel);
            return RedirectToAction("Gracias");
        }

        [HttpGet]
        public IActionResult Gracias()
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