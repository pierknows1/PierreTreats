using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using PierreTreats.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace PierreTreats.Controllers

{
    public class TreatsController : Controller

    {

    private readonly TreatsContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public TreatsController(UserManager<ApplicationUser> userManager, TreatsContext db)
    {
        _db = db;
        _userManager = userManager;
        }

    public ActionResult Index()
    {
        return View(_db.Treats.ToList());
        }

    public ActionResult Create()
    {
        return View();
        }

    [HttpPost]
    public ActionResult Create (Treat treat)
    {
        _db.Treats.Add(treat);
        _db.SaveChanges();
        return RedirectToAction("Index");
        }

    public ActionResult Details(int id)
    {
        ViewBag.Flavors = _db.Flavors.ToList();
        Treat thisTreat = _db.Treats
                .Include(treat => treat.JoinEntities)
                .ThenInclude(join => join.Flavor)
                .FirstOrDefault(treat => treat.TreatId == id);
        return View(thisTreat); 
        }   
    
    public ActionResult AddFlavor (int id)
    {
        Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
        ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "FlavorName");
        return View(thisTreat);
    }

    [HttpPost]
        public ActionResult AddFlavor(Treat treat, int flavorId)
        {
        #nullable enable
        TreatFlavor? joinEntity = _db.TreatFlavors.FirstOrDefault(join => (join.FlavorId == flavorId && join.TreatId == treat.TreatId));
        #nullable disable
        if (joinEntity == null && flavorId != 0)
        {
        _db.TreatFlavors.Add(new TreatFlavor() { FlavorId = flavorId, TreatId = treat.TreatId });
        _db.SaveChanges();
        }
        return RedirectToAction("Details", new { id = treat.TreatId });
        }

    public ActionResult Edit(int id)
    
    {
        Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
        return View(thisTreat);
        }

    [HttpPost]
        public ActionResult Edit(Treat treat)
    {
        _db.Treats.Update(treat);
        _db.SaveChanges();
        return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
    {
        Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
        return View(thisTreat);
        }

    [HttpPost, ActionName("Delete")]

    public ActionResult DeleteConfirmed(int id)
    {
        Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
        _db.Treats.Remove(thisTreat);
        _db.SaveChanges();
        return RedirectToAction("Index");
        }

    [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
        TreatFlavor joinEntry = _db.TreatFlavors.FirstOrDefault(entry => entry.TreatFlavorId == joinId);
        _db.TreatFlavors.Remove(joinEntry);
        _db.SaveChanges();
        return RedirectToAction("Index");
        }
    }
}
