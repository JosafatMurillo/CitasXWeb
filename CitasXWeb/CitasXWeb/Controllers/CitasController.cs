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
        public Boolean AgendarCita([FromForm] TbCita cita)
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

        // GET api/<controller>/5
        [Route("/General/HorasCita")]
        [HttpPost]
        [Produces("application/json")]
        public String[] HorasDisponibles([FromForm] DateTime fecha)
        {
            String[] horas = { "9:00", "9:30", "10:00", "10:30", "11:00", "11:30", "12:00", "12:30", "13:00", "13:30", "14:00", "14:30", "15:00", "15:30" };

            List<TbCita> citas = _context.TbCita.Where(c => c.CitFecha.Equals(fecha)).OrderBy(c => c.CitHora).ToList();

            //Rangos de horario es de 9 am a 3 pm - con una duración de la cita de 30 min
            for (int i = 0; i < citas.Count(); i++)
            {
                var horarioV = citas.ElementAt(i).CitHora;
                for (int tiempo = 0; tiempo < horas.Count(); tiempo++)
                {
                    if(horas[tiempo] == horarioV)
                    {
                        horas = horas.Where(val => val != horarioV).ToArray();
                        break;
                    }
                }
            }

            return horas;
        }

        public IActionResult cancelarRegistroCita()
        {
            return View();
        }
    }
}
