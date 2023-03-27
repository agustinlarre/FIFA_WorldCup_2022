using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Obligatorio_Web.Models;

namespace Obligatorio_Web.Controllers
{
    public class HomeController : Controller
    {
        Sistema s = Sistema.Instancia();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // ActionResult que envia a la vista el usuario logueado para luego tomar sus datos
        public IActionResult Index()
        {
            int? idRecuperado = HttpContext.Session.GetInt32("Id");
            ViewBag.User = s.GetUsuario(idRecuperado);
            return View();
        }

        // ActionResult (get) que muestra la vista de login a los usuarios anonimos 
        public IActionResult Login()
        {
            if (HttpContext.Session.GetInt32("Id") == null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");

        }

        // ActionResult (post) que verifica los datos de acceso y envia a la vista correspondiente
        [HttpPost]
        public IActionResult Login(string emailUsuario, string passwordUsuario)
        {
            Usuario usuarioLogueado = s.LogueoUsuario(emailUsuario, passwordUsuario);

            if (usuarioLogueado != null)
            {
                HttpContext.Session.SetInt32("Id", usuarioLogueado.Id);
                HttpContext.Session.SetString("Tipo", usuarioLogueado.GetTipo());
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Msg = "Datos incorrectos. Intente nuevamente.";
            }
            return View();
        }

        // IActionResult(get) que envia a la vista para cerrar sesion
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetInt32("Id") != null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        // IActionResult (post) que verifica el checkBox, y en caso de ser true, envia a la vista correspondiente luego de cerrar sesion.
        [HttpPost]
        public IActionResult Logout(bool CierreChequeado)
        {
            if (CierreChequeado)
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.msg = "Usted no ha cerrado Sesión";
            }
            return View();

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
