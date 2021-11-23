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

            var productAlreadyInCart = _context.ShoppingCarts.Include(sc => sc.Product).Include(sc => sc.User).Where(sc => sc.UserID == user.Id && sc.Product.Id == value.ProductId).SingleOrDefault();
            if (productAlreadyInCart != null)
            {
                var product = _context.ShoppingCarts.Where(sc => sc.Product.Id == value.ProductId).FirstOrDefault();
                product.Quantity++;
                _context.SaveChanges();
            }
            else if (productAlreadyInCart == null)
            {

                value.UserID = userId;

                _context.ShoppingCarts.Add(value);
                _context.SaveChanges();
            }

            return StatusCode(201, value);
        }
        // *** DELETE A Record ***
        // DELETE /api/shoppingcart
        [HttpDelete("{Id}"), Authorize]
        public IActionResult RemoveProductFromShoppingCart(int Id)
        {
            
            
            var ItemToRemove = _context.ShoppingCarts.Include(sc => sc.Product).Where(sc => sc.ProductId == Id);
            
            foreach (ShoppingCart Item in ItemToRemove)
            {
                _context.ShoppingCarts.Remove(Item);
            }
            
            
            _context.SaveChanges();

            return StatusCode(202, Id);
        }

        [HttpGet, Authorize]
        public IActionResult GetProductFromShoppingCart()

        {
            var userId = User.FindFirstValue("id");
            var user = _context.Users.Find(userId);

            var GetProducts = _context.ShoppingCarts.Include(sc => sc.User).Include(sc => sc.Product).Where(sc => sc.UserID == user.Id);
            var products = GetProducts.ToList();
           


            return Ok(products);
        }


    }
}
