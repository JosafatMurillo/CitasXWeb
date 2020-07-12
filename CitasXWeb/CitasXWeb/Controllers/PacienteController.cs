using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CitasXWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace CitasXWeb.Controllers
{
    public class PacienteController : Controller
    {
        public IActionResult AgendarCita()
        {
            if ((TempData["usuario_rol"] as int?) != null)
            {
                if ((TempData["usuario"] as int?) == 3 || (TempData["usuario"] as int?) == 1)
                {
                    TempData.Keep();
                    return View();
                }
            }
            return RedirectToAction("Login", "Home");
        }
    }
}