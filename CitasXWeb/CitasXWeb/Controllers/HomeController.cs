using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CitasXWeb.Models;

namespace CitasXWeb.Controllers
{
    public class HomeController : Controller
    {
        Dictionary<String, String> listaNavBar = null;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Registro()
        {
            if((TempData["usuario_rol"] as int?) != null)
            {
                if((TempData["usuario"] as int?) == 1)
                {
                    TempData.Keep();
                    return View();
                }
            }

            return View("Login");
        }

        [HttpPost]
        public ActionResult IniciarSesion(String username, String contrasena)
        {
            if(username == null || contrasena == null)
            {
                return View("Login");
            }

            var contexto = new CitasXContext();
            var usuario = contexto.TbUsuario.FirstOrDefault(p => p.UsuIdentificador.Equals(username) && p.UsuContrasenia.Equals(contrasena));

            listaNavBar = new Dictionary<String, String>();

            if (usuario == null)
            {
                return View("Login");
            }
            else
            {
                TempData["usuario"] = usuario.UsuId;
                TempData["usuario_rol"] = usuario.UsuRol;
                return IniciarComoRecepcionista(usuario.UsuRol);
            }
        }

        public ActionResult IniciarComoRecepcionista(int? rol)
        {
            if (rol == 1)
            {
                TempData["navbar"] = "~/Views/Shared/_NavBarRecepcionista.cshtml";

                return View("Index");
            }
            else
            {
                return IniciarComoMedico(rol);
            }
        }

        public ActionResult IniciarComoMedico(int? rol)
        {
            if(rol == 2)
            {
                return RedirectToAction("Dash", "Medico");
            }
            else 
            {
                return IniciarComoPaciente(rol);
            }
        }

        public ActionResult IniciarComoPaciente(int? rol)
        {
            TempData["navbar"] = "~/Views/Shared/_NavBarPaciente.cshtml";

            return View("Index");
        }

        public IActionResult CerrarSesion()
        {
            TempData["usuario"] = null;
            TempData["usuario_rol"] = null;
            TempData["navbar"] = "~/Views/Shared/_NavMenu.cshtml";
            return View("Index");
        }
    }
}
