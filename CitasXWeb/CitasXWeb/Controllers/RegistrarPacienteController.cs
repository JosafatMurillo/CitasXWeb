using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CitasXWeb.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CitasXWeb.Controllers
{
    [Route("api/[controller]")]
    public class RegistrarPacienteController : Controller
    {
        CitasXContext _context = new CitasXContext();

        [Route("/Personal/Registro")]
        [Produces("application/json")]
        [HttpPost]
        public Boolean RegistrarPaciente([FromForm] TbPaciente paciente)
        {
            _context.TbPaciente.Add(paciente);
            var confirmar = _context.SaveChanges();

            if(confirmar > 0)
            {
                ViewBag.registroPaciente = true;
                return true;
            }
            ViewBag.registroPaciente = false;
            return false;
        }

        public IActionResult cancelarRegistro()
        {
            return View();
        }
    }
}
