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
    [Route("login")]
    public class LoginController : Controller
    {

        CitasXContext _context = new CitasXContext();

        // GET api/<controller>/5
        [HttpGet]
        public async Task<IActionResult> Login([FromBody] string identificador, [FromBody] string contrasenia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuario = _context.TbUsuario.FirstOrDefault(u => u.UsuIdentificador.Equals(identificador) && u.UsuContrasenia.Equals(contrasenia));

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }
    }
}
