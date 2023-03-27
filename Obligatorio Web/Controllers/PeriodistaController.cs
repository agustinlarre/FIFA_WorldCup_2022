using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Obligatorio_Web.Controllers
{
    public class PeriodistaController : Controller
    {
        Sistema s = Sistema.Instancia();

        //IActionResult que envia a la vista Index la lista de periodistas
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Tipo") == "Operador")
            {
                return View(s.GetPeriodistas());
            }
            return RedirectToAction("Index", "Home");
        }

        // IActionResult (get) que envia a la vista para registrar un nuevo periodista
        public IActionResult Create()
        {
            if (HttpContext.Session.GetInt32("Id") == null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        // IActionResult (post) que da de alta al periodista si los datos fueron correctos ye nvia a la vista el mensaje correspondiente
        [HttpPost]
        public IActionResult Create(Periodista p)
        {
            try
            {
                s.AltaUsuario(p);
                ViewBag.msg = "Periodista creado correctamente";
            }
            catch (Exception e)
            {
                ViewBag.msg = e.Message;
            }
            return View();
        }


    }
}
