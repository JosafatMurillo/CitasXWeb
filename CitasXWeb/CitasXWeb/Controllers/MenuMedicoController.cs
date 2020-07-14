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
    public class MenuMedicoController : Controller
    {
        CitasXContext _context = new CitasXContext();

        [Route("/Medico/ObtenerCitas")]
        [Produces("application/json")]
        [HttpPost]
        public List<TbCita> obtenerCitasFecha([FromForm]DateTime fecha)
        {
            List<TbCita> citas = _context.TbCita.Where(c => c.CitFecha.Equals(fecha) && c.CitEstado.Equals(1)).OrderBy(c => c.CitHora).ToList(); //El estado 1 de la cita hace referencia a que está agendada
            ViewBag.citas = citas;
            return citas;
        }

        [Route("/Medico/EditarCita")]
        [HttpPost]
        public Boolean EditarCita([FromForm]TbCita cita, DateTime fecha, string hora)
        {
            cita.CitEstado = 3; //Es el indice del estado referente a Editado
            _context.TbCita.Update(cita);

            TbCita citanueva = new TbCita();
            citanueva = cita;
            citanueva.CitFecha = fecha;
            citanueva.CitHora = hora;

            _context.TbCita.Add(citanueva);

            var confirmacion = _context.SaveChanges();
            
            if (confirmacion > 0)
            {
                ViewBag.editarCita = true;
                return true;
            }
            ViewBag.editarCita = false;
            return false;
        }

        public IActionResult cancelarEdicion()
        {
            return View();
        }

        [Route("/Medico/EditarCita")]
        [HttpPost]
        public Boolean EliminarCita([FromForm]TbCita cita)
        {
            cita.CitEstado = 4; //Es el indice del estado referente a Elimnada
            _context.TbCita.Update(cita);

            var confirmacion = _context.SaveChanges();

            if (confirmacion > 0)
            {
                ViewBag.eliminarCita = true;
                return true;
            }
            ViewBag.eliminarCita = false;
            return false;
        }


        [Route("/Medico/ObtenerHistorial")]
        [Produces("application/json")]
        [HttpPost]
        public List<TbHistorialMedico> ObtenerHistorialMedico([FromForm] string CURP)
        {
            List<TbHistorialMedico> historial = _context.TbHistorialMedico.Where(h => h.HisPaciente.Equals(CURP)).OrderBy(h => h.HisFecha).ToList();
            ViewBag.historialMedico = historial;
            return historial;
        }


        [Route("/Medico/RegistrarConsulta")]
        [Produces("application/json")]
        [HttpPost]
        public Boolean RegistrarConsulta([FromForm] TbHistorialMedico consulta)
        {
            _context.TbHistorialMedico.Add(consulta);
            var confirmacion = _context.SaveChanges();

            if (confirmacion > 0)
            {
                ViewBag.registrarConsulta = true;
                return true;
            }
            ViewBag.registrarConsulta = false;
            return false;
        }
    }
}
