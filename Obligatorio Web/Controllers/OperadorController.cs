using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Obligatorio_Web.Controllers
{
    public class OperadorController : Controller
    {
        Sistema s = Sistema.Instancia();

        // IActionResult que muestra la vista de estadisticas (solo la tabla para seleccionr las opciones de estadisticas)
        public IActionResult Estadisticas()
        {
            if (HttpContext.Session.GetString("Tipo") == "Operador")
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

    }
}
