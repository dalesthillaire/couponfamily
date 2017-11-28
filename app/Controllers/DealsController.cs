using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using app.Models;
using app.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace app.Controllers
{
    [Authorize]
    public class DealsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly DealService _dealService;

        public DealsController(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _dealService = new DealService(context);
        }
        public IActionResult Index()
        {
           var result = _dealService.GetAll();
           var viewModel = _mapper.Map<List<DealViewModel>>(result);

            return View(viewModel);
        }

        public IActionResult Browse()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }
        
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
