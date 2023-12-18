using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.data.EF
{
    public class _1015DbContextFactory : IDesignTimeDbContextFactory<_1015DbContext>
    {
        public _1015DbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("MyDB");

            var optionsBuilder = new DbContextOptionsBuilder<_1015DbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new _1015DbContext(optionsBuilder.Options);
        }
    }
}
