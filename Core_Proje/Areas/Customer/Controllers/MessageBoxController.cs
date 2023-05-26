using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Core_Proje.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Route("Customer/MessageBox")]
    public class MessageBoxController : Controller
    {
        MessageManager writerMessageManager = new MessageManager(new EFMessageDal());

        private readonly UserManager<User> _userManager;

        public MessageBoxController( UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [Route("")]
        [Route("Inbox")]
        public async Task<IActionResult> Inbox()
        {
            ClaimsPrincipal currentUser = this.User;

            string userName = _userManager.GetUserName(currentUser);

            var messageList = writerMessageManager.GetListReceiverMessage(userName);

            return View(messageList);
        }

        [Route("")]
        [Route("Outbox")]
        public async Task<IActionResult> Outbox()
        {
            ClaimsPrincipal currentUser =this.User;

            string userName = _userManager.GetUserName(currentUser);

            var messageList = writerMessageManager.GetListSenderMessage(userName);

            return View(messageList);
        }

        [Route("")]
        [Route("SendMessage")]
        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }

        [Route("")]
        [Route("SendMessage")]
        [HttpPost]
        public async Task<IActionResult> SendMessage(Message p)
        {
            ClaimsPrincipal currentUser = this.User;

            CustomerMessageValidator validations = new CustomerMessageValidator();

            string userName = _userManager.GetUserName(currentUser);

            var admin = await _userManager.GetUsersInRoleAsync("Admin");

            var user = await _userManager.GetUserAsync(currentUser);


            p.SenderFullName = user.Name + " " + user.Surname;
            p.RecieverFullName = admin.FirstOrDefault().Name + " " + admin.FirstOrDefault().Surname;

            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());

            p.RecieverUserName = admin.FirstOrDefault().UserName;
            p.SenderUserName = user.UserName;

            ValidationResult results = validations.Validate(p);

            if (results.IsValid)
            {
                writerMessageManager.TAdd(p);

                return RedirectToAction("Inbox");
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
        [Route("MessageDetailsInModal/{id}")]
        [HttpGet]
        public IActionResult MessageDetailsInModal(int id)
        {
            var message = writerMessageManager.TGetById(id);

            return PartialView(message);
        }
    }
}
