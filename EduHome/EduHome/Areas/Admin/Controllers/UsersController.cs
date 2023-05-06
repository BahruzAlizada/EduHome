using EduHome.Helper;
using EduHome.Models;
using EduHome.ViewsModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UsersController(UserManager<AppUser> userManager,
                               RoleManager<IdentityRole> roleManager,
                               SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            List<AppUser> dbuser = await _userManager.Users.ToListAsync();
            List<UserVM> usersVM = new List<UserVM>();
            foreach (AppUser userr in dbuser)
            {
                UserVM usersVm = new UserVM
                {
                    Id = userr.Id,
                    FullName = userr.Name + userr.Surname,
                    Email = userr.Email,
                    Username = userr.UserName,
                    Role = (await _userManager.GetRolesAsync(userr))[0],
                    IsDeactive = userr.IsDeactive
                };
                usersVM.Add(usersVm);
            }

            return View(usersVM);
        }

     #region Create
        public IActionResult Create()
        {
            ViewBag.Roles = new List<string>
            {
                Helper.Role.Admin.ToString(),
                Helper.Role.Member.ToString()
            };

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(CreateVM createVM, string role)
        {
            ViewBag.Roles = new List<string>
            {
                Helper.Role.Admin.ToString(),
                Helper.Role.Member.ToString()
            };

            AppUser newuser = new AppUser
            {
                Name = createVM.FullName,
                Email = createVM.Email,
                UserName = createVM.Username
            };

            IdentityResult identityResult = await _userManager.CreateAsync(newuser, createVM.Password);
            if (!identityResult.Succeeded)
            {
                foreach (IdentityError error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }
            await _userManager.AddToRoleAsync(newuser, role);

            return RedirectToAction("Index");
        }
        #endregion

     #region Update
       public async Task<IActionResult> Update(string id)
        {
            ViewBag.Roles = new List<string>
            {
                Helper.Role.Admin.ToString(),
                Helper.Role.Member.ToString()
            };

            if (id == null)
                return NotFound();
            AppUser dbuser = await _userManager.FindByIdAsync(id);
            if (dbuser == null)
                return BadRequest();

            UpdateVM dbupdateVM = new UpdateVM
            {
                FullName = dbuser.Name + dbuser.Surname,
                Username = dbuser.UserName,
                Email = dbuser.Email,
            };

            return View(dbupdateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Update(string id,UpdateVM updateVM,string role)
        {
            ViewBag.Roles = new List<string>
            {
                Helper.Role.Admin.ToString(),
                Helper.Role.Member.ToString()
            };

            if (id == null)
                return NotFound();
            AppUser dbuser = await _userManager.FindByIdAsync(id);
            if (dbuser == null)
                return BadRequest();

            UpdateVM dbupdateVM = new UpdateVM
            {
                FullName = dbuser.Name + dbuser.Surname,
                Username = dbuser.UserName,
                Email = dbuser.Email,
                Role = (await _userManager.GetRolesAsync(dbuser))[0]
            };
            string full = dbuser.Name + dbuser.Surname;

            full  = updateVM.FullName;
            dbuser.Email = updateVM.Email;
            dbuser.UserName = updateVM.Username;

            if(dbupdateVM.Role != null)
            {
                IdentityResult identityResultRemove = await _userManager.RemoveFromRoleAsync(dbuser, dbupdateVM.Role);
                if(!identityResultRemove.Succeeded)
                {
                    foreach (IdentityError error in identityResultRemove.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View();
                }
                IdentityResult identityResultAdd = await _userManager.AddToRoleAsync(dbuser, role);
                if(!identityResultAdd.Succeeded)
                {
                    foreach (IdentityError error in identityResultAdd.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View();
                }
            }

            await _userManager.UpdateAsync(dbuser);
            return RedirectToAction("Index");
        }
        #endregion

        #region ResetPassword
        public async Task<IActionResult> ResetPassword(string id)
        {
            if (id == null)
                return NotFound();
            AppUser dbuser = await _userManager.FindByIdAsync(id);
            if (dbuser == null)
                return BadRequest();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> ResetPassword(string id,ResetPasswordVM resetPasswordVM)
        {
            if (id == null)
                return NotFound();
            AppUser dbuser = await _userManager.FindByIdAsync(id);
            if (dbuser == null)
                return BadRequest();

            string token = await _userManager.GeneratePasswordResetTokenAsync(dbuser);
            IdentityResult identityResult = await _userManager.ResetPasswordAsync(dbuser,token, resetPasswordVM.Password);

            if(!identityResult.Succeeded)
            {
                foreach (IdentityError error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }

            return RedirectToAction("Index");
        }
        #endregion

        #region Activity
        public async Task<IActionResult> Activity(string id)
        {
            if (id == null)
                return NotFound();
            AppUser dbuser = await _userManager.FindByIdAsync(id);
            if (dbuser == null)
                return BadRequest();

            if (dbuser.IsDeactive)
                dbuser.IsDeactive = false;
            else
                dbuser.IsDeactive = true;

            await _userManager.UpdateAsync(dbuser);
            return RedirectToAction("Index");
        }
        #endregion

    }
}


