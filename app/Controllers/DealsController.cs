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
        private readonly IMapper _mapper;
        private readonly DealService _dealService;
        private readonly SubScriptionService _subscriptionService;
        private readonly NotificationService _notificationService;

        public DealsController(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _dealService = new DealService(context);
            _subscriptionService = new SubScriptionService(context);
            _notificationService = new NotificationService();
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

        public ActionResult Browse()
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
               var deal = new Deal();
               //to do: populate deal model from form collection

                //save the deal
               var result = _dealService.CreateDeal(deal);

               //get the customers who are subscribed to the business
               var subscription = _subscriptionService.GetAll().FirstOrDefault(x => x.Business.Id == result.Creator.Id);
                if (subscription == null) return RedirectToAction(nameof(Index));
                {
                    //get all the phone numbers for the customers subscribed to the buiness who created the deal
                    var customerPhoneNumbers = subscription.Customers.Select(x => x.PhoneNumber).ToList();
                    //call the notification service
                    _notificationService.SendMessage(customerPhoneNumbers, deal);
                }
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