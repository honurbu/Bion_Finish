using Blogss.Models;
using Blogss.Models.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blogss.Areas.Adminss.Controllers
{
    [Area("Adminss")]
    public class AdminProductController : Controller
    {
        Context context = new Context();


        public async Task<List<Product>> GetProductListWithCategory()
        {

            var products = context.Products
                .Include(x => x.Category);


            return await products.AsNoTracking().ToListAsync();
        }


        public async Task<IActionResult> ManageProducts()
        {
            var products = await GetProductListWithCategory();
            return View(products);
        }



        public IActionResult ProductDelete(int id)
        {
            var products = context.Products.Find(id);
            context.Remove(products);
            context.SaveChanges();
            return RedirectToAction("ManageProducts", "AdminProduct");
        }







        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            Product products = new Product();
            if (id == null)
            {
                return View(products);
            }

            products = context.Products
                .AsNoTracking()
                .Include(x => x.Category)
                .FirstOrDefault(x => x.Id == id);


            if (products == null)
            {
                return NotFound();
            }

            return View(products);            

        }
        [HttpPost]
        [ValidateAntiForgeryToken]  //for mvc post security. bots barcet
        public IActionResult UpdateProduct(Product products)
        {
            var prd = context.Products.Find(products.Id);


            prd.ProductTitle = products.ProductTitle;
            prd.ProductDescription = products.ProductDescription;
            prd.Category = products.Category;
            prd.ImageUrl = products.ImageUrl;


            context.Products.Update(prd);

            context.SaveChanges();

            return RedirectToAction("ManageProducts", "AdminProduct");
        }



        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product, Category category)
        {


            context.Products.Add(product);
            context.Categories.Add(category);

            context.SaveChanges();

            return RedirectToAction("ManageProducts", "AdminProduct");



        }





        [HttpGet]
        public IActionResult GetProductById(int id)
        {
            Values product = new Values();
            product.Urunlerimiz = context.Products.Where(x => x.Id == id).ToList();
            return View(product);

        }



    }
}
