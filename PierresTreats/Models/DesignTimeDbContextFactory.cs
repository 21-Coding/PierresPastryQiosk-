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

      var builder = new DbContextOptionsBuilder<PierresTreatsContext>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");

      builder.UseMySql(connectionString);

    }
  }
}
