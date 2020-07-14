using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CitasXWeb.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CitasXWeb.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {

        CitasXContext _context = new CitasXContext();

        // GET api/<controller>/5
        [Route("/Home/Login")]
        [HttpPost]
        [Produces("application/json")]
        public TbUsuario Login([FromForm] string identificador, [FromForm] string contrasenia)
        {
            var usuario = _context.TbUsuario.Where(u => u.UsuIdentificador.Equals(identificador) && u.UsuContrasenia.Equals(contrasenia)).First();
            ViewBag.usuario = usuario;

            return usuario;
        }

        public IActionResult redireccionLogin(TbUsuario usuario)
        {
            if (usuario.UsuRol == 1)
            {
                return View(/*medico*/);
            } else if (usuario.UsuRol == 2)
            {
                return View(/*recepcionista*/);
            } else {
                return View(/*paciente*/);
            }
        }
    }
}
