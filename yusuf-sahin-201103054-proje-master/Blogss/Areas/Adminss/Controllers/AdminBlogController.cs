using Blogss.Controllers;
using Blogss.Models;
using Blogss.Models.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blogss.Areas.Adminss.Controllers
{
    [Area("Adminss")]

    public class AdminBlogController : Controller
    {
        Context context = new Context();


        public async Task<IActionResult> BlogManage()
        {
            var blogs = await context.Blogs.ToListAsync();
            return View(blogs);
        }


        public IActionResult BlogDelete(int id)
        {
            var blogs = context.Blogs.Find(id);
            context.Remove(blogs);
            context.SaveChanges();
            return RedirectToAction("BlogManage", "AdminBlog");
        }



        [HttpGet]
        public IActionResult UpdateBlog(int id)
        {
            Blog blogs = new Blog();
            if (id == null)
            {
                return View(blogs);
            }

            blogs = context.Blogs
            .FirstOrDefault(x => x.Id == id);


            if (blogs == null)
            {
                return NotFound();
            }

            return View(blogs);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]  //for mvc post security. bots barcet
        public IActionResult UpdateBlog(Blog blogs)
        {
            var bloglarım = context.Blogs.Find(blogs.Id);

            bloglarım.Id = blogs.Id;
            bloglarım.BlogTitle = blogs.BlogTitle;
            bloglarım.BlogWrite = blogs.BlogWrite;
            bloglarım.SpotDefinition = blogs.SpotDefinition;
            bloglarım.BlogImage = blogs.BlogImage;


            context.Blogs.Update(bloglarım);
            context.SaveChanges();

            return RedirectToAction("BlogManage", "AdminBlog");
        }



        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Blog blogcx, Category categories)
        {

            context.Blogs.Add(blogcx);
            context.Categories.Add(categories);

            context.SaveChanges();


            return RedirectToAction("BlogManage", "AdminBlog");

        }






        [HttpGet]
        public IActionResult GetBlogById(int id)
        {
            Values blog = new Values();
            blog.Bloglarımız = context.Blogs.Where(x => x.Id == id).ToList();
            return View(blog);

        }


    }
}
