using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Obligatorio_Web.Controllers
{
    public class GruposController : Controller
    {
        Sistema s = Sistema.Instancia();

        // ActionResult que envia a la vista la lista de partidos 
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("Id") != null)
            {
                return View(s.GetPartidos());
            }
            return RedirectToAction("Index", "Home");
        }

        // Metodo get para cerrar partido de grupos
        [HttpGet]
        public IActionResult Close(int partidoId)
        {
            if (HttpContext.Session.GetString("Tipo") == "Operador")
            {
                FaseDeGrupos partidoBuscado = s.GetGrupos(partidoId);
                return View(partidoBuscado);
            }
            return RedirectToAction("Index", "Home");
        }

        // Metodo post para cerrar partido de grupos
        [HttpPost]
        public IActionResult Close(bool chequeado, int partidoId)
        {
            FaseDeGrupos partidoBuscado = s.GetGrupos(partidoId);

            if (chequeado)
            {
                s.FinalizarPartido(partidoBuscado);
                ViewBag.Msg = "Partido cerrado correctamente!";
            }
            else
            {
                ViewBag.Msg = "Debe confirmar el cierre del partido.";
            }
            return View(partidoBuscado);
        }
    }
}