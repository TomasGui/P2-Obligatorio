using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Http;

namespace WebObligatorio.Controllers
{
    public class CompraController : Controller
    {
        Administradora sistema = Administradora.Instancia;
        //Accion del controlador que permite al usuario cliente realizar la compra de entradas para una actividad
        public IActionResult Compra(int idActividad)
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
            Actividad unaActividad = sistema.BuscarActividadId(idActividad);
            ViewBag.IdActividad = idActividad;
            ViewBag.NombreActividad = unaActividad.DevolverNombre();
            ViewBag.NombreCategoria = unaActividad.NombreCategoria();
            ViewBag.FechaYHora = unaActividad.DevolverFecha();
            ViewBag.Precio = unaActividad.PrecioActividad();
            return View();
        }
        //Recibe la id de la actividad y la cantidad de entradas para registrar la compra
        [HttpPost]
        public IActionResult Compra(int cantidadEntradas, int idActividad)
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
            Actividad actividadSelecionada = sistema.BuscarActividadId(idActividad);

            DateTime fechaSistema = DateTime.Now;

            Usuario usuarioSeleccionado = sistema.BuscarUsuarioId((int)HttpContext.Session.GetInt32("id"));

            Compra unaCompra = new Compra(actividadSelecionada, cantidadEntradas, usuarioSeleccionado, fechaSistema);

            if (sistema.ValidarYCargarCompra(unaCompra))
            {
                return Redirect("/Actividad/ListaActividades?mensaje=Compra Exitosa!");
            }

            ViewBag.Mensaje = "No fue posible realizar la compra , debe comprar al menos una entrada";

            ViewBag.IdActividad = idActividad;
            ViewBag.NombreActividad = actividadSelecionada.DevolverNombre();
            ViewBag.NombreCategoria = actividadSelecionada.NombreCategoria();
            ViewBag.FechaYHora = actividadSelecionada.DevolverFecha();
            ViewBag.Precio = actividadSelecionada.PrecioActividad();

            return View();
        }
        //Accion del controlador para devolver las compras realizadas por el usuario activo,
        //las mismas deben estar activas y la fecha de su actividad debe superar las 24 horas del dia actual
        public IActionResult Cancelar()
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
            ViewBag.Compras = sistema.ComprasActivasPorUsuario((int)HttpContext.Session.GetInt32("id"));
            return View();
        }
        //Accion del controlador para cambiar el estado de una compra seleccionada por el cliente
        public IActionResult CancelarId(int idCompra)
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
            Compra comp = sistema.ObtenerCompra(idCompra);
            if (comp.CambiarEstado(false))
            {
                ViewBag.Mensaje = "Se cancelo la compra correctamente.";
            }
            else
            {
                ViewBag.Mensaje = "No se pudo cancelar la compra.";
            }
            ViewBag.Compras = sistema.ComprasActivasPorUsuario((int)HttpContext.Session.GetInt32("id"));
            return View("cancelar");
        }
        //Accion del controlador para devolver todas las compras realizadas entre 2 fechas dadas por el operador
        public IActionResult FiltrarCompras()
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
            return View();
        }
        //Dadas las fechas seleccionadas, devuelve una lista de compras entre esas dos fechas
        [HttpPost]
        public IActionResult FiltrarCompras(DateTime desde, DateTime hasta)
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

            List<Compra> listaCompras = sistema.FiltroComprasPorFechas(desde.Date, hasta.Date);

            if (listaCompras.Count > 0)
            {
                ViewBag.Compras = listaCompras;
                ViewBag.Mensaje = null;
                ViewBag.TotalCompras = sistema.TotalComprasRealizadas(listaCompras);
            }
            else
            {
                ViewBag.Compras = null;
                ViewBag.TotalCompras = null;
                ViewBag.Mensaje = "No se han encontrado compras con las espeficicaciones marcadas";
            }
            return View();
        }
        //Accion del controlador para devolver todas las compras realizadas por el usuario activo
        public IActionResult ComprasUsuario()
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
            Usuario user = sistema.BuscarUsuarioId((int)HttpContext.Session.GetInt32("id"));
            List<Compra> listaCompras = sistema.ListarComprasPorUsuario(user);
            if (listaCompras.Count>0)
            {
                ViewBag.Compras = listaCompras;
            }
            else
            {
                ViewBag.Compras = null;
                ViewBag.Mensaje = "No posee compras para mostrar"; 
            }
            
            return View();
        }
        //Accion del cotrolador para devolver todas las compras con mayor valor
        public IActionResult CompraMayorValor()
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
            ViewBag.ComprasMayorValor = sistema.ComprasMayorValor();
            return View();
        }
    }
}
