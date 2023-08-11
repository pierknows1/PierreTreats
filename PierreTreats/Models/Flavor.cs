using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PierreTreats.Models

{
    public class Flavor
    {
        public int FlavorId { get; set; }
        public string FlavorName { get; set; }
        public List<TreatFlavor> JoinEntities { get; set; }
        

    }
}