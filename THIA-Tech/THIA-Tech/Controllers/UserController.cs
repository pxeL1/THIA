using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using THIA_Tech.Models;
using THIA_Tech.Services;

namespace THIA_Tech.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUserService _userService;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager, IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (!_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Register");
            }  
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(DataChangeViewModel newData, string change)
        {
            if (change == "data")
            {
                if(newData.FirstName == null || newData.LastName == null || newData.Email == null)
                {
                    ModelState.AddModelError("emptyPassFields", "Fields cannot be empty");
                    return View(newData);
                }

                var usr = await _userManager.GetUserAsync(User);
                
                usr.FirstName = newData.FirstName;
                usr.LastName = newData.LastName;
                usr.Email = newData.Email;

                await _userManager.UpdateAsync(usr);
                return Redirect(Request.Headers.Referer);
            }
            else if (change == "password")
            {
                if (newData.oldPass == null || newData.newPass == null || newData.repeatNew == null)
                {
                    ModelState.AddModelError("emptyPassFields", "Fields cannot be empty");
                    return View(newData);
                }
                var usr = await _userManager.GetUserAsync(User);
                if (!await _userManager.CheckPasswordAsync(usr, newData.oldPass))
                {
                    ModelState.AddModelError("oldPass", "Invalid password");
                }
                if (newData.newPass != newData.repeatNew)
                {
                    ModelState.AddModelError("repeatNew", "Passwords must match!");
                }
                if (!ModelState.IsValid)
                {
                    return View(newData);
                }
                await _userManager.ChangePasswordAsync(usr, newData.oldPass, newData.newPass);
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }

        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDataViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    UserName = model.Username,
                    Role = Models.User.Roles.Customer
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(RegisterDataViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Wishlist()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RemoveItemFromWishlist(int id)
        {
           await _userService.RemoveWishlistItem(id);
            return RedirectToAction("Wishlist");
        }
    }
}
