using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P335_BackEnd.Areas.Admin.Models;
using P335_BackEnd.Data;
using P335_BackEnd.Models;
using P335_BackEnd.Entities;

namespace P335_BackEnd.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactInfoController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ContactInfoController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var user = HttpContext.User;
            var isAdmin = user.IsInRole("Admin");
            var isModerator = user.IsInRole("Moderator");

            var contactInfo = _dbContext.ContactInfo.FirstOrDefault();

            var contactInfoViewModel = new ContactInfoVM
            {
                Email = contactInfo?.Email,
                PhoneNumber = contactInfo?.PhoneNumber,
                IsAdmin = isAdmin,
                IsModerator = isModerator
            };

            return View(contactInfoViewModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Update(ContactInfoVM model)
        {
            if (ModelState.IsValid)
            {
                var existingContactInfo = _dbContext.ContactInfo.FirstOrDefault();

                if (existingContactInfo != null)
                {
                    if (model.IsAdmin)
                    {
                        existingContactInfo.Email = model.Email;
                        existingContactInfo.PhoneNumber = model.PhoneNumber;
                        _dbContext.SaveChanges();
                    }

                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }

            return View("Index", model);
        }
    }

}