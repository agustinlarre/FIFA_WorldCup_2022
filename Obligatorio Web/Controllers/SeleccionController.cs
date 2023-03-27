using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Obligatorio_Web.Controllers
{
    public class SeleccionController : Controller
    {
        Sistema s = Sistema.Instancia();

        // IActionResult que envia todas las selecciones a la vista
        public IActionResult Index()
        {
            string tipoUsuario = HttpContext.Session.GetString("Tipo");

            if (tipoUsuario != "Periodista")
            {
                return View(s.GetSelecciones());
            }

            return RedirectToAction("Index", "Home");

        }
        
        // IActionResult que envía a la vista la o las selecciones con mas goles
        public IActionResult Estadisticas()
        {
            if (HttpContext.Session.GetString("Tipo") == "Operador")
            {
                List<Seleccion> sel = s.SeleccionConMasGoles();
                return View(sel);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
