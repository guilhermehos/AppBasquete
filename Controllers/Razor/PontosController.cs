using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AppDemo
{
    public class PontosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
