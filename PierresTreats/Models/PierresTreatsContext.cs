using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Pierre.Models
{
    public class PierresTreatsContext 
    {
        public virtual DbSet<Flavor> Flavors { get; set; }
        public DbSet<Treat> Treats { get; set; }

        public PierresTreatsContext(DbContextOptions options) : base(options) { }
    
    }
}