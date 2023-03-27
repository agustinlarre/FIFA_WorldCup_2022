using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Obligatorio_Web.Controllers
{
    public class PartidoController : Controller
    {
        Sistema s = Sistema.Instancia();

        // IActionResult que envia a la vista la lista de partidos, asi como un metodo que nos indica si hay partidos finalizados
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("Id") != null)
            {
                ViewBag.Contador = s.PartidosFinalizados();
                return View(s.GetPartidos());
            }
            return RedirectToAction("Index", "Home");
        }

        //IActionResult (get) que envia a la vista del buscador de partidos
        [HttpGet]
        public IActionResult Buscar()
        {
            if (HttpContext.Session.GetString("Tipo") == "Operador")
            {
                return View();
            }
                return RedirectToAction("Index", "Home");
        }

        //IActionResult (post) que devuelve a la vista la lista de partidos finalizados entre dos fechas
        [HttpPost]
        public IActionResult Buscar(DateTime fecha1, DateTime fecha2)
        {
            List<Partido> listaFiltrada = s.GetPartidos(fecha1, fecha2);
            
            return View(listaFiltrada);
        }
    }
}
