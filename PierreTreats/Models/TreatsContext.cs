using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace PierreTreats.Models
{
    public class TreatsContext : IdentityDbContext<ApplicationUser>
    {  
        public DbSet<Flavor> Flavors { get; set; }
        public DbSet<Treat> Treats { get; set; }
        public DbSet<TreatFlavor> TreatFlavors { get; set; }
        public TreatsContext(DbContextOptions options) : base(options) { }
    }
   
 }  