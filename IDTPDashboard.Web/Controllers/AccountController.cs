using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IDTPDashboard.DataAccess.Interface;
using IDTPDashboard.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IDTPDashboard.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl="/") {
            return View(new LoginModel {ReturnUrl=returnUrl });
        }

        [AllowAnonymous]
        [HttpPost]
        public  async  Task<IActionResult> Login(LoginModel model)
        {
            // if (ModelState.IsValid)
            // {
            //     var user = await _userRepository.GetByUsernameAndPassword(model.Username, model.Password);
            //     if (user == null)
            //     {
            //         Unauthorized();
            //         ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            //         return View();
            //     }

            //     var claims = new List<Claim>() {
            //     new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
            //     new Claim(ClaimTypes.Name,user.Name),
            //     new Claim("Organization",user.Organization),
            //     new Claim(ClaimTypes.Role,user.Role),
            //     new Claim("PBSName", user.PbsName)
            // };

            //     var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            //     var principal = new ClaimsPrincipal(new[] { identity });

            //     await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = model.RememberLogin });

            //     if(user.Organization== "IDTP")
            //     {
            //         return RedirectToAction("IDTPDashboard1", "IDTPChart");
            //     }
            //     //else
            //     //{
            //     //    return LocalRedirect(model.ReturnUrl);
            //     //}
            // }
            
            return RedirectToAction("IDTPDashboard1", "IDTPChart");
            //return LocalRedirect(model.ReturnUrl);

        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Dashboard");
        }
    }
}
