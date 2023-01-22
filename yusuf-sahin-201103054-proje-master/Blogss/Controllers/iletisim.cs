using Blogss.Models.Context;
using Microsoft.AspNetCore.Mvc;

namespace Blogss.Controllers
{
    public class iletisim : Controller
{
    Context context = new Context();

    public IActionResult Index()
    {
        var values = context.Blogs.ToList();
        return View(values);
    }
}
}
