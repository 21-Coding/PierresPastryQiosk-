using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Pierre.Models
{
    public class Treat
    {
        public Treat()
        {
            // join table bones
            // this.Flavors = new HashSet<>();
        }

        public int TreatId { get; set; }
        public string TreatName { get; set; }
        // join table bones 
        // public virtual ICollection<> Flavors { get; set; }
    }
}