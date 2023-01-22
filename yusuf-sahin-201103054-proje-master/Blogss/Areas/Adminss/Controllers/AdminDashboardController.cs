using Blogss.Models.Context;
using Microsoft.AspNetCore.Mvc;

namespace Blogss.Areas.Adminss.Controllers
{
    [Area("Adminss")]
    public class AdminDashboardController : Controller
    {
        Context context = new Context();

        public IActionResult Index()
        {
            ViewBag.Product = context.Products.Count();
            ViewBag.Blogs = context.Blogs.Count();


            return View();
        }
    }
}
