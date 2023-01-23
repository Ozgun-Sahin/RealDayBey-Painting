using Core_Proje.Areas.Writer.Models;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.Controllers
{
    [AllowAnonymous]
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class RegisterController : Controller
    {
        private readonly UserManager<ClientUser> _userManager;

        public RegisterController(UserManager<ClientUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new UserRegisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel p)
        {

            ClientUser wrtr = new ClientUser()
            {
                Name = p.Name,
                Surname = p.Surname,
                Email = p.Email,
                UserName = p.UserName,
                ImageUrl = p.ImageUrl,
            };

            if (p.Password == p.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(wrtr, p.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View(p);
        }
    }
}
