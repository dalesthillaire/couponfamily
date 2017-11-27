using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using app.Models;


namespace app.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "Account main page.";
            return View();
        }

        public IActionResult Create()
        {
            ViewData["Message"] = "Create Account on this page.";

            return View();
        }

        public IActionResult Detail()
        {
            ViewData["Message"] = "Account Detail on this page.";

            return View();
        }

        public IActionResult Deals()
        {
            ViewData["Message"] = "Account Deals page.";

            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
