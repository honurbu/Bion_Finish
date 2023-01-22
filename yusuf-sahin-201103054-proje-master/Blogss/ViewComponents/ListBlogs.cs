using Blogss.Models.Context;
using Microsoft.AspNetCore.Mvc;

namespace Blogss.ViewComponents
{
    public class ListBlogs:ViewComponent
    {
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            var values = context.Blogs.ToList();
            return View(values);
        }
    }
}
