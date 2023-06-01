using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ConnectElectronics.Models;
using ConnectElectronics.Models.ViewModels;

namespace ConnectElectronics.Controllers
{
    public class RoleController : Controller
    {
        public UserManager<ApplicationUser> UserManager;
        public RoleManager<IdentityRole> RoleManager;
        public IEnumerable<IdentityRole> Roles { get; set; }
        public RoleController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }
        public IActionResult Index()
        {
            Roles = RoleManager.Roles;
            return View(Roles);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Caktojmë emrin e rolit
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.Name
                };

                // Ruajmë Rolin duke thërritur metodën CreateAsync e cila shton rolin në tabelën AspNetRoles 
                IdentityResult result = await RoleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }
        
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var role = await RoleManager.FindByIdAsync(id);
            if (role != null)
            {
                await RoleManager.DeleteAsync(role);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> ShowEdit(string id)
        {
            var role = await RoleManager.FindByIdAsync(id);

            if (role == null)
            {

                return BadRequest("Roli nuk gjendet");
            }

            var model = new EditRole
            {
                Id = role.Id,
                Name = role.Name
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditRole model)
        {
            var role = await RoleManager.FindByIdAsync(model.Id);

            if (role == null)
            {
                return BadRequest("Roli nuk gjendet" + model.Id);
            }
            else
            {
                role.Name = model.Name;

                var result = await RoleManager.UpdateAsync(role);

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
