using System.Diagnostics;
using System.Threading.Tasks;
using app.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using app.Models.Security;
using Microsoft.WindowsAzure.Storage;


namespace app.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }
        // GET: /Account/Login
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (!ModelState.IsValid) return View(model);
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, set lockoutOnFailure: true
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToLocal(returnUrl);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
            }
        }
		
		 // GET: /Account/Detail
        [HttpGet]
        public IActionResult Detail()
        {
            return View();
        }
		
        // GET: /Account/Register
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async  Task<IActionResult> Register(CustomerRegistrationViewModel model)
        {
            if (!ModelState.IsValid) return View();
            var user = new AppUser()
            {
                Name = model.Name.Trim(),
                UserName = model.RegisterEmail.Trim(),
                Email = model.RegisterEmail.Trim(),
                IsBusinessUser = model.AccountType == "Business"
            };
            var result = await _userManager.CreateAsync(user, model.RegisterConfirmPassword);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, true);

                return user.IsBusinessUser
                    ? RedirectToAction("Register", "Account", new BusinessRegistrationViewModel())
                    : RedirectToAction("Index", "Deals");
            }
            else
            {
                AddErrors(result);
            }
            return RedirectToAction(nameof(Login), "Account");
        }

        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterBusiness(BusinessRegistrationViewModel model)
        {
            if (!ModelState.IsValid) return View("Register", model);
          
            //get the current user
            var currentUser = await _userManager.GetUserAsync(Request.HttpContext.User);
            currentUser.City = "D.C.";
            currentUser.State = model.State;
            currentUser.StreetAddress = model.StreetAddress;
            currentUser.Zip = model.Zip;
            currentUser.PhoneNumber = model.Phone;

            var result = await _userManager.UpdateAsync(currentUser);
            if (result.Succeeded) RedirectToAction("Index", "Deals");

            AddErrors(result);
            return RedirectToAction(nameof(Login), "Account");
        }
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logoff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login), "Account");
        }


        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Deals");
            }
        }
    }

}
