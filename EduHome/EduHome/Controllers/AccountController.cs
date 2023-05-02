using EduHome.Helper;
using EduHome.Models;
using EduHome.ViewsModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager,SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        #region Login
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            AppUser user = await _userManager.FindByNameAsync(loginVM.Username);
            if (user == null)
            {
                ModelState.AddModelError("", "UserName or Password is wrong");
                return View();
            }
            if (user.IsDeactive)
            {
                ModelState.AddModelError("", "Your Account is deactive");
                return View();
            }

           Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(user, loginVM.Password, loginVM.IsRemember, true);
            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelError("", "Your Account is blocked");
                return View();
            }
            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "UserName or Password is wrong");
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Register
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            AppUser newuser = new AppUser
            {
                Email = registerVM.Email,
                UserName = registerVM.Username,
                Name = registerVM.FullName
            };

            IdentityResult identityResult = await _userManager.CreateAsync(newuser, registerVM.Password);
            if (!identityResult.Succeeded)
            {
                foreach (IdentityError error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }
            await _userManager.AddToRoleAsync(newuser, Role.Admin.ToString());
            await _signInManager.SignInAsync(newuser, registerVM.IsRemember);
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Logout
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        #endregion

        //public async Task  CreateRoles()
        //{
        //    if(!await _roleManager.RoleExistsAsync(Helper.Role.Admin.ToString()))
        //    {
        //        await _roleManager.CreateAsync(new IdentityRole { Name=Helper.Role.Admin.ToString() });
        //    }
        //    if(!await _roleManager.RoleExistsAsync(Helper.Role.Member.ToString()))
        //    {
        //        await _roleManager.CreateAsync(new IdentityRole { Name = Helper.Role.Member.ToString() });
        //    }
        //}
    }
}
