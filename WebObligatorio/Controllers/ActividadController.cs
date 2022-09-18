using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Http;

namespace WebObligatorio.Controllers
{
    public class ActividadController : Controller
    {
        //Instanciar el sistema
        Administradora sistema = Administradora.Instancia;

        //Accion del controlador para mostrar Lista de actividades
        public IActionResult ListaActividades(string mensaje)
        {
            //Controlar el acceso de usuario
            if (HttpContext.Session.GetString("rol") == "operador")
            {
                return Redirect("/usuario/operadorIndex");
            }
            ViewBag.Mensaje = mensaje;
            ViewBag.Actividades = sistema.Actividades;
            return View();
        }
        //Accion del controlador para filtrar actividades 
        public IActionResult FiltrarActividades()
        {
            //Controlar el acceso de usuario
            if (HttpContext.Session.GetString("rol") == "cliente")
            {
                return Redirect("/usuario/clienteIndex");
            }
            if (HttpContext.Session.GetString("rol") == null)
            {
                return Redirect("/usuario/anonimoIndex");
            }
            ViewBag.Categorias = sistema.Categorias;
            return View();
        }
        //Accion del controlador para filtrar actividades - Adquirir datos
        [HttpPost]
        public IActionResult FiltrarActividades(int idCategoria, DateTime desde, DateTime hasta)
        {
            //Controlar el acceso de usuario
            if (HttpContext.Session.GetString("rol") == "cliente")
            {
                return Redirect("/usuario/clienteIndex");
            }
            if (HttpContext.Session.GetString("rol") == null)
            {
                return Redirect("/usuario/anonimoIndex");
            }
            List<Actividad> listaActividades = sistema.ListarActividadesPorFechaYCategoria(idCategoria, desde, hasta);

            if(idCategoria >= 0)
            {
                if (listaActividades.Count > 0)
                {
                    ViewBag.Actividades = listaActividades;
                    ViewBag.Mensaje = null;
                }
                else
                {
                    ViewBag.Actividades = null;
                    ViewBag.Mensaje = "No hay actividades con las especificaciones marcadas";
                }
            }
            else
            {
                ViewBag.Mensaje = "Debe seleccionar una categoría.";
            }
            ViewBag.Categorias = sistema.Categorias;
            return View();
        }
       //Accion del controlador para agregar Me gusta a una actividad - NO TIENE VISTA solo se hace referencia en el HTML con a href 
        public IActionResult MeGusta(int idActividad)
        {
            //Control acceso de usuario  
            if (HttpContext.Session.GetString("rol") == "operador")
            {
                return Redirect("/usuario/operadorIndex");
            }
            if (HttpContext.Session.GetString("rol") == null)
            {
                return Redirect("/usuario/anonimoIndex");
            }
            sistema.BuscarActividadYAgregarMegusta(idActividad);
            return RedirectToAction("ListaActividades");
        }
        //Accion del controlador para listar las activades por lugar , en envia la lista de lugares disponibles - vista previa al form
        public IActionResult ListaActividadesPorLugar()
        {
            //Control acceso de usuario
            if (HttpContext.Session.GetString("rol") == "cliente")
            {
                return Redirect("/usuario/clienteIndex");
            }
            if (HttpContext.Session.GetString("rol") == null)
            {
                return Redirect("/usuario/anonimoIndex");
            }
            ViewBag.Lugares = sistema.Lugares;
            return View();
        }
        //Accion del controlador para listar las activades por lugar , adquiriendo la id del lugar
        [HttpPost]
        public IActionResult ListaActividadesPorLugar(int idLugar)
        {
            //Control acceso de usuario
            if (HttpContext.Session.GetString("rol") == "cliente")
            {
                return Redirect("/usuario/clienteIndex");
            }
            if (HttpContext.Session.GetString("rol") == null)
            {
                return Redirect("/usuario/anonimoIndex");
            }
            if (idLugar >= 0)
            {
                ViewBag.ListaActividadesPorLugar = sistema.ActividadesPorLugar(idLugar);
            }
            else
            {
                ViewBag.Mensaje = "Debe seleccionar un Lugar.";
            }
            ViewBag.Lugares = sistema.Lugares;
            return View();
        }
    }
}
