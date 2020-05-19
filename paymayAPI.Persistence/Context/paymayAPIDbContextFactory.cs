using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace paymayAPI.Persistence.Context {
    public class paymayAPIDbContextFactory : IDesignTimeDbContextFactory<paymayAPIDbContext> {
        public static IConfigurationRoot Configuration { get; set; }
        public paymayAPIDbContextFactory () {
            var builder = new ConfigurationBuilder ()
                .SetBasePath (Directory.GetCurrentDirectory ())
                .AddJsonFile ("appsettings.json");
            Configuration = builder.Build ();
        }
        public paymayAPIDbContext CreateDbContext (string[] args) {
            var optionsBuilder = new DbContextOptionsBuilder<paymayAPIDbContext> ();
            optionsBuilder.UseSqlServer (Configuration.GetConnectionString ("Default"));
            return new paymayAPIDbContext (optionsBuilder.Options);
        }
    }
}