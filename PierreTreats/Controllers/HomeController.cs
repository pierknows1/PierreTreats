using Microsoft.AspNetCore.Mvc;

namespace PierreTreats.Controllers 
{
    public class HomeController : Controller
    {
        {
            private readonly TreatsContext _db;
            private readonly UserManager<ApplicationUser> _userManager;

            public HomeController(UserManager<ApplicationUser> userManager, TreatsContext db)
            {
                _userManager = userManager;
                _db = db;
            }
        }
        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }
    }
}