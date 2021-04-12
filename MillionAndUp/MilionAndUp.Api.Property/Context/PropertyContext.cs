using Microsoft.EntityFrameworkCore;
using MilionAndUp.Models;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
//Add-Migration InitialMigration -Context PropertyContext
//Update-Database -Context PropertyContext


/*
 *docker pull mcr.microsoft.com/mssql/server
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=pass" -p 1433:1433 -d mcr.microsoft.com/mssql/server


docker network create microservicesproperty
docker network list
doker network connect microservicesnet sqlservername



cambiar en el conection string  
 * 
 * */


namespace MillionAndUp
{
    public class PropertyContext : DbContext
    {
        public PropertyContext(DbContextOptions<PropertyContext> options) : base(options)
        {

        }

        public DbSet<Owner> Owner { get; set; }
        public DbSet<Property> Property { get; set; }
        public DbSet<PropertyImage> PropertyImage { get; set; }
        public DbSet<PropertyTrace> PropertyTrace { get; set; }
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PropertyContext>
    {
        public PropertyContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../MilionAndUp.Api.Property/appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<PropertyContext>();
            var connectionString = configuration.GetConnectionString("MillionAndUpConnection");
            builder.UseSqlServer(connectionString);
            return new PropertyContext(builder.Options);
        }
    }
}