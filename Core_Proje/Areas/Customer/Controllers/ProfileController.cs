using Core_Proje.Areas.Customer.Models;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;

namespace Core_Proje.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Route("Customer/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<User> _userManager;

        public ProfileController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> ProfileIndex()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel();
            model.Name = value.Name;
            model.Surname = value.Surname;
            model.PictureUrl = value.ImageUrl;
            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> ProfileIndex(UserEditViewModel p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (p.Picture !=null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.Picture.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/userimage/" + imageName;
                var strem = new FileStream(saveLocation, FileMode.Create);
                await p.Picture.CopyToAsync(strem);
                user.ImageUrl = imageName;
            }

            user.Name = p.Name;
            user.Surname = p.Surname;

            if (p.NewPassword == p.NewPasswordConfirm && p.NewPassword!=null)
            {
                //user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.Password);

                var result1 = await _userManager.ChangePasswordAsync(user, p.CurrentPassword, p.NewPassword);

                if (result1.Succeeded)
                {
                    var result2 = await _userManager.UpdateAsync(user);

                    if (result2.Succeeded)
                    {
                        return RedirectToAction("Index", "Default");
                    }
                    else
                    {
                        foreach (var item in result2.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }
                else
                {
                    foreach (var item in result1.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }

            return View();
        }
    }
}
