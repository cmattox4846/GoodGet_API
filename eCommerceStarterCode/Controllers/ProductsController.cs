
﻿using eCommerceStarterCode.Data;
using eCommerceStarterCode.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace eCommerceStarterCode.Controllers
{
    [Route("api/product")]
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

        [HttpGet("{Id}"), Authorize]
        public IActionResult FilterProducts( string searchProducts)
        {
           
            var searchForProducts = _context.Products.Where(sp => sp.Name == searchProducts).FirstOrDefault();
            return Ok();
        }
        Products newProductList = new Products()
        {
            
        };
        [HttpDelete("{Delete}"), Authorize]
        void RemoveProduct(string removeThisProduct)
        {
            var deleteProduct = _context.Products.Where(pr => pr.Name == removeThisProduct);
            
            foreach (Products productRemoval in deleteProduct)
            {
                _context.Products.Remove(productRemoval);
            }
            _context.SaveChanges();
        }

        //[HttpGet("{Add}"), Authorize]
        //void AddProduct(object addThisProduct)
        //{
        //    var item = addThisProduct;
        //    Products newProduct = new Products()
        //        {

        //            Name = item.Name,
        //            Description = addThisProduct.Description,
        //            Price = addThisProduct.Price
        //        }
        //    _context.Products.Add(newProduct);
        //    _context.SaveChanges();




        //}

        //[HttpGet("{Edit}"), Authorize]
        //void EditProduct(string editThisProduct)
        //{
        //    var editProduct = _context.Products.Where(pr => pr.Id == editThisProduct.Id);

        //        editProduct.Name = editThisProduct.Name,
        //        editProduct.Description = editThisProduct.Description,
        //        editProduct.Price = editThisProduct.Price,

        //    _context.Products.Update(editProduct);
        //    _context.SaveChanges();
        }

    }
//}
