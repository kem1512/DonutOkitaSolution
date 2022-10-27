using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Data.Context
{
    public class DonutOkitaContextFactory : IDesignTimeDbContextFactory<DonutOkitaContext>
    {
        public DonutOkitaContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            var connectionString = configuration.GetConnectionString("DonutOkita");
            var optionBuilder = new DbContextOptionsBuilder<DonutOkitaContext>().UseSqlServer(connectionString);
            return new DonutOkitaContext(optionBuilder.Options);
        }
    }
}
