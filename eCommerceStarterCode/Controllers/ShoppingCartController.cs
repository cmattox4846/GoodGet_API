using eCommerceStarterCode.Data;
using eCommerceStarterCode.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;

namespace eCommerceStarterCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ShoppingCartController(ApplicationDbContext context)
        {
            _context = context;
        }

        // **** ADD A Shopping cart
        // POST /api/shoppingcart
        [HttpPost, Authorize]
        public IActionResult AddProductToShoppingCart([FromBody] ShoppingCart value)
        {
            var userId = User.FindFirstValue("id");
            var user = _context.Users.Find(userId);
            if (user == null)
            {
                return NotFound();
            }
            
            var productId = _context.Products.Where(p => p.Id == value.Id).Select(p => p.Id).SingleOrDefault();

            ShoppingCart newProduct = new ShoppingCart()
            {
                UserID = userId,
                ProductId = productId,
                Quantity = 1,
            };

            _context.ShoppingCarts.Add(newProduct);
            _context.SaveChanges();

            return StatusCode(201, value);
        }
        // *** DELETE A Record ***
        // DELETE /api/shoppingcart
        [HttpDelete("{Id}"), Authorize]
        public IActionResult RemoveProductFromShoppingCart(int Id)
        {
            
            
            var ItemToRemove = _context.ShoppingCarts.Include(sc => sc.Product).Where(sc => sc.Product.Id == Id).SingleOrDefault();
            _context.ShoppingCarts.Remove(ItemToRemove);
            _context.SaveChanges();

            return StatusCode(202, Id);
        }

        [HttpGet, Authorize]
        public IActionResult GetProductFromShoppingCart(string UserData)
        {
            var GetProducts = _context.ShoppingCarts.Include(sc => sc.Users).Include(sc => sc.Product).Where(sc => sc.Users.Id == UserData);
            var products = GetProducts.ToList();
            foreach (ShoppingCart product in GetProducts)
            {
                var ItemsInCart = product;
                Console.WriteLine(ItemsInCart);
            };
            

            return View();
        }


    }
}
