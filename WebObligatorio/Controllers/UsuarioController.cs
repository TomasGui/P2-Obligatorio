using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Http;


namespace WebObligatorio.Controllers
{
    public class UsuarioController : Controller
    {
        //Instanciar el sistema
        Administradora sistema = Administradora.Instancia;
        //Accion del controlador para el acceso al sistema LOGIN - enviar la vista
        public IActionResult Login(string mensaje)
        {
            //Controlar el acceso de usuario
            if (HttpContext.Session.GetString("rol") == "cliente")
            {
                return Redirect("/usuario/clienteIndex");
            }
            if (HttpContext.Session.GetString("rol") == "operador")
            {
                return Redirect("/usuario/operadorIndex");
            }
            ViewBag.MensajeExito = mensaje;
            return View();
        }
        //Accion del controlador para el acceso al sistema LOGIN - adquirir infomacion de la vista
        [HttpPost]
        public IActionResult Login(string usuario, string password)
        {
            //Controlar el acceso de usuario
            if (HttpContext.Session.GetString("rol") == "cliente")
            {
                return Redirect("/usuario/clienteIndex");
            }
            if (HttpContext.Session.GetString("rol") == "operador")
            {
                return Redirect("/usuario/operadorIndex");
            }
            if (sistema.ValidarUsuario(usuario))
            {
                if (sistema.ValidarPasswordUsuario(usuario, password))
                {
                    Usuario uS = sistema.ObtenerUsuario(usuario);
                    //Adquirir la infomacion del usuario para dejar sus valores en la sesion
                    HttpContext.Session.SetString("nombre", uS.Nombre);
                    HttpContext.Session.SetString("rol", uS.Rol);
                    HttpContext.Session.SetInt32("id", uS.Id);
                    //Control de acceso de usuario a partir del ROL
                    if (HttpContext.Session.GetString("rol") == "cliente")
                    {
                        return Redirect("/usuario/clienteIndex");
                    }
                    if ((HttpContext.Session.GetString("rol") == "operador"))
                    { 
                        return Redirect("/usuario/operadorIndex");
                    }
                }
                else
                {
                    ViewBag.MensajeError = "Password incorrecto";
                }
            }
            else
            {
                ViewBag.MensajeError = "Usuario no valido";
            }
            return View();
        }
        //Accion del controlador para cerrar la sesion - No tiene vista se hace referencia por medio del menu
        public IActionResult Logout()
        {
            //Control acceso de usuario
            if (HttpContext.Session.GetString("rol") == null)
            {
                return Redirect("/usuario/anonimoIndex");
            }
            HttpContext.Session.Clear();
            return RedirectToAction("anonimoIndex");
        }
        //Accion del controlador para registrarse en el sistema , genera la vista. 
        public IActionResult Create()
        {
            //Control acceso de usuario
            if (HttpContext.Session.GetString("rol") == "cliente")
            {
                return Redirect("/usuario/clienteIndex");
            }
            if (HttpContext.Session.GetString("rol") == "operador")
            {
                return Redirect("/usuario/operadorIndex");
            }
            return View(new Usuario());
        }
        //Accion del controlador para registrarse en el sistema , adquirir informacion del sistema 
        [HttpPost]
        public IActionResult Create(Usuario nuevoUsuario)
        {
            //Control acceso de usuario
            if (HttpContext.Session.GetString("rol") == "cliente")
            {
                return Redirect("/usuario/clienteIndex");
            }
            if (HttpContext.Session.GetString("rol") == "operador")
            {
                return Redirect("/usuario/operadorIndex");
            }

            if (!sistema.BuscarEmail(nuevoUsuario.Email))
            {
                if (!sistema.ValidarUsuario(nuevoUsuario.NombreUsuario))
                {
                    if (Usuario.ValidarPassword(nuevoUsuario.Password))
                    {
                        if (sistema.ValidarYCargarUsuarios(nuevoUsuario))
                        {
                            return RedirectToAction("login", new { mensaje = "Se dio de alta en forma correcta" });
                        }
                    }
                    else
                    {
                        ViewBag.Mensaje = "Password incorrecto ,debe contener al menos una mayúscula, una minúscula y un dígito";
                    }
                }
                else
                {
                    ViewBag.Mensaje = "El usuario ya existe ";
                }
            }
            else
            {
                ViewBag.Mensaje = "Ya existe e-mail";
            }

            return View(nuevoUsuario);
        }
        //Accion del controlador para mostrar los usuarios ordenados en el sistema
        public IActionResult ListaUsuarios()
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
            ViewBag.Clientes = sistema.UsuariosOrdenadosPorNombre();
            return View();
        }
        //Accion del controlador para controlar la vista principal del Usuario Cliente
        public IActionResult OperadorIndex()
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
        //Accion del controlador para controlar la vista principal del Usuario operador
        public IActionResult ClienteIndex()
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
            return View();
        }
        //Accion del controlador para controlar la vista principal del Usuario anonimo - BIENVENIDA general
        public IActionResult AnonimoIndex()
        {
            //Control acceso de usuario
            if (HttpContext.Session.GetString("rol") == "cliente")
            {
                return Redirect("/usuario/clienteIndex");
            }
            if (HttpContext.Session.GetString("rol") == "operador")
            {
                return Redirect("/usuario/operadorIndex");
            }
            return View();
        }
    }
}
