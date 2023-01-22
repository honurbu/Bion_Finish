using Blogss.Models;
using Blogss.Models.Context;
using Microsoft.AspNetCore.Mvc;

namespace Blogss.Areas.Adminss.Controllers
{
    [Area("Adminss")]
    public class AdminOrganisiationController : Controller
    {
        Context context = new Context();




        public IActionResult Index()
        {
            var values = context.Organisations.ToList();
            return View(values);
        }



        public IActionResult OrganisatiionDelete(int id)
        {
            var organisation = context.Organisations.Find(id);
            context.Remove(organisation);
            context.SaveChanges();
            return RedirectToAction("Index", "AdminOrganisiation");
        }



        [HttpGet]
        public IActionResult UpdateOrganisation(int id)
        {
            Organisation organisation = new Organisation();
            if (id == null)
            {
                return View(organisation);
            }

            organisation = context.Organisations
            .FirstOrDefault(x => x.Id == id);


            if (organisation == null)
            {
                return NotFound();
            }

            return View(organisation);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]  //for mvc post security. bots barcet
        public IActionResult UpdateOrganisation(Organisation organisation)
        {
            var organisations = context.Organisations.Find(organisation.Id);

            organisations.OrganisationName = organisation.OrganisationName;
            organisations.Definition = organisation.Definition;


            context.Organisations.Update(organisations);
            context.SaveChanges();

            return RedirectToAction("Index", "AdminOrganisiation");
        }



        [HttpGet]
        public IActionResult AddOrganisation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddOrganisation(Organisation organisation)
        {

            context.Organisations.Add(organisation);

            context.SaveChanges();


            return RedirectToAction("Index", "AdminOrganisiation");

        }




    }
}
