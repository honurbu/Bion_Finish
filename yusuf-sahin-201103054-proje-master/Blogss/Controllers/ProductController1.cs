using Blogss.Models.Context;
using Microsoft.AspNetCore.Mvc;

namespace Blogss.Controllers
{
    public class ProductController1 : Controller
    {
        Context context = new Context();
        public IActionResult GetProduct()
        {
            var values = context.Products.ToList();
            return View(values);
        }
    }
}
