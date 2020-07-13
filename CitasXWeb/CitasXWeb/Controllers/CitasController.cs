using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CitasXWeb.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CitasXWeb.Controllers
{
    [Route("api/[controller]")]
    public class CitasController : Controller
    {

        CitasXContext _context = new CitasXContext();

        // GET api/<controller>/5
        [Route("/General/Cita")]
        [HttpPost]
        [Produces("application/json")]
        public Boolean Login([FromForm] TbCita cita)
        {
            _context.TbCita.Add(cita);
            var confirmar = _context.SaveChanges();

            if (confirmar > 0)
            {
                ViewBag.registroCita = true;
                return true;
            }
            ViewBag.registroCita = false;
            return false;
        }

        public IActionResult cancelarRegistroCita()
        {
            return View();
        }
    }
}
