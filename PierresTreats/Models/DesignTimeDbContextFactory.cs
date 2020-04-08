using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Pierre.Models
{
  public class PierresTreatsContextFactory : IDesignTimeDbContextFactory<PierresTreatsContext>
  {
    PierresTreatsContext IDesignTimeDbContextFactory<PierresTreatsContext>.CreateDbContext()
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();
    }
  }
}
