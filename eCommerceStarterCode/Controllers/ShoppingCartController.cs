using eCommerceStarterCode.Data;
using eCommerceStarterCode.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;

namespace eCommerceStarterCode.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ShoppingCartController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult AddProductToShoppingCart()
        {
            var userId = User.FindFirstValue("id");
            var user = _context.Users.Find(userId);
            if (user == null)
            {
                return NotFound();
            }
            //assign variable to "product"
            var productId = _context.Products.Where(p => p.Name == "product" ).Select(p => p.Id).SingleOrDefault();

            ShoppingCart newProduct = new ShoppingCart()
            {
                UserID = userId,
                ProductId = productId,
                Quantity = 1,
            };

            _context.ShoppingCarts.Add(newProduct);
            _context.SaveChanges();

            return View();
        }

        void RemoveProductFromShoppingCart()
        {
            //assign variable to "productId"
            var ProductToBeRemoved = "productId";
            var ItemToRemove = _context.ShoppingCarts.Include(sc => sc.Product).Where(sc => sc.Product.Name == ProductToBeRemoved).SingleOrDefault();
            _context.ShoppingCarts.Remove(ItemToRemove);
            _context.SaveChanges();
        }

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
