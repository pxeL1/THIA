using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using THIA_Tech.Models;
using THIA_Tech.Services;

namespace THIA_Tech.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICartService _cartService;
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public ProductController(IProductService productService, ICartService cartService, UserManager<User> userManager, IUserService userService, SignInManager<User> signInManager)
        {
            _productService = productService;
            _cartService = cartService;
            _userManager = userManager;
            _userService = userService;
            _signInManager = signInManager;
        }
        public async  Task<IActionResult> Index(string category, string? searchQuery = null)
        {
            if(searchQuery != null && searchQuery.Any())
            {
                return View(await _productService.SearchProducts(searchQuery));
            }
            return View(await _productService.GetProductsByCategory(category));
        }
        [HttpGet]
        public async Task<IActionResult> ProductDetails(int Id)
        {
            var prod = await _productService.GetProductById(Id);
            return View(prod);
        }
        [HttpPost]
        public async Task<IActionResult> ProductDetails(int Id, string change, int count)
        {
            var prod = await _productService.GetProductById(Id);

            if (!_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Register", "User");
            }

            if (change == "cart")
            {
               await _cartService.AddCartItem(Id, _userManager.GetUserId(User), count);
            }
            else if(change == "wishlist")
            {
               await _userService.AddItemToWishlist(Id, _userManager.GetUserId(User));
            }


            return RedirectToAction("ProductDetails", Id);
        }
        public async Task<IActionResult> AddProduct()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(NewProductViewModel model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}
