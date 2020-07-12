using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CitasXWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace CitasXWeb.Controllers
{
    public class MedicoController : Controller
    {
        public IActionResult Dash()
        {
            TempData["navbar"] = "~/Views/Shared/_NavBarMedico.cshtml";
            if ((TempData["usuario"] as int?) != null)
            {
                if ((TempData["usuario"] as int?) == 2)
                {
                    TempData.Keep();
                    return View();
                }
            }
            return RedirectToAction("Login", "Home");
        }
    }
}