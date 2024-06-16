using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using THIA_Tech.Models;
using THIA_Tech.Services;

namespace THIA_Tech.Controllers
{
    public class CartController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IOrderService _orderService;
        private readonly ICartService _cartService;
        public CartController(SignInManager<User> signInManager, IOrderService orderService, UserManager<User> userManager, ICartService cartService)
        {
            _signInManager = signInManager;
            _orderService = orderService;
            _userManager = userManager;
            _cartService = cartService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            if (!_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Register", "User");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string address, string change)
        {
            var items = await _cartService.GetAllCartItems(_userManager.GetUserId(User));
          
            var result = await _orderService.CreateOrder(address, items, _userManager.GetUserId(User));

              
                    await _orderService.CreateOrderItems(items, result.Id);
                    await _cartService.DeleteCart(items);
                    return RedirectToAction("Index");
                
            
           return View();
        }
        [HttpPost]
        public async Task<IActionResult> RemoveItemFromCart(int id)
        {
            await _cartService.RemoveCartItem(id);
            return RedirectToAction("Index");
        }
    }
}
