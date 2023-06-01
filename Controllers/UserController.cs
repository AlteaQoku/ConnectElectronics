using ConnectElectronics.Models.ViewModels;
using ConnectElectronics.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ConnectElectronics.Data; 
using Microsoft.Owin.Security;

namespace ConnectElectronics.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public UserController(UserManager<ApplicationUser> usermanager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = usermanager;
            _signInManager = signInManager;

        }

        public IActionResult UserDetails()

        {
            var id = _userManager.GetUserId(HttpContext.User);
            var user = _userManager.FindByIdAsync(id).Result;
            return View(user);
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var user = _userManager.FindByIdAsync(id).Result;
            return View(user);

        }


        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            await _userManager.DeleteAsync(user);
            await _userManager.UpdateSecurityStampAsync(user);


            return RedirectToPage("/Account/Login", new { area = "Identity" });

        }

        public IActionResult Edit(string id)
        {
            var user = _userManager.FindByIdAsync(id).Result;

            if (user == null)
            {

                return BadRequest("User nuk gjendet");
            }

            var model = new UserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Birthday = user.Birthday,
                City = user.City,

            };

            return View(model);
        }

        public async Task<IActionResult> EditConfirmed(UserViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);

            if (user == null)
            {

                return BadRequest("User nuk gjendet" + model.Id);
            }
            else
            {
                user.Email = model.Email;
                user.UserName = model.UserName;
                user.Birthday = model.Birthday;
                user.City = model.City;

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("UserDetails");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);

            }
        }

        public IActionResult ShowPasswordForm()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordUserViewModel model)
        {

            if (ModelState.IsValid)
            {
                var id = _userManager.GetUserId(HttpContext.User);
                var user = _userManager.FindByIdAsync(id).Result;
                if (user == null)
                {
                    return RedirectToPage("/Account/Login", new { area = "Identity" });
                }


                var result = await _userManager.ChangePasswordAsync(user,
                    model.OldPassword, model.NewPassword);

                if (result.Succeeded)
                {
                    await _signInManager.RefreshSignInAsync(user);
                    return RedirectToAction("UserDetails");

                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }

            return View("ShowPasswordForm", model);
        }


    }



}

