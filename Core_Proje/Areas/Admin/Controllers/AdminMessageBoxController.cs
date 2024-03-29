﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace Core_Proje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/")]
    [Authorize(Roles = "Admin")]
    public class AdminMessageBoxController : Controller
    {
        MessageManager writerMessageManager = new MessageManager(new EFMessageDal());

        private readonly UserManager<User> _userManager;

        public AdminMessageBoxController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Inbox()
        {
            ClaimsPrincipal currentUser = User;

            string userName = _userManager.GetUserName(currentUser);

            var messageList = writerMessageManager.GetListReceiverMessage(userName);

            return View(messageList);
        }

        public async Task<IActionResult> Outbox()
        {
            ClaimsPrincipal currentUser = User;

            string userName = _userManager.GetUserName(currentUser);

            var messageList = writerMessageManager.GetListSenderMessage(userName);

            return View(messageList);
        }



        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(Message p)
        {
            AdminMessageValidator validations = new AdminMessageValidator();

            ClaimsPrincipal Admin = User;
            var admin = await _userManager.GetUserAsync(Admin);
            var user = _userManager.Users.Where(x => x.UserName == p.RecieverUserName).FirstOrDefault();

            p.SenderFullName = admin.Name + " " + admin.Surname;

            if (user!=null)
            {
                p.RecieverFullName = user.Name + " " + user.Surname;
            }

            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.SenderUserName = admin.UserName;


            ValidationResult results = validations.Validate(p);

            if (results.IsValid)
            {
                writerMessageManager.TAdd(p);
                return RedirectToAction("DashboardIndex", "Dashboard");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
              
        }


        //Modal
        [HttpGet("{id}")]
        public IActionResult MessageDetailsInModal(int id)
        {
            var message = writerMessageManager.TGetById(id);

            return PartialView(message);
        }



    }
}
