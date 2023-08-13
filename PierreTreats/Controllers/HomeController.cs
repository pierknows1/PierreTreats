using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using PierreTreats.Models;
using System.Collections.Generic;
using System.Linq;

namespace PierreTreats.Controllers
{
    public class HomeController : Controller
    {
        private readonly TreatsContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(UserManager<ApplicationUser> userManager, TreatsContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        [HttpGet("/")]
        public ActionResult Index()
        {
            Dictionary<string, object[]> model = new Dictionary<string, object[]>();

            List<Treat> treats = _db.Treats.ToList();
            List<Flavor> flavors = _db.Flavors.ToList();

            model.Add("treats", treats.ToArray());
            model.Add("flavors", flavors.ToArray());

            return View(model);
        }
    }
}

