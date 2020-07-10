using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CitasXWeb.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CitasXWeb.Controllers
{
    [Route("registrarPaciente")]
    public class RegistrarPacienteController : Controller
    {
        CitasXContext _context = new CitasXContext();

        // GET api/<controller>/5
        [HttpPost]
        public async Task<IActionResult> RegistrarPaciente([FromBody] TbUsuario paciente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var usuario = new TbUsuario();

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }
    }
}
