using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using app.Models;
using app.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace app.Controllers
{
    public class DealsController : Controller
    {
        // GET: Deal

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


        // GET: Deal/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: Deal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Deal/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Deal/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        // POST: Deal/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Deal/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: Deal/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}