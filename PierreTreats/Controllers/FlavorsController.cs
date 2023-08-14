using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using PierreTreats.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Claims;

namespace PierreTreats.Controllers

{
    [Authorize]
    public class FlavorsController : Controller

    {

    private readonly TreatsContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public FlavorsController(UserManager<ApplicationUser> userManager, TreatsContext db)
    {
        _db = db;
        _userManager = userManager;
        }

    [AllowAnonymous]
    public async Task<ActionResult> Index()
    {
        string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);

        List<Flavor> model = _db.Flavors.ToList();
        return View(model);
        }

    public ActionResult Create()
    {
        return View();
    }

      [HttpPost]
    public ActionResult Create(Flavor flavor)
    {
        _db.Flavors.Add(flavor);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Details (int id)
    {
        Flavor thisFlavor = _db.Flavors
                            .Include(flavor => flavor.JoinEntities)
                            .ThenInclude(join => join.Treat)
                            .FirstOrDefault(flavor => flavor.FlavorId == id);
        return View(thisFlavor);
    }

    public ActionResult Edit(int id)
    {
        Flavor thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
        return View(thisFlavor);
    }

    [HttpPost]
    public ActionResult Edit (Flavor flavor)
    {
        _db.Flavors.Update(flavor);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
    public ActionResult Delete (int id)
    {
        Flavor thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
        return View (thisFlavor);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
        Flavor thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
        _db.Flavors.Remove(thisFlavor);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult AddTreat (int id)
    {
        Flavor thisFlavor = _db.Flavors.FirstOrDefault(flavors => flavors.FlavorId == id);
        List<Treat> treats = _db.Treats.ToList();
        SelectList treatList = new SelectList(treats, "TreatId", "TreatName");
        ViewBag.TreatId = treatList;
        return View(thisFlavor);
    }
    [HttpPost]
    public ActionResult AddTreat(Flavor flavor, int treatId)
    {
        #nullable enable
        TreatFlavor? joinEntity = _db.TreatFlavors.FirstOrDefault(join => (join.TreatId == treatId && join.FlavorId == flavor.FlavorId));
        #nullable disable
        if (joinEntity == null && treatId != 0)
        {
            _db.TreatFlavors.Add(new TreatFlavor() { TreatId = treatId, FlavorId = flavor.FlavorId});
            _db.SaveChanges();
        }
        return RedirectToAction("Details", new { id = flavor.FlavorId});
    }

    }

}