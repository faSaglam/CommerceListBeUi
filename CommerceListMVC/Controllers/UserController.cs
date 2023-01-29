
using Business.Abstract;
using Business.Concreate;
using CommerceListMVC.Models;
using CommerceListMVC.Validators;
using Entities.Concreate;
using Entities.Concreate.ViewModels;
using Entitites.Concrete;
using Entitites.Concrete.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CommerceListMVC.Controllers
{
    public class UserController : Controller
    {
       private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<UserRole> _roleManager;
        public UserController(IUserService userService, UserManager<User> userManager,
            SignInManager<User> signInManager,RoleManager<UserRole> roleManager)
        {
            _userService = userService;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
    
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.Email,
                    PasswordHash = model.Password,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    

                };
                
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var userRole = _roleManager.FindByNameAsync("User").Result;
                    if(userRole != null)
                    {
                        IdentityResult roleResult = await _userManager.AddToRoleAsync(user, userRole.Name);
                    }
                    return RedirectToAction("Login");
                }
                result.Errors.ToList().ForEach(f => ModelState.AddModelError(string.Empty, f.Description));


            };

            return View(model);
        }
        public IActionResult Login(string returnUrl)
        {
            if(returnUrl !=null)
            {
                TempData["ReturnUrl"] = returnUrl;
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(viewModel.Email);
                if (user != null)
                {
                    await _signInManager.SignOutAsync(); // önceki oturumdan kalma user bilgileri
                    var result = await _signInManager.PasswordSignInAsync(user, viewModel.Password, viewModel.RememberMe, true);
                    if (result.Succeeded)
                    {
                        await _userManager.ResetAccessFailedCountAsync(user);
                        await _userManager.SetLockoutEndDateAsync(user, null);

                        var returnUrl = TempData["ReturnUrl"];
                        if (returnUrl != null)
                        {
                            return Redirect(returnUrl.ToString() ?? "/");

                        }
                        return RedirectToAction("List", "Product");
                    }
                    else if (result.IsLockedOut)
                    {
                        var lockoutEndUtc = await _userManager.GetLockoutEndDateAsync(user);
                        var timeLeft = lockoutEndUtc.Value - DateTime.UtcNow;
                        ModelState.AddModelError(string.Empty, $"Lütfen {timeLeft.Minutes} sonra tekrar deneyin");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Yanlış şifre veya e-posta.");

                    }


                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Yanlış şifre veya e-posta.");
                }
            }
            return View(viewModel);

        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
