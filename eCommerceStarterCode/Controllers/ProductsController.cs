using eCommerceStarterCode.Data;
using eCommerceStarterCode.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace eCommerceStarterCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly Data.ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            
            _context = context;
          
        }

        [HttpGet, Authorize]

        public IActionResult GetProducts()
        {
            var products = _context.Products;

            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }

        [HttpGet("{Id}")]
        public IActionResult FilterProducts( string searchProducts)
        {
           
            var searchForProducts = _context.Products.Where(sp => sp.Name == searchProducts).FirstOrDefault();
            return Ok();
        }
        Products newProductList = new Products()
        {
            
        };
        [HttpDelete("{Delete}")]
        void RemoveProduct(string removeThisProduct)
        {
            var deleteProduct = _context.Products.Where(pr => pr.Name == removeThisProduct);
            
            foreach (Products productRemoval in deleteProduct)
            {
                _context.Products.Remove(productRemoval);
            }
            _context.SaveChanges();
        }

        [HttpGet("{Add}")]
        void AddProduct(string addThisProduct)
        {
            var addProduct = _context.Products.Where(pr => pr.Name == addThisProduct);

            foreach (Products productAddition in addProduct)
            {
                _context.Products.Remove(productAddition);
            }
            _context.SaveChanges();
        }

        [HttpGet("{Add}")]
        void EditProduct(string editThisProduct)
        {
            var editProduct = _context.Products.Where(pr => pr.Name == editThisProduct);

            foreach (Products productEdit in editProduct)
            {
                _context.Products.Remove(productEdit);
            }
            _context.SaveChanges();
        }
    }
}
