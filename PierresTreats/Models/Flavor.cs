using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Pierre.Models
{
    public class Flavor
    {
        public Flavor()
        {
            this.Treats = new HashSet<TreatFlavor>();
        }

        public int FlavorId { get; set; }
        public string FlavorName { get; set; }

      
        public ICollection<TreatFlavor> Treats { get; }
    }
}
