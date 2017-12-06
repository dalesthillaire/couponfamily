using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using app.Models;
using Microsoft.AspNetCore.Authorization;

namespace app.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
      
    }
}
