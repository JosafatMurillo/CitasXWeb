using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CitasXWeb.Models;
using System.Net;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace CitasXWeb.Controllers
{
    public class HomeController : Controller
    {

        private static String url = "http://localhost:50665";

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

        [Route("/Home/IniciarSesion")]
        [HttpPost]
        public ActionResult IniciarSesion(String username, String contrasena)
        {
            if (username == null || contrasena == null)
            {
                return View("Login");
            }

            var request = (HttpWebRequest)WebRequest.Create(url + "/Home/Login");
            var postData = $"identificador={username}&contrasenia={contrasena}";
            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using(var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                var usuario = JsonConvert.DeserializeObject<TbUsuario>(responseString);

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
