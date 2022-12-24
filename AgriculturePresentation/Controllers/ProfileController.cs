using AgriculturePresentation.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AgriculturePresentation.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public ProfileController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);

            ProfileEditViewModel profileEditViewModel = new ProfileEditViewModel();

            profileEditViewModel.UserName = values.UserName;
            profileEditViewModel.PhoneNumber = values.PhoneNumber;

            return View(profileEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(ProfileEditViewModel profileEditViewModel)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);

            if (profileEditViewModel.Password == profileEditViewModel.PasswordConfirm && profileEditViewModel.Password != null && profileEditViewModel.PasswordConfirm != null)
            {
                values.UserName = profileEditViewModel.UserName;
                values.PhoneNumber = profileEditViewModel.PhoneNumber;
                values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, profileEditViewModel.Password);

                var result = await _userManager.UpdateAsync(values);

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

            return View();
        }
    }
}
