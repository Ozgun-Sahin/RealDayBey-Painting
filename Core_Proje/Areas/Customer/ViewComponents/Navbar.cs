using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Customer.ViewComponents
{
    public class Navbar :ViewComponent
    {
        private readonly UserManager<ClientUser> _userManager;

        public Navbar(UserManager<ClientUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v = value.ImageUrl;
            return View();  
        }
    }
}
