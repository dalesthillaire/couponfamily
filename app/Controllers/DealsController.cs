using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using app.Models;
using app.Models.Security;
using app.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace app.Controllers
{
    [Authorize]
    public class DealsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly INotificationService _notificationService;
        private readonly UserManager<AppUser> _userManager;
        private readonly DealService _dealService;
        private readonly SubScriptionService _subscriptionService;
       

        public DealsController(
            IMapper mapper,
            INotificationService notificationService,
            ApplicationDbContext context,
            UserManager<AppUser> userManager
           )
        {
            _mapper = mapper;
            _notificationService = notificationService;
            _userManager = userManager;
            _dealService = new DealService(context);
            _subscriptionService = new SubScriptionService(context);
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                //get the current user
                var currentUser = await _userManager.GetUserAsync(Request.HttpContext.User);
                var result = _dealService.GetAll();

                if (currentUser.IsBusinessUser)
                {
                    var userId = currentUser?.Id;
                    result = result.Where(x => x.Creator.Id == userId).ToList();
                }

                var viewModel = _mapper.Map<List<DealViewModel>>(result);
                foreach (var model in viewModel)
                {
                    model.City = currentUser?.City;
                    model.State = currentUser?.State;
                    model.Zip = currentUser?.Zip;
                    model.StreetAddress = currentUser?.StreetAddress;
                    model.Phone = currentUser?.PhoneNumber;
                    model.BusinessId = currentUser?.Id;
                }
                return View(viewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
         
        }

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
        public async Task<IActionResult> Create(DealViewModel viewModel)
        {
            if (!ModelState.IsValid) return View();
            var model = _mapper.Map<Deal>(viewModel);

            try
            {
                //get the current user
                var currentUser = await _userManager.GetUserAsync(Request.HttpContext.User);
                model.Creator = currentUser;

                //save the deal
                var result = _dealService.CreateDeal(model);

                //get the customers who are subscribed to the business
                var subscription = _subscriptionService.GetAll().FirstOrDefault(x => x.Business.Id == result.Creator.Id);
                if (subscription == null) return RedirectToAction(nameof(Index));
                {
                    //get all the phone numbers for the customers subscribed to the buiness who created the deal
                    var customerPhoneNumbers = subscription.Customers.Select(x => x.PhoneNumber).ToList();
                    //call the notification service
                    _notificationService.SendMessage(customerPhoneNumbers, model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                throw ex;
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