using IDTPDashboard.DataAccess.Interface;
using IDTPDashboard.DomainModel.Entity;
using IDTPDashboard.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IDTPDashboard.Web.Controllers
{
    public class SettingController : Controller
    {
        private readonly IOfficeRepository _repositoryOffice;

        public SettingController(IOfficeRepository repositoryOffice)
        {
            _repositoryOffice = repositoryOffice ?? throw new ArgumentNullException(nameof(repositoryOffice));
        }


        public async Task<IActionResult> Index()
        {
            var Organization = HttpContext.User.FindFirstValue("Organization");

            OfficeList_Entity officeList_Entity = await _repositoryOffice.GetAllData(Organization);
            ViewData["Office"] = new SelectList(officeList_Entity.officeList,"OfficeCode","OfficeName");
            var userSettings = new UserSettingViewModel();
            if (userSettings == null)
            {
                return NotFound();
            }
            return View(userSettings);
            // return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(UserSetting userSetting)
        {
            //if (id != tag.Id)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(tag);
            //        await _context.SaveChangesAsync();
            //        TempData["Edit"] = "Update Successfull!";
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!TagExists(tag.Id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            return View();
        }

    }
}
