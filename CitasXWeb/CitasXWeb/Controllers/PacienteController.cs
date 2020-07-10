using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CitasXWeb.Controllers
{
    public class PacienteController : Controller
    {
        public IActionResult AgendarCita()
        {
            return View();
        }
    }
}