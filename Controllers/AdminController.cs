using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ConnectElectronics.Models;
using ConnectElectronics.Areas.Identity.Pages.Account;
using ConnectElectronics.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using ConnectElectronics.Models.ViewModels;

namespace ConnectElectronics.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> UserManager;
        public RoleManager<IdentityRole> RoleManager;
        public IEnumerable<IdentityRole> Roles { get; set; }

        public AdminController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.UserManager = userManager;
            this.RoleManager = roleManager;

        }

        public IActionResult Index()
        {
            var users = UserManager.Users.Select(user => new UserViewModel()
            {
                Id = user.Id,
                Name = user.FirstName,
                LastName= user.LastName,
                Email = user.Email,
                Birthday = user.Birthday,
                City = user.City,
                Role = string.Join(",", UserManager.GetRolesAsync(user).Result.ToArray())
            }).ToList();
            return View(users);
        }
        public async Task<IActionResult> Delete(string id)
        {
            ApplicationUser user = await UserManager.FindByIdAsync(id);
            if (user != null)
            {
                await UserManager.DeleteAsync(user);
            }
            return RedirectToAction("Index");
        }
        //create a role for user
        [HttpGet]
        public async Task<ActionResult> Create(string id)
        {
            var user = await UserManager.FindByIdAsync(id);

            if (user == null)
            {

                return BadRequest("User was not found");
            }

            var model = new UserViewModel
            {
                Id = user.Id,
                Email = user.Email
            };

            var roles = RoleManager.Roles;
            ViewBag.Roles = new SelectList(roles.ToList(), "Id", "Name");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateUserRole(UserViewModel u)
        {
            var name = Convert.ToString(await RoleManager.FindByIdAsync(u.Role));
            var user = await UserManager.FindByEmailAsync(u.Email);

            if (user == null)
            {
                return BadRequest("User does not exists" + user);
            }
            await UserManager.AddToRoleAsync(user, name);
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> ShowEditAsync(string id)
        {
            var user = await UserManager.FindByIdAsync(id);

            if (user == null)
            {

                return BadRequest("User nuk gjendet");
            }

            var model = new UserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.FirstName,
                LastName = user.LastName,
                Birthday = user.Birthday,
                City = user.City,

            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UserViewModel model)
        {
            var user = await UserManager.FindByIdAsync(model.Id);

            if (user == null)
            {

                return BadRequest("User was not found" + model.Id);
            }
            else
            {
                user.Email = model.Email;
                user.FirstName = model.Name;
                user.LastName = model.LastName;
                user.Birthday = model.Birthday;
                user.City = model.City;

                var result = await UserManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }


        }
    }
}
