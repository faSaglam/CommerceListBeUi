using Business.Concreate;
using Core.Entities;
using Entities.Concreate;
using Entities.Concreate.ViewModels;
using Entitites.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CommerceListMVC.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<User> _userManager;
     

        public AdminController(UserManager<User> userManager, RoleManager<UserRole> roleManager)
        {
            _userManager = userManager;
           
        }
        public async Task<IActionResult> Users()
        {
            return View(await _userManager.Users.ToListAsync());
        }
 
  

    }
}
