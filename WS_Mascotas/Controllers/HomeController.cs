using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WS_Mascotas.Models;
using WS_Mascotas.Models.Base;
using WS_Mascotas.Models.Request;
using WS_Mascotas.Services;

namespace WS_Mascotas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IUsuarioService _user;

        public HomeController(ILogger<HomeController> logger, IUsuarioService user)
        {
            _logger = logger;
            _user = user;
        }

        public IActionResult Index()
        {            
            Agregar nuevo = new Agregar
            {
                FirstName = "Ismael",
                lastName = "Torres",
                CellPhone = "123456781",
                Date = DateTime.Now,                
            };

            _user.Add(nuevo);

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