
﻿using eCommerceStarterCode.Data;
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

        [HttpGet(), Authorize]
        public IActionResult FilterProducts( string searchProducts)
        {

            var searchForProducts = _context.Products.Where(sp => sp.Name.Contains(searchProducts));
            return Ok(searchProducts);

        }
       
        [HttpDelete("{Id}"), Authorize]
        public IActionResult RemoveProduct(int Id)
        {
            var deleteProduct = _context.Products.Where(pr => pr.Id == Id);
            
            foreach (Products productRemoval in deleteProduct)
            {
                _context.Products.Remove(productRemoval);
            }
            _context.SaveChanges();
            return StatusCode(202, Id);
        }

        [HttpPost(), Authorize]
        public IActionResult AddProduct([FromBody]Products addThisProduct)
        {

            Products newProduct = new Products()
            {

                Name = addThisProduct.Name,
                Description = addThisProduct.Description,
                Price = addThisProduct.Price
            };
            _context.Products.Add(newProduct);
            _context.SaveChanges();

            return StatusCode(202, newProduct);




        }

        [HttpPut("{ID}"), Authorize]
        public IActionResult EditProduct(int Id, [FromBody] Products editThisProduct)
        {
            var updatedProduct = _context.Products.Where(pr => pr.Id == Id).SingleOrDefault();

            updatedProduct.Name = editThisProduct.Name;
            updatedProduct.Description = editThisProduct.Description;
            updatedProduct.Price = editThisProduct.Price;

            _context.Products.Update(updatedProduct);
            _context.SaveChanges();

            return StatusCode(202, updatedProduct);
        }
    }

}
