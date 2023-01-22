using Blogss.Models.Context;
using Microsoft.AspNetCore.Mvc;

namespace Blogss.Controllers
{
    public class kurumsal : Controller
    {
        Context context = new Context();

        public IActionResult Index()
        {
            var values = context.Organisations.ToList();
            return View(values);
        }
    }
}
