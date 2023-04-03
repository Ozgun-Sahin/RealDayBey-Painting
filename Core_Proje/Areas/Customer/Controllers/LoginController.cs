using Core_Proje.Areas.Customer.Models;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Customer.Controllers
{
    [AllowAnonymous]
    [Area("Customer")]
    [Route("Customer/[controller]/[action]")]
    public class LoginController : Controller
    {
        private readonly SignInManager<ClientUser> _signInManager;

        public LoginController(SignInManager<ClientUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel p)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.Username, p.Password, true, true);

                if (result.Succeeded)
                {
                    //return RedirectToAction("Index", "Profile", new { area = "Writer" });
                    return RedirectToAction("DashboardIndex", "WriterDashboard");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
                }
            }

            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index","Login");
        }
    }
}
