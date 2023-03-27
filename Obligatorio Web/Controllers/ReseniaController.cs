using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Obligatorio_Web.Controllers
{
    public class ReseniaController : Controller
    {
        Sistema s = Sistema.Instancia();

        // IactionResult que envia a la vista las reseñas de un determinado periodista
        // Verifica que sea periodista, y también si la lista de reseñas esta vacia o no
        public IActionResult Index()
        {
            int? idR = HttpContext.Session.GetInt32("Id");
            Usuario usuarioR = s.GetUsuario(idR);
            if (usuarioR != null)
            {
                if (HttpContext.Session.GetString("Tipo") == "Periodista")
                {
                    ViewBag.User = usuarioR;
                    string rol = HttpContext.Session.GetString("Tipo");
                    ViewBag.ListaVacia = s.ListaVaciaPeriodista((Periodista)usuarioR);
                    if (rol == "Periodista")
                    {
                        return View(s.GetResenias());
                    }
                }
            }
            return RedirectToAction("Index", "Home");
        }

        // IActionResult (get) que envia a la vista para que el peridoista realice una reseña
        [HttpGet]
        public IActionResult Create(int partidoId)
        {
            string rol = HttpContext.Session.GetString("Tipo");
            if (rol == "Periodista")
            {
                Partido partidoRes = s.GetPartido(partidoId);
                ViewBag.ElPartido = partidoRes;
                return View();
            }
                return RedirectToAction("Index", "Home");
        }

        // IActionResult (post) que obtiene los datos de la reseña, la da de alta en el sistema y envia mensaje a la vista
        [HttpPost]
        public IActionResult Create(int partidoId, string unTitulo, string unContenido)
        {
              Partido partidoR = s.GetPartido(partidoId);
              ViewBag.ElPartido = partidoR;
              int? idR = HttpContext.Session.GetInt32("Id");
              Usuario usuarioR = s.GetUsuario(idR);

              Resenia res = new Resenia();

              res.UnPartido = partidoR;
              res.UnPeriodista = usuarioR as Periodista;
              res.Fecha = DateTime.Now;
              res.Titulo = unTitulo;
              res.Contenido = unContenido;

              try
              {
                  s.AltaResenia(res);
                  ViewBag.Msg = "Datos guardados correctamente";
              }
              catch (Exception ex)
              {
                  ViewBag.Msg = ex.Message;
              }

              return View();
        }

        // IActionResult que envia a la vista los detalles de una reseña determinada
        public IActionResult Details(int id)
        {
            string rol = HttpContext.Session.GetString("Tipo");
            if (rol == "Periodista")
            {
                Resenia reseniaR = s.GetResenia(id);
                return View(reseniaR);
            }
                return RedirectToAction("Index", "Home");
        }

        // IActionResult (get) que envía a la vista del buscador de reseñas de partidos con tarjeta roja de un periodista 
        public IActionResult Estadisticas()
        {
            if (HttpContext.Session.GetString("Tipo") == "Operador")
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        // IActionResult (post) que obtiene el email del periodista y retorna las reseñas de ese periodista de partidos con tarjeta roja 
        [HttpPost]
        public IActionResult Estadisticas(string emailPeriodista)
        {
            List<Resenia> listaRes = s.GetReseniaPeriodistas(emailPeriodista);
            Usuario unPeriodista = s.GetUsuarioPorEmail(emailPeriodista);
            if (unPeriodista == null)
            {
                ViewBag.msg = "Periodista inexistente";
            }
            else if (listaRes.Count() == 0)
            {
                ViewBag.msg = "No hay partidos con tarjeta roja reseñados";
            }
            return View(listaRes);
        }

        // IActionResult que envía a la vista de reseñas de un determinado periodista
        public IActionResult FiltroPeriodista(int id) 
        {
            if (HttpContext.Session.GetString("Tipo") == "Operador")
            {
                List<Resenia> listaRes = s.GetReseniasUnPeriodista(id);
                Usuario unUsuario = s.GetUsuario(id);
                ViewBag.Nombre = unUsuario.Nombre;
                return View(listaRes);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}

