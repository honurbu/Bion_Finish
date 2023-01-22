using Blogss.Models.Context;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Blogss.Controllers
{
    public class Blogs : Controller
    {
        Context context = new Context();

        public IActionResult Index()
        {
            var values = context.Blogs.ToList();
            return View(values);
        }

    }
}
