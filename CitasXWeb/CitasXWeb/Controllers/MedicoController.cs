using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CitasXWeb.Controllers
{
    public class MedicoController : Controller
    {
        public IActionResult Dash()
        {
            return View();
        }
    }
}