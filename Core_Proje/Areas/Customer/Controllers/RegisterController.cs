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
    public class RegisterController : Controller
    {
        private readonly UserManager<User> _userManager;

        public RegisterController(UserManager<User> userManager)
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

            User wrtr = new User()
            {
                Name = p.Name,
                Surname = p.Surname,
                UserName = p.UserName,
                
            };

            if(p.Picture != null)
            {
                var resoruce = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.Picture.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resoruce + "/wwwroot/userimage/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await p.Picture.CopyToAsync(stream);
                wrtr.ImageUrl = imageName;
            }


            if (p.Password == p.ConfirmPassword && p.Password !=null)
            {
                var result = await _userManager.CreateAsync(wrtr, p.Password);
                await _userManager.AddToRoleAsync(wrtr, "Customer");

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
