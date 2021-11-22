using Microsoft.AspNetCore.Mvc;

namespace eCommerceStarterCode.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
