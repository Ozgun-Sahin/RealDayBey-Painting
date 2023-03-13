using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class AdminLoginController : Controller
    {
        private readonly SignInManager<ClientUser> _signInManager;

        public AdminLoginController(SignInManager<ClientUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "AdminLogin");
        }
    }
}
