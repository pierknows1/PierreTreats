using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using PierreTreats.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

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
        public async Task<ActionResult> Index()
        {
           Flavor[] flavors = _db.Flavors.ToArray();
           Treat[] treats = _db.Treats.ToArray();
           Dictionary<string, object[]> model = new Dictionary<string, object[]>();
           model.Add("flavors", flavors);
           model.Add("treats", treats);
           return View(model);
        }
    }
}