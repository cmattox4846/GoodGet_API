
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
    public class ReviewsController : ControllerBase
    {
        private readonly Data.ApplicationDbContext _context;

        public ReviewsController(ApplicationDbContext context)
        {

            _context = context;

        }

        [HttpGet, Authorize]
        public IActionResult GetReviews()
        {
            var review = _context.Reviews;

            if (review == null)
            {
                return NotFound();
            }

            return Ok(review);
        }

        [HttpDelete("{Id}"), Authorize]
        public IActionResult RemoveReview(int Id)
        {
            var deleteReview = _context.Reviews.Find(Id);

            //foreach (Reviews reviewRemoval in deleteReview)
            //{
            //    _context.Reviews.Remove(reviewRemoval);
            //}
            _context.SaveChanges();
            return StatusCode(202, Id);
        }

        [HttpPost, Authorize]
        public IActionResult AddReview([FromBody] Reviews addThisReview)
        {

            Reviews newReview = new Reviews()
            {

                Review = addThisReview.Review,
                Rating = addThisReview.Rating,
                ProductId = addThisReview.ProductId
            };
            _context.Reviews.Add(newReview);
            _context.SaveChanges();

            return StatusCode(202, newReview);




        }

        [HttpPut("{ID}"), Authorize]
        public IActionResult EditReview(int Id, [FromBody] Reviews editThisReview)
        {
            var updatedReview = _context.Reviews.Find(Id);

            updatedReview.Review = editThisReview.Review;
            updatedReview.Rating = editThisReview.Rating;
            updatedReview.ProductId = editThisReview.ProductId;

            _context.Reviews.Update(updatedReview);
            _context.SaveChanges();

            return StatusCode(202, updatedReview);
        }


    }
}
