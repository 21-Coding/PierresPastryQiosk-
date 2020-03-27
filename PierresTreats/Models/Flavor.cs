using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Pierre.Models
{
    public class Flavor
    {
        public Flavor()
        {
            // join table bones
            // this.Treats = new HashSet<>():
        }

        public int FlavorId { get; set; }
        public string FlavorName { get; set; }

        // join table bones
        // public ICollection<> Treats { get; }
    }
}